/*
NetworkController

Author: Don Ebben

Purpose: state machine for managing the networking


*/

#ifndef NETWORKCONTROLLER_H
#define NETWORKCONTROLLER_H

#include <WiFiShieldOrPmodWiFi.h>

#include <DNETcK.h>
#include <DWIFIcK.h>
#include "Car.h"
const int cPending = 3; // number of clients the server will hold until accepted


typedef enum
{
    NONE = 0,
    INITIALIZE,
    LISTEN,
    ISLISTENING,
    AVAILABLECLIENT,
    ACCEPTCLIENT,
    READ,
    WRITE,
    CLOSE,
    EXIT,
    DONE
} STATE;


class NetworkController {
	private:
		
		unsigned short portServer;

		unsigned tStart;
		unsigned tWait;

		// remember to give the UDP client a datagram cache
		byte rgbUDPClientCache[1024];
		UdpClient *udpClient;

		// remember to give the server a datagram cache that is 
		// equal or larger than the client datagram cache

		byte rgbUDPServerCache[cPending * sizeof(rgbUDPClientCache)];
		UdpServer *udpServer;

		// a read buffer
		byte rgbRead[1024];
		int cbRead;
		int count;

		DNETcK::STATUS status;



	public:
		Car *car;
		unsigned int packetSize;		
		IPv4 ipServer;
		STATE state;
		void run();
		void begin();
};

#endif