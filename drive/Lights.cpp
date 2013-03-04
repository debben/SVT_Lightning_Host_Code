/*

Lights.h

Author: Don Ebben

Purpose: contains class prototypes for the light controller.

*/

#include "Lights.h"
#include "config.h"
#include <wiring.h>

#include <peripheral/timer.h>

LightsClass Lights;

//80 mhz
int sampleRate = 1000;

//with 40mhz at 1/256 prescale, roughly 156.25 ticks per ms
#define MILI	313

volatile bool brake = false;
volatile bool left = false;
volatile bool right = false;


volatile byte lightMask =0;


//ISR's must be strait C
#ifdef __cplusplus
extern "C" {
#endif

void __ISR(_TIMER_2_VECTOR,IPL3AUTO) lightToggle(void)
{

  if(lightMask & BRAKE_LIGHT){
  	digitalWrite(BRAKE_LED,brake);
  	brake = !brake;
  }

  if(lightMask & LEFT_SIGNAL)
  {
  	digitalWrite(LEFT_SIGNAL_LED, left);
  	left = !left;
  }

  if(lightMask & RIGHT_SIGNAL){
  	digitalWrite(RIGHT_SIGNAL_LED, right);	
  	right = !right;
  }
  


  

  
  mT2ClearIntFlag();  // Clear interrupt flag
  
}

#ifdef __cplusplus
}
#endif

void LightsClass::begin(){

	pinMode(BRAKE_LED,OUTPUT);
	pinMode(LEFT_SIGNAL_LED,OUTPUT);
	pinMode(RIGHT_SIGNAL_LED,OUTPUT);

	OpenTimer2( T2_ON | T2_PS_1_256 | T2_SOURCE_INT, 156250 - sampleRate*MILI);
	ConfigIntTimer2((T2_INT_ON | T2_INT_PRIOR_3));
	//EnableIntT2();
}

void LightsClass::setPeriod(int p){
	sampleRate = p;
	//update
	OpenTimer2( T2_ON | T2_PS_1_256 | T2_SOURCE_INT, 156250 - sampleRate*MILI);
}

void LightsClass::setBlinkingLights(byte mask){
	lightMask = mask;
}

void LightsClass::setLights(byte mask, bool state){

	if(lightMask & BRAKE_LIGHT){
  		digitalWrite(BRAKE_LED,state);
  	}

  	if(lightMask & LEFT_SIGNAL)
  	{
	  	digitalWrite(LEFT_SIGNAL_LED, state);
  	}

	if(lightMask & RIGHT_SIGNAL){
	  	digitalWrite(RIGHT_SIGNAL_LED, state);	
  	}
}



/*
void dissableLights(){
	DisableIntT2();

}

void enableLights()
{
	EnableIntT2();
}
*/