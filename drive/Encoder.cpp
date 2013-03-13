/*
Encoder

Author: Don Ebben

Purpose: Class for encoder management


*/

#include <Encoder.h>
#include "config.h"
#include <WProgram.h>
#include <SD.h>

Odometer Encoder;

//vars
int QRE1113_Pin = 7;

volatile unsigned int wheel_count =0;

long time;// = micros();
long duration;
volatile unsigned int period = 0;
unsigned int last_rev;
bool ff = false;


void Odometer::begin(){
  //read from SD card and get initial odometer value
  //File myFile = SD.open("odd",FILE_READ);
// if(myFile != NULL){
 //   byte* temp = (byte*)&wheel_count;
 //   temp[0] = myFile.read();
 //   temp[1] += myFile.read() << 8;
 //   temp[2] += myFile.read() << 16;
  //  temp[3] += myFile.read() << 24;

  //}

 // myFile.close();
  pinMode( QRE1113_Pin, OUTPUT );
  digitalWrite(QRE1113_Pin,LOW);//pull the pin low to charge low for a bit
  delay(50);

  attachInterrupt(2, readQD, FALLING);

  
  digitalWrite( QRE1113_Pin, HIGH );  
  delayMicroseconds(ONTIME);
  pinMode( QRE1113_Pin, INPUT );

}

void Odometer::run(){

}

void Odometer::save(){
  //save the int to the sd card
  File myFile = SD.open("odd",FILE_WRITE);
  myFile.write((uint8_t*)&wheel_count,sizeof(unsigned int));
  myFile.close();
}


void readQD(){
  //Returns value from the QRE1113 
  //Lower numbers mean more refleacive
  //More than 3000 means nothing was reflected.
  //Serial.println(micros()-time);
  duration = micros()-time;
  boolean temp = duration < REV_WINDOW;
  if(temp && !ff) {
    wheel_count++;
    period = micros() - last_rev;
    if(period > IDLE_WHEEL_WINDOW) period = 0;
    last_rev = micros();
  }

  ff=temp;
  pinMode( QRE1113_Pin, OUTPUT );
  digitalWrite( QRE1113_Pin, HIGH );  
  delayMicroseconds(ONTIME);
  pinMode( QRE1113_Pin, INPUT );
  time = micros();

  
}