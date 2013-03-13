/*
Audio.h

an audio controller class
*/
#ifndef AUDIO_H
#define AUDIO_H
#include <WProgram.h>

#define TogglePin(pin)                  \
            digitalWrite(pin, HIGH);    \
            delay(AUDIO_TOGGLE_DELAY);  \
            digitalWrite(pin, LOW);     \
            delay(AUDIO_TOGGLE_DELAY);  \
            digitalWrite(pin, HIGH);    \

class Audio{
	public:
		void togglePlayback();
		void nextTrack();
		void previousTrack();
		bool audioIsBusy();
		void setup();

};

extern Audio Stereo;

#endif