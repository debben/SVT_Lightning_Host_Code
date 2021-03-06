/*

Car.h

Author: Don Ebben

Purpose: contains prototypes for the car class.

*/
#ifndef CAR_H
#define CAR_H

#include <Servo.h>
#include "config.h"

//constants
#define NEUTRAL			90

//macros
#define MAP_VALUE(lowIn,highIn,lowOut,highOut,value)  (((highOut - lowOut) * value)/(highIn - lowIn)) + ((highOut-lowOut)/2)

//this structure contains the UDP data packet format
struct DrivePacket {
	signed short throttle_power;
	signed short steering_angle;
	byte aux;
};

//this structure is the response messae
struct ReturnPacket {
	unsigned int count;
	unsigned int period;
};

class Car {

	private:
		int odemeter;
		DrivePacket controls;
		Servo throttle, steering;



	public:
		bool begin();
		void drive(byte* p);
		void dissable();



};


#endif