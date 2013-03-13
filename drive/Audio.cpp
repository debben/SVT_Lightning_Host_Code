/*
Audio.cpp

Audio controller

*/

#include "Audio.h"
#include "config.h"

Audio Stereo;

void Audio::setup()
{    
    // initialize the audio breakout pins
    pinMode(AUDIO_RESET_PIN,OUTPUT);    // do not toggle
    pinMode(AUDIO_PREVIOUS_PIN, OUTPUT); digitalWrite(AUDIO_PREVIOUS_PIN, HIGH);
    pinMode(AUDIO_NEXT_PIN, OUTPUT);     digitalWrite(AUDIO_NEXT_PIN, HIGH);
    pinMode(AUDIO_PLAY_PIN, OUTPUT);     digitalWrite(AUDIO_PLAY_PIN, HIGH);
    pinMode(AUDIO_BUSY_PIN, INPUT);     // input only

}

void Audio::togglePlayback()
{
	#ifdef VERBOSE_SERIAL
    // read the busy pin
    switch (audioIsBusy())
    {
        case true:
            // playback is active
            // print
            Serial.println("State before 'PLAY' pin toggle: [  ACTIVE  ]");
            // break out
            break;
        case false:
            // playback is inactive
            // print
            Serial.println("State before 'PLAY' pin toggle: [ INACTIVE ]");
            // break out
            break;
    }
    #endif
    // toggle the PLAY pin
    TogglePin(AUDIO_PLAY_PIN);
    // read the busy pin
    #ifdef VERBOSE_SERIAL
    switch (audioIsBusy())
    {
        case true:
            // playback is active
            // print
            Serial.println("State after 'PLAY' pin toggle:  [  ACTIVE  ]");
            // break out
            break;
        case false:
            // playback is inactive
            // print
            Serial.println("State after 'PLAY' pin toggle:  [ INACTIVE ]");
            // break out
            break;
    }
    #endif
}
void Audio::nextTrack()
{
    // toggle the NEXT pin
    TogglePin(AUDIO_NEXT_PIN);
}
void Audio::previousTrack()
{
    // toggle the PREV pin
    TogglePin(AUDIO_PREVIOUS_PIN);
}
bool Audio::audioIsBusy()
{
    // the result
    bool result = digitalRead(AUDIO_BUSY_PIN);
    // return the result
    return result;
}