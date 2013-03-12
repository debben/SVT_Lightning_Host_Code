/*

Lights.h

Author: Don Ebben

Purpose: contains class prototypes for the light controller.

*/

#ifndef LIGHTS_H
#define LIGHTS_H
#include <WProgram.h>



#define BRAKE_LIGHT				0x01
#define LEFT_SIGNAL				0x02
#define RIGHT_SIGNAL			0x04

//void __ISR(_TIMER_2_VECTOR,IPL3AUTO) lightToggle(void);
class LightsClass
{
public:
	void setPeriod(int p);
	void setBlinkingLights(byte mask);
	void setLights(byte mask, bool state);
	void begin();
	
};

extern LightsClass Lights;

#endif
