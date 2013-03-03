/*
Car.cpp

Author: Don Ebben

Contains methods and variables related to the car class.


*/

#include "Car.h"
#include "config.h"


//Configures the car for opperation.
bool Car::begin(){

	//configure the defualt packet

	//start with the PWM controlled devices
	steering.attach(STEERING_PIN);
	throttle.attach(THROTTLE_PIN);

	//set to neutral for now
	steering.write(NEUTRAL);
	throttle.write(NEUTRAL);
}

void Car::drive(DrivePacket* p)
{

}


