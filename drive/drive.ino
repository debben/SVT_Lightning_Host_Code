/*

Drive.ino

Author: Don Ebben

Purpose: Test out preliminary driving classes.

*/
#include "config.h"


#include <WiFiShieldOrPmodWiFi.h>

#include <DNETcK.h>
#include <DWIFIcK.h>


#include "Lights.h"
#include <aJSON.h>
#include <SD.h>
#include <Servo.h>
#include "Car.h"
#include "VehicleController.h"



//variables
Car ford;
VehicleController controller;

void setup(){
  ford.begin();
  controller.car = ford;
  Lights.begin();
  Lights.setLights(BRAKE_LIGHT | LEFT_SIGNAL | RIGHT_SIGNAL, LOW);
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