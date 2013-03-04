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
#define THROTTLE_PIN			36

#define SD_SPI_CS				4


//compile time options comment to dissable

//#define VERBOSE_SERIAL
//#define FAT_DEGBUG

#endif