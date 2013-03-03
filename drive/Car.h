/*

Car.h

Author: Don Ebben

Purpose: contains prototypes for the car class.

*/
#include <Servo.h>
#include "config.h"

//constants
#define NEUTRAL			90


//this structure contains the UDP data packet format
typedef struct DrivePacket {
	signed short throttle, steering;
};

class Car {

	private:
		int odemeter;
		DrivePacket controls;
		Servo throttle, steering;



	public:
		bool begin();
		void drive(DrivePacket* p);

};


