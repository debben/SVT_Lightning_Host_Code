/*
	VehicleController.cpp

	Author: Don Ebbben

	Purpose: A state machine that determines how to opperate the vehicle
			based on the enviroment and netwrok status.
*/

#include "VehicleController.h"
#include <string.h>
#include <stdlib.h>
#include "Lights.h"      
#include "Encoder.h"
#include "Audio.h"      

void VehicleController::run(){
	switch(state){
		case STATE_START:
      Lights.setPeriod(1500);
      Lights.setLights(LEFT_SIGNAL | RIGHT_SIGNAL | BRAKE_LIGHT, LOW );
      Lights.setBlinkingLights(LEFT_SIGNAL | RIGHT_SIGNAL | BRAKE_LIGHT);
			#ifdef AUDIO
      Stereo.setup();
      #endif

      state = setupSD();
			break;
		case STATE_CHECKING_SD:
			//do code to try and read the file off the SD card
			state = mountSD();
			break;
		case STATE_CONFIGURE_NETWORK:    
			state = readNetworkConfig();
			break;
		case STATE_CONNECTING:
      //we have good sd. Let's setup the encoder
      Encoder.begin();
      state = connectToNetwork();
      //set the caution lights
      Lights.setPeriod(2500);
      Lights.setLights(BRAKE_LIGHT,LOW);
      Lights.setBlinkingLights(LEFT_SIGNAL | RIGHT_SIGNAL);
			break;
    case STATE_CONNECTED:
      #ifdef AUDIO
      //todo: remove this later
      Stereo.togglePlayback();
      #endif
      net.run();
      break;
    case STATE_WARNING:
      break;
		default:
			state = STATE_WARNING;
	}
}

//verify the SD card exists
int VehicleController::setupSD(){
	// we'll use the initialization code from the utility libraries
	// since we're just testing if the card is working!
  if (!card.init(SPI_HALF_SPEED, SD_SPI_CS)) 
  {
  	#ifdef VERBOSE_SERIAL
	    Serial.println("initialization failed. Things to check:");
	    Serial.println("* is a card is inserted?");
	    Serial.println("* Is your wiring correct?");
	    Serial.println("* did you change the chipSelect pin to match your shield or module?");
    #endif
  
    return STATE_NO_SD;
  } 
  else 
  {
  	#ifdef VERBOSE_SERIAL
   		Serial.println("Wiring is correct and a card is present."); 
   	#endif
   	return STATE_CHECKING_SD;
  }
}

int VehicleController::mountSD(){
	//welp, looks like we have to do this...
	SD.begin(SD_SPI_CS);
	  // Now we will try to open the 'volume'/'partition' - it should be FAT16 or FAT32
  if (!(volume.init(card) && root.openRoot(volume))) {
  	#ifdef VERBOSE_SERIAL
    	Serial.println("Could not find FAT16/FAT32 partition.\nMake sure you've formatted the card");
	#endif    	
    return STATE_FILESYSTEM_ERROR;
  }
  else{
  	//if we got here, then let's try to find the file "network.config" in the root folder
    //"/Android/data/com.ebarch.ipgamepad/files/network.config"
	if(SD.exists("netconf")){
		netConfig = SD.open("netconf");
		
		file_pointer = new aJsonStream(&netConfig);
		return STATE_CONFIGURE_NETWORK;
	}
	else {
		#ifdef VERBOSE_SERIAL
			Serial.println("Can't find network.config");
		#endif
		return STATE_FILESYSTEM_ERROR;
	}
  }
}

int VehicleController::readNetworkConfig(){
	if (file_pointer->available()) {
   /* First, skip any accidental whitespace like newlines. */
    file_pointer->skip();
  }

  if (file_pointer->available()) {
    /* Something real on input, let's take a look. */
    aJsonObject *msg = aJson.parse(file_pointer);
    
    if(msg == NULL){
    	return STATE_JSON_ERROR;
    }

    //now let's take a good hard look at this JSON
    aJsonObject *datum = aJson.getObjectItem(msg,"SSID");

    if(datum == NULL){
    	return STATE_JSON_ERROR;
    }

    #ifdef VERBOSE_SERIAL
    	Serial.print("SSID: ");
    	Serial.println(datum->valuestring);
    #endif

    //copy in the string
    ssid = (char*)malloc(strlen(datum->valuestring));
    strcpy(ssid,datum->valuestring);

    //now the port
    datum = aJson.getObjectItem(msg,"port");

    if(datum == NULL){
    	return STATE_JSON_ERROR;
    }

	  #ifdef VERBOSE_SERIAL
    	Serial.print("port: ");
    	Serial.println(datum->valueint, DEC);
    #endif

    port = datum->valueint;

    //now the ip address (this one's the hard one.)
    datum = aJson.getObjectItem(msg,"preferedIP");

    if(datum == NULL){
    	return STATE_JSON_ERROR;
    }

    #ifdef VERBOSE_SERIAL
    	Serial.print("Prefered IP: ");
    	Serial.println(datum->valuestring);
    #endif

    //ok. we need to parse out this number and store it in a 32 bit int
    char* octet = strtok(datum->valuestring,".");

    while (octet != NULL)
    {
    	ip = ip << 8; //shift out the octet
    	ip += atoi(octet);                 
    	octet = strtok(NULL, ".");
    }

    #ifdef VERBOSE_SERIAL
    	Serial.print("IP bytes: ");
    	Serial.println(ip,HEX);
    #endif

    datum = aJson.getObjectItem(msg,"preSharedKey");

    if(datum == NULL){
      return STATE_JSON_ERROR;
    }

    #ifdef VERBOSE_SERIAL
      Serial.print("preSharedKey: ");
      Serial.println(datum->valuestring);
    #endif

    //copy in the string
    preSharedKey = (char*)malloc(strlen(datum->valuestring));
    strcpy(preSharedKey,datum->valuestring);
    	

    aJson.deleteItem(msg);
	  netConfig.close();
	  return STATE_CONNECTING;    
  }
}

int VehicleController::connectToNetwork(){
  DNETcK::STATUS status;
  int conID = DWIFIcK::INVALID_CONNECTION_ID;

  if((conID = DWIFIcK::connect(ssid, preSharedKey, &status)) != DWIFIcK::INVALID_CONNECTION_ID)
  {
      #ifdef VERBOSE_SERIAL
        Serial.print("Connection Created, ConID = ");
        Serial.println(conID, DEC);
      #endif
      state = INITIALIZE;
  }
  else
  {
      #ifdef VERBOSE_SERIAL
        Serial.print("Unable to connection, status: ");
        Serial.println(status, DEC);
      #endif  
      state = CLOSE;
  }

  // intialize the stack with a static IP
  IPv4 ipserv =   {192,168,0,190};
  //{ip & 0xFF000000,
    //              ip & 0x00FF0000,
      //            ip & 0x0000FF00,
        //          ip & 0x000000FF};

  net.ipServer = ipserv;
  DNETcK::begin(net.ipServer);

  net.begin();

  while(net.state == INITIALIZE){
    net.run(); //run until the network stack is initialized.
  }
  if(net.state == EXIT || net.state == DONE){
    return STATE_WARNING;
  }

  net.car = &car;
  net.packetSize = sizeof(DrivePacket);

  return STATE_CONNECTED;
}
