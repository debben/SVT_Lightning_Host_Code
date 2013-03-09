/*
NetworkController

Author: Don Ebben

Purpose: state machine for managing the networking
*/
#include "config.h"
#include "NetworkController.h"
#include "Lights.h"



void NetworkController::begin(){
  state = INITIALIZE;
  tStart = 0;
  tWait = UDP_CLIENT_TIMEOUT;
  udpClient = new UdpClient(rgbUDPClientCache, sizeof(rgbUDPClientCache));

  portServer = DNETcK::iPersonalPorts44 + 400;

  // remember to give the server a datagram cache that is 
  // equal or larger than the client datagram cache

  udpServer = new UdpServer(rgbUDPServerCache, sizeof(rgbUDPServerCache), cPending);
  cbRead = 0;
  count = 0;

}


void NetworkController::run(){
	switch(state)
    {

    // say to listen on the port
    case INITIALIZE:
        if(DNETcK::isInitialized(&status))
        {
        	#ifdef VERBOSE_SERIAL        	
            	Serial.println("IP Stack Initialized");
            #endif
            state = LISTEN;
        }
        else if(DNETcK::isStatusAnError(status))
        {
        	#ifdef VERBOSE_SERIAL
            	Serial.print("Error in initializing, status: ");
            	Serial.println(status, DEC);
            #endif
            state = EXIT;
        }
        break;

    case LISTEN:
        if(udpServer->startListening(portServer))
        {
        	#ifdef VERBOSE_SERIAL
            	Serial.println("Started Listening");
            #endif
            state = ISLISTENING;
        }
        else
        {
            state = EXIT;
        }
        break;

    // not specifically needed, we could go right to AVAILABLECLIENT
    // but this is a nice way to print to the serial monitor that we are 
    // actively listening.
    // Remember, this can have non-fatal falures, so check the status
    case ISLISTENING:
        if(udpServer->isListening(&status))
        {
        	#ifdef VERBOSE_SERIAL
            	Serial.print("Listening on port: ");
            	Serial.print(portServer, DEC);
            	Serial.println("");
            #endif
            state = AVAILABLECLIENT;
        }
        else if(DNETcK::isStatusAnError(status))
        {
            state = EXIT;
        }
        break;

    // wait for a connection
    case AVAILABLECLIENT:
        if((count = udpServer->availableClients()) > 0)
        {
        	#ifdef VERBOSE_SERIAL
	            Serial.print("Got ");
            	Serial.print(count, DEC);
            	Serial.println(" clients pending");
            #endif
            state = ACCEPTCLIENT;
        }
        break;

    // accept the connection
    case ACCEPTCLIENT:
        
        // probably unneeded, but just to make sure we have
        // udpClient in the  "just constructed" state
        udpClient->close(); 

        // accept the client 
        if(udpServer->acceptClient(udpClient))
        {

            //Let's turn the lights off
            Lights.setBlinkingLights(0);
            Lights.setLights(0,false);
        	#ifdef VERBOSE_SERIAL
            	Serial.println("Got a Connection");
            #endif
            state = READ;
            tStart = (unsigned) millis();
        }

        // this probably won't happen unless the connection is dropped
        // if it is, just release our socket and go back to listening
        else
        {
            state = CLOSE;
        }
        break;

    // wait fot the read, but if too much time elapses (5 seconds)
    // we will just close the udpClient and go back to listening
    case READ:

        // see if we got anything to read
        if((cbRead = udpClient->available()) > 0)
        {
            cbRead = cbRead < sizeof(rgbRead) ? cbRead : sizeof(rgbRead);
            cbRead = udpClient->readDatagram(rgbRead, cbRead);

            #ifdef VERBOSE_SERIAL
            	Serial.print("Got ");
            	Serial.print(cbRead, DEC);
            	Serial.println(" bytes");
            #endif
           
           //parse out the data
           if(cbRead != packetSize){
             break;
             
           }
           //ok. Reading this in is weird. The endianness of the 
           
           //chip kit is reverse of what we think it is. //probably best
           //to just send packets
           
           car->drive(rgbRead);
           
			#ifdef VERBOSE_SERIAL

           		//Serial.print("Throttle: ");
           		//Serial.println(throttle_power,DEC);

           		//Serial.print("Steering: ");
           		//Serial.println(steering_angle,DEC);           
            #endif

           
        }

        // If too much time elapsed between reads, close the connection
        else if( (((unsigned) millis()) - tStart) > tWait )
        {
            state = CLOSE;
        }
        break;


    // echo back the string
    case WRITE:
    	//TODO: 
    	#ifdef VERBOSE_SERIAL
        	Serial.println("Writing datagram: ");  
        

	        //for(int i=0; i < cbRead; i++) 
        	//{
	        //    Serial.print(rgbRead[i], BYTE);
        	//}
        	//Serial.println("");  

		#endif

        //udpClient->writeDatagram(rgbRead, cbRead);
        //state = READ;
        //tStart = (unsigned) millis();
        break;
        
    // close our udpClient and go back to listening
    case CLOSE:
        udpClient->close();
        //turn the lights back on
        Lights.setBlinkingLights(LEFT_SIGNAL | RIGHT_SIGNAL);
        car->dissable();

        #ifdef VERBOSE_SERIAL
        	Serial.println("Closing UdpClient");
        	Serial.println("");
        #endif
        state = ISLISTENING;
        break;

    // something bad happen, just exit out of the program
    case EXIT:
        udpClient->close();
        udpServer->close();
        #ifdef VERBOSE_SERIAL
        	Serial.println("Something went wrong, sketch is done.");  
        #endif
        state = DONE;
        break;

    // do nothing in the loop
    case DONE:
    default:
        break;
    }

    // every pass through loop(), keep the stack alive
    DNETcK::periodicTasks(); 
}