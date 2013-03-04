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

void Car::drive(byte* p)
{
	short throttle_power = *((short*)p);
	short steering_angle = *((short*)(p+2));

	throttle_power = MAP_VALUE(-1000,1000,0,180,throttle_power);
    steering_angle = MAP_VALUE(-1000,1000,0,180,steering_angle);

    #ifdef VERBOSE_SERIAL
    	Serial.print("Throttle: ");
	    Serial.println(throttle_power,DEC);

    	Serial.print("Steering: ");
    	Serial.println(steering_angle,DEC);   
    #endif

   	throttle.write(throttle_power);
           
    steering.write(steering_angle);

}


