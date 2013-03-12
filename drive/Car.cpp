/*
Car.cpp

Author: Don Ebben

Contains methods and variables related to the car class.


*/

#include "Car.h"
#include "config.h"
#include "Lights.h"
#include "Encoder.h"

bool lastWasForward = true;

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
	struct DrivePacket* pac = (struct  DrivePacket*)p;
	
	//short throttle_power = *((short*)p);
	//short steering_angle = *((short*)(p+2));

	pac->throttle_power = MAP_VALUE(-1000,1000,0,180,pac->throttle_power);
    pac->steering_angle = MAP_VALUE(-1000,1000,0,180,pac->steering_angle);

	lastWasForward = (pac->throttle_power < NEUTRAL && lastWasForward);
	if(lastWasForward)
	{
		lastWasForward = false;
		pac->throttle_power = NEUTRAL;
		Lights.setLights(BRAKE_LIGHT, false);
	}
	else if(pac->throttle_power > NEUTRAL)
	{
		lastWasForward = true;
		Lights.setLights(BRAKE_LIGHT, true);
	}

	

    #ifdef VERBOSE_SERIAL
    	Serial.print("Throttle: ");
	    Serial.println(pac->throttle_power,DEC);

    	Serial.print("Steering: ");
    	Serial.println(pac->steering_angle,DEC);   
    #endif

   	throttle.write(pac->throttle_power);
           
    steering.write(pac->steering_angle);

    #ifdef LIGHTS
    //if not in a warning state, set the time to be a normal turn signal period
    Lights.setBlinkingLights(pac->aux << 1);
    #endif

}

void Car::dissable(){
	throttle.write(NEUTRAL);//put the car in neutral.
}
