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
#define RIGHT_SIGNAL_LED		25

#define STEERING_PIN			37
#define THROTTLE_PIN			38

#define SD_SPI_CS				4

#define UDP_CLIENT_TIMEOUT		500

#define ENCODER_PIN				20

#define ONTIME 					10 	//microseconds to charge the cap
#define REV_WINDOW 				1800	//time to consider values from the light sensor valid

#define IDLE_WHEEL_WINDOW		2700000 //microseconds to consider the wheel ldle.

#define ODOM_INT_PIN  7; //connected to the light sensor


// define the audio breakout pins
#define         AUDIO_RESET_PIN      23
#define         AUDIO_PREVIOUS_PIN    36
#define         AUDIO_PLAY_PIN        22
#define         AUDIO_NEXT_PIN        24
#define         AUDIO_BUSY_PIN        26
// define the audio bounds
#define         MAX_TRACK             0x01FF    // 0511
#define         MIN_TRACK             0x0000    // 0000
#define         TOGGLE_DELAY          0x0400    // 1024 (milliseconds)

#define         AUDIO_TOGGLE_DELAY    TOGGLE_DELAY


//brown next 24 
//green play 22
//purple busy 26
//white previous 36
//yellow reset 23

//compile time options comment to dissable


//#define VERBOSE_SERIAL
//#define FAT_DEGBUG
//#define AUDIO
#define LIGHTS
#endif
