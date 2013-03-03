/*

Drive.ino

Author: Don Ebben

Purpose: Test out preliminary driving classes. No networking.

*/
#include "config.h"
#include <aJSON.h>
#include <SD.h>
#include <Servo.h>
#include "Car.h"
#include "VehicleController.h"

#include <WiFiShieldOrPmodWiFi.h>

#include <DNETcK.h>
#include <DWIFIcK.h>

//variables
Car ford;
VehicleController controller;

void setup(){
  ford.begin();
  Serial.begin(9600);
}

void loop(){
  //do network slice
  //do other slices as nessesary
  controller.run();
  /*
      // run the scan state machine
    scanStateMachine();
    // run the udp state machine
    udpStateMachine();
    // run the periodic tasks
    DNETcK::periodicTasks();
    */

}