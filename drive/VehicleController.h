/*
	VehicleController.h

	Author: Don Ebbben

	Purpose: A state machine that determines how to opperate the vehicle
			based on the enviroment and netwrok status.
*/

#ifndef VEHICLECONTROLLER_H
#define VEHICLECONTROLLER_H

#include <SD.h>
#include "config.h"
#include <aJSON.h>
#include "NetworkController.h"
#include <DNETcK.h>
#include "Car.h"

#define STATE_START					0
#define STATE_CHECKING_SD			1
#define STATE_CONNECTING			2
#define STATE_NO_SD					3			
#define STATE_FILESYSTEM_ERROR		4			
#define STATE_CONFIGURE_NETWORK		5
#define STATE_JSON_ERROR			6
#define STATE_CONNECTED				7
#define STATE_WARNING				0xFFFF

class VehicleController
{

private:
	int state;
	Sd2Card card;
	SdVolume volume;
	SdFile root;
	File netConfig;
	aJsonStream* file_pointer;
	NetworkController net;

	int port;
	char* ssid;
	char* preSharedKey;
	unsigned int ip;


	int setupSD();
	int mountSD();
	int readNetworkConfig();
	int connectToNetwork();

public:
	void run();
	Car car;

};

#endif