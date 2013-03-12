/*
config.h

Contains pin definitions as well as details about what to compile
and not compile

*/

#ifndef CONFIG_H
#define CONFIG_H

// Pin configurations

#define BRAKE_LED				28
#define LEFT_SIGNAL_LED			30
#define RIGHT_SIGNAL_LED		32

#define STEERING_PIN			34
#define THROTTLE_PIN			38

#define SD_SPI_CS				4

#define UDP_CLIENT_TIMEOUT		500

#define ENCODER_PIN				20

#define ONTIME 					10 	//microseconds to charge the cap
#define REV_WINDOW 				1800	//time to consider values from the light sensor valid

#define IDLE_WHEEL_WINDOW		2700000 //microseconds to consider the wheel ldle.

#define ODOM_INT_PIN  7; //connected to the light sensor



//compile time options comment to dissable


//#define VERBOSE_SERIAL
//#define FAT_DEGBUG
#define LIGHTS
#endif
