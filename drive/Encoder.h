/*
Encoder

Author: Don Ebben

Purpose: Class for encoder management


*/

#ifndef ENCODER_H
#define ENCODER_H

//includes go here


//globals go here.

void readQD();

class Odometer
{

public:
	void begin();
	void run();
	void save();

	//something to get from the sdcard
	//something to get 

};

extern Odometer Encoder;
extern volatile unsigned int period;
extern volatile unsigned int wheel_count;
#endif
