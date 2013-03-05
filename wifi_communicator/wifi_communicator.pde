#include <WiFiShieldOrPmodWiFi.h>
#include <DNETcK.h>
#include <DWIFIcK.h>

// define the audio breakout pins
#define         AUDIO_RESET_PIN       54
#define         AUDIO_PREVIOUS_PIN    55
#define         AUDIO_PLAY_PIN        56
#define         AUDIO_NEXT_PIN        57
#define         AUDIO_BUSY_PIN        58
// define the audio bounds
#define         MAX_TRACK             0x01FF    // 0511
#define         MIN_TRACK             0x0000    // 0000
#define         TOGGLE_DELAY          0x0400    // 1024 (milliseconds)

#define         AUDIO_TOGGLE_DELAY    TOGGLE_DELAY

// the local ip address
IPv4            local_ip_addr         = { 192, 168, 1, 200 };
// the local port
unsigned short  local_port            = 8888;
// the ssid
const char *    ssid                  = "b166er";
// the passphrase
const char *    passphrase            = "1122334455";
// the ssid's mac address
byte            ssid_mac_addr[]       = { 0x00, 0x15, 0xe9, 0x1D, 0xC4, 0x13 };
// define the wifi connect macro
#define WiFiConnectMacro() DWIFIcK::connect(ssid, passphrase, &status)

// define the maximum buffer sizes
#define MAXIMUM_CLIENT_BUFFER         64
#define MAXIMUM_SERVER_BUFFER         64
#define MAXIMUM_TX_BUFFER             64
#define MAXIMUM_RX_BUFFER             64

// define the maximum number of clients
#define MAXIMUM_CLIENTS               1

// define the status enumeration
typedef enum
{
    UDP_NONE                = 0x00,
    UDP_INITIALIZE          = 0x01,
    UDP_LISTEN              = 0x02,
    UDP_IS_LISTENING        = 0x03,
    UDP_AVAILABLE_CLIENT    = 0x04,
    UDP_ACCEPT_CLIENT       = 0x05,
    UDP_READ                = 0x06,
    UDP_WRITE               = 0x07,
    UDP_CLOSE               = 0x08,
    UDP_EXIT                = 0x09,
    UDP_DONE                = 0x0A
} UDP_STATE;

UDP_STATE udp_state = UDP_INITIALIZE;

typedef enum
{
    NET_NONE                = 0x00,
    NET_WAIT_FOR_SCAN       = 0x01,
    NET_PRINT_AP_INFO       = 0x02,
    NET_ERROR               = 0x03,
    NET_STOP                = 0x04,
    NET_DONE                = 0x05
} NET_STATE;

NET_STATE net_state = NET_WAIT_FOR_SCAN;

// the client buffer
byte            client_buffer[MAXIMUM_CLIENT_BUFFER];
// the server buffer
byte            server_buffer[MAXIMUM_SERVER_BUFFER];
// the input buffer
byte            input_buffer [MAXIMUM_RX_BUFFER];
// the output buffer
byte            output_buffer[MAXIMUM_TX_BUFFER];

// the number of bytes to read
int             bytes_to_read     = 0;
// the number of available clients
int             available_clients = 0;

// the udp client
UdpClient       udp_client(client_buffer, MAXIMUM_CLIENT_BUFFER);
// the udp server
UdpServer       udp_server(server_buffer, MAXIMUM_SERVER_BUFFER, MAXIMUM_CLIENTS);

// the time at which a device connected
unsigned int    connection_start_time = 0;
// the time at which a scan started
unsigned int    scan_start_time       = 0;
// the amount of time to wait (15 seconds)
unsigned int    timeout_duration      = 15000;
// the number of avaialble wifi networks
int             available_networks    = 0;
// the index of the current wifi network 
int             current_network       = 0;


// the subfeature enable flags
boolean         enable_stereo         = false;
boolean         enable_signals        = false;
boolean         enable_battery        = false;

// the parameters
byte            current_speed         = 0;
byte            current_direction     = 0;
byte            current_battery       = 0;
byte            current_signal        = 0;
// the turn signal colors
byte            turn_red              = 0x00;
byte            turn_green            = 0x00;
byte            turn_blue             = 0x00;
// the brake signal colors
byte            brake_red             = 0x00;
byte            brake_green           = 0x00;
byte            brake_blue            = 0x00;
// the reverse signal colors
byte            reverse_red           = 0x00;
byte            reverse_green         = 0x00;
byte            reverse_blue          = 0x00;
// the "track playing" flag
boolean         track_playing         = false;

// define the translate red function
#define TranslateRed(value) map(value, 0, 255, 0, 170)

// the status
DNETcK::STATUS      status = DNETcK::None;
// the scan info object
DWIFIcK::SCANINFO   scan_data;

void setup()
{
    // the connection id
    int connection_id = DWIFIcK::INVALID_CONNECTION_ID;
    // initialize the serial port
    Serial.begin(9600);
    // print
    Serial.println("-------------------------------------------");
    Serial.println("-          Senior Design Project          -");
    Serial.println("-        WiFi R/C Car Communicator        -");
    Serial.println("-    Kettering University, Winter 2013    -");
    Serial.println("-------------------------------------------");
    // initialize the audio breakout pins
    pinMode(AUDIO_RESET_PIN,OUTPUT);    // do not toggle
    pinMode(AUDIO_PREVIOUS_PIN, OUTPUT); digitalWrite(AUDIO_PREVIOUS_PIN, HIGH);
    pinMode(AUDIO_NEXT_PIN, OUTPUT);     digitalWrite(AUDIO_NEXT_PIN, HIGH);
    pinMode(AUDIO_PLAY_PIN, OUTPUT);     digitalWrite(AUDIO_PLAY_PIN, HIGH);
    pinMode(AUDIO_BUSY_PIN, INPUT);     // input only
    // determine if the device can connect to wifi
    if ((connection_id = WiFiConnectMacro()) != DWIFIcK::INVALID_CONNECTION_ID)
    {
        // the device is connected
        // print
        Serial.println("Connection established!");
          Serial.print("ID     = "); Serial.println(connection_id, DEC);

        // save the state
        udp_state = UDP_INITIALIZE;
    }
    else
    {
        // print
        Serial.println("Connection could not be established.");
          Serial.print("Status = "); Serial.println(status, DEC);
        // save the state
        udp_state = UDP_CLOSE;
    }    
    // initialize the stack
    DNETcK::begin(local_ip_addr);
}

#define TogglePin(pin)                  \
            digitalWrite(pin, HIGH);    \
            delay(AUDIO_TOGGLE_DELAY);  \
            digitalWrite(pin, LOW);     \
            delay(AUDIO_TOGGLE_DELAY);  \
            digitalWrite(pin, HIGH);    \

void togglePlayback()
{
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
    // toggle the PLAY pin
    TogglePin(AUDIO_PLAY_PIN);
    // read the busy pin
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
}
void nextTrack()
{
    // toggle the NEXT pin
    TogglePin(AUDIO_NEXT_PIN);
}
void previousTrack()
{
    // toggle the PREV pin
    TogglePin(AUDIO_PREVIOUS_PIN);
}
boolean audioIsBusy()
{
    // the result
    boolean result = digitalRead(AUDIO_BUSY_PIN);
    // return the result
    return result;
}
void scanStateMachine()
{// set the wait time to nothing
    DNETcK::setDefaultBlockTime(DNETcK::msImmediate);
    // begin the scan
    DWIFIcK::beginScan(DWIFIcK::WF_ACTIVE_SCAN);
    // determine the current state of the scan interface
    switch (net_state)
    {
        case NET_WAIT_FOR_SCAN:
            // the program is waiting for the scan to complete
            // determine if the scan is done
            if (DWIFIcK::isScanDone(&available_networks, &status) == true)
            {
                // the scan is complete
                // print
                Serial.println("WiFi network scan was successfully completed!");
                // save the state
                net_state = NET_PRINT_AP_INFO;
            }
            else
            if (DNETcK::isStatusAnError(status))
            {
                // there was an error during the scan
                // print
                Serial.println("WiFi network scan failed.");
                // save the state
                net_state = NET_ERROR;
            }
            // break out
            break;
        case NET_PRINT_AP_INFO:
            // the program is ready to print the access point info
            // loop through the networks
            for (current_network = 0; current_network < available_networks; current_network++)
            {
                // determine if there is scan data for this network
                if (DWIFIcK::getScanInfo(current_network, &scan_data))
                {
                    // there is scan data for this network
                    // print
                    Serial.println("");
                    Serial.print("Index:          "); Serial.println(current_network, DEC);
                    Serial.print("SSID:           "); Serial.println(scan_data.szSsid);
                    Serial.print("Security:       "); Serial.println(scan_data.securityType, DEC);
                    Serial.print("Channel:        "); Serial.println(scan_data.channel, DEC);
                    Serial.print("Strength:       "); Serial.println(scan_data.signalStrength, DEC);
                    Serial.print("Rate Count:     "); Serial.println(scan_data.cBasicRates, DEC);
                    // iterate through the rates
                    for (int rate_index = 0; rate_index < scan_data.cBasicRates; rate_index++)
                    {
                        // print
                        Serial.print("    Rate:       "); 
                          Serial.print(scan_data.basicRates[rate_index], DEC); 
                          Serial.println(" bps");
                    }
                    // print
                    Serial.print("MAC Address:    ");
                    // iterate through the mac address
                    for (int byte_index = 0; byte_index < sizeof(scan_data.ssidMAC); byte_index++)
                    {
                        // determine if this value is less than 16
                        if (scan_data.ssidMAC[byte_index] < 16)
                        {
                            // print
                            Serial.print(0, HEX);
                        }
                        // print the rest of this byte
                        Serial.print(scan_data.ssidMAC[byte_index], HEX);
                    }
                }
            }
            // save the state
            net_state = NET_STOP;
            // break out
            break;
        case NET_ERROR:
            // there was an error
            // print
            Serial.println("There was an error scanning...");
            Serial.print("Status:         "); Serial.println(status, DEC);
            // save the state
            net_state = NET_STOP;
            // break out
            break;
        case NET_STOP:
            // print
            // the scan routine is finished
            Serial.println("Scan process complete, moving to idle state...");
            // save the state
            net_state = NET_DONE;
            // break out
            break;
        case NET_DONE:
        default:
            // idle
            break;
            
    }
}

void udpStateMachine()
{
    // determine the current state of the udp interface
    switch (udp_state)
    {
        case UDP_INITIALIZE:
            // determine if the device is initialized
            if (DNETcK::isInitialized(&status))
            {
                // the device is initialized
                // print
                Serial.println("IP stack initialized!");
                // save the state
                udp_state = UDP_LISTEN;
            }
            else
            if (DNETcK::isStatusAnError(status))
            {
                // there was an error
                // print
                Serial.println("IP stack could not be initialized.");
                  Serial.print("Status = "); Serial.println(status, DEC);
                // save the state
                udp_state = UDP_EXIT;
            }
            // break out
            break;
        case UDP_LISTEN:
            // determine if the udp server started listening
            if (udp_server.startListening(local_port))
            {
                // the server is listening
                // print
                Serial.println("Listening...");
                // save the state
                udp_state = UDP_IS_LISTENING;
            }
            else
            {
                // the server is not listening
                // print
                Serial.println("Error initializing UDP server.");
                // save the state
                udp_state = UDP_EXIT;
            }
            // break out
            break;
        case UDP_IS_LISTENING:
            // determine the state of the udp server
            if (udp_server.isListening(&status))
            {
                // the server is listening
                Serial.print("Listening on port "); Serial.println(local_port, DEC);
                // save the state
                udp_state = UDP_AVAILABLE_CLIENT;
            }
            else
            if (DNETcK::isStatusAnError(status))
            {
                // there was an error
                // save the state
                udp_state = UDP_EXIT;
            }
            // break out
            break;
        case UDP_AVAILABLE_CLIENT:
            // determine if there are any available clients
            if ((available_clients = udp_server.availableClients()) > 0)
            {
                // print
                Serial.println("Client connection pending!");
                // save the state
                udp_state = UDP_ACCEPT_CLIENT;
            }
            // break out
            break;
        case UDP_ACCEPT_CLIENT:
            // ensure that the client is in its "just connected" state
            udp_client.close();
            // determine if the server can accept the client
            if (udp_server.acceptClient(&udp_client))
            {
                // the client was successfully accepted
                // print
                Serial.println("Client connection accepted!");
                // save the state
                udp_state   = UDP_READ;
                // save the start time
                connection_start_time  = (unsigned int)(millis());
            }
            else
            {
                // the connection was dropped
                // print
                Serial.println("Client connection could not be accepted.");
                // save the state
                udp_state   = UDP_CLOSE;
            }
            // break out
            break;
        case UDP_READ:
            // determine if there is anything to read
            if ((bytes_to_read = udp_client.available()) > 0)
            {
                // there is data to read
                // determine how large the buffer should be
                bytes_to_read = (bytes_to_read < MAXIMUM_RX_BUFFER)
                                    ? bytes_to_read
                                    : MAXIMUM_RX_BUFFER;
                // read the datagram
                bytes_to_read = udp_client.readDatagram(input_buffer, bytes_to_read);
                // print
                Serial.print("Received "); Serial.print(bytes_to_read, DEC); Serial.println(" bytes");
                // save the state
                udp_state = UDP_WRITE;
            }
            else
            if ((((unsigned int)(millis())) - connection_start_time) > timeout_duration)
            {
                // the connection timed out
                // save the state
                udp_state = UDP_CLOSE;
            }
            // break out
            break;
        case UDP_WRITE:
            // determine the type of received data
            switch (input_buffer[0])
            {
                case '+':
                    // this was an increase speed command
                    // save the speed
                    current_speed = input_buffer[1];
                    // print
                    Serial.print("Command Received:     "); Serial.println("['+'] INCREASE SPEED");
                    Serial.print("Current Speed:        "); Serial.println(current_speed, DEC);
                    // break out
                    break;
                case '-':
                    // this was a decrease speed command
                    // save the speed
                    current_speed = input_buffer[1];
                    // print
                    Serial.print("Command Received:     "); Serial.println("['-'] DECREASE SPEED");
                    Serial.print("Current Speed:        "); Serial.println(current_speed, DEC);
                    // break out
                    break;
                case '<':
                    // this was a turn left command
                    // save the direction
                    current_direction = input_buffer[1];
                    // print
                    Serial.print("Command Received:     "); Serial.println("['<'] TURN LEFT");
                    Serial.print("Current Direction:    "); Serial.println(current_direction, DEC);
                    // break out
                    break;
                case '>':
                    // this was a turn right command
                    // save the direction
                    current_direction = input_buffer[1];
                    // print
                    Serial.print("Command Received:     "); Serial.println("['>'] TURN RIGHT");
                    Serial.print("Current Direction:    "); Serial.println(current_direction, DEC);
                    // break out
                    break;
                case '0':
                    // this was a full stop command
                    // save the speed
                    current_speed = input_buffer[1];
                    // print
                    Serial.print("Command Received:     "); Serial.println("['0'] FULL STOP");
                    Serial.print("Current Speed:        "); Serial.println(current_speed, DEC);
                    // break out
                    break;
                case '=':
                    // this was a turn straight command
                    // save the direction
                    current_direction = input_buffer[1];
                    // print
                    Serial.print("Command Received:     "); Serial.println("['='] TURN STRAIGHT");
                    Serial.print("Current Direction:    "); Serial.println(current_direction, DEC);
                    // break out
                    break;
                case 'N':
                    // this was a next track command
                    // print
                    Serial.print("Command Received:     "); Serial.println("['N'] NEXT TRACK");
                    // break out
                    break;
                case 'T':
                    // this was a toggle playback command
                    // print
                    Serial.print("Command Received:     "); Serial.println("['T'] TOGGLE PLAYBACK");
                    // break out
                    break;
                case 'P':
                    // this was a previous track command
                    // print
                    Serial.print("Command Received:     "); Serial.println("['P'] PREVIOUS TRACK");
                    // break out
                    break;
                case 'S':
                    // this was a send settings command
                    // print
                    Serial.print("Command Received:     "); Serial.println("['S'] SET SETTINGS");
                    // determine if the stereo should be enabled
                    enable_stereo  = ((input_buffer[1] & 0x01) == 0x01) 
                                         ? true 
                                         : false;
                    // print
                    Serial.print("Enable Stereo?        "); Serial.println(enable_stereo == true  
                                                                               ? "Yes" : "No");
                    // determine if the turn, brake, and reverse signals should be enabled
                    enable_signals = ((input_buffer[1] & 0x02) == 0x02) 
                                         ? true 
                                         : false;
                    // print
                    Serial.print("Enable Signals?       "); Serial.println(enable_signals == true 
                                                                               ? "Yes" : "No");
                    // determine if the battery status should be enabled
                    enable_battery = ((input_buffer[1] & 0x04) == 0x04) 
                                         ? true 
                                         : false;
                    // print
                    Serial.print("Enable Battery?       "); Serial.println(enable_battery == true 
                                                                               ? "Yes" : "No");
                    // break out
                    break;
                case 'C':
                    // this was a send colors command
                    // print
                    Serial.print("Command Received:     "); Serial.println("['C'] SET SIGNAL COLORS");
                    // save the turn signal color values
                    turn_red       = input_buffer[1];
                    turn_green     = input_buffer[2];
                    turn_blue      = input_buffer[3];
                    // print
                    Serial.print("Turn Signal [R]:      ");
                    if (turn_red < 16) { Serial.print(0, HEX); }
                    Serial.println(turn_red, HEX);
                    // print
                    Serial.print("Turn Signal [G]:      ");
                    if (turn_green < 16) { Serial.print(0, HEX); }
                    Serial.println(turn_green, HEX);
                    // print
                    Serial.print("Turn Signal [B]:      ");
                    if (turn_blue < 16) { Serial.print(0, HEX); }
                    Serial.println(turn_blue, HEX);
                    // save the brake signal color values
                    brake_red      = input_buffer[4];
                    brake_green    = input_buffer[5];
                    brake_blue     = input_buffer[6];
                    // print
                    Serial.print("Brake Signal [R]:     ");
                    if (brake_red < 16) { Serial.print(0, HEX); }
                    Serial.println(brake_red, HEX);
                    // print
                    Serial.print("Brake Signal [G]:     ");
                    if (brake_green < 16) { Serial.print(0, HEX); }
                    Serial.println(brake_green, HEX);
                    // print
                    Serial.print("Brake Signal [B]:     ");
                    if (brake_blue < 16) { Serial.print(0, HEX); }
                    Serial.println(brake_blue, HEX);
                    // save the reverse signal color values
                    reverse_red    = input_buffer[7];
                    reverse_green  = input_buffer[8];
                    reverse_blue   = input_buffer[9];
                    // print
                    Serial.print("Reverse Signal [R]:   ");
                    if (reverse_red < 16) { Serial.print(0, HEX); }
                    Serial.println(reverse_red, HEX);
                    // print
                    Serial.print("Reverse Signal [G]:   ");
                    if (reverse_green < 16) { Serial.print(0, HEX); }
                    Serial.println(reverse_green, HEX);
                    // print
                    Serial.print("Reverse Signal [B]:   ");
                    if (reverse_blue < 16) { Serial.print(0, HEX); }
                    Serial.println(reverse_blue, HEX);
                    // break out
                    break;
                case 'I':
                    // this was a send intervals command
                    Serial.print("Command Received:     "); Serial.println("['I'] SET INTERVALS");
                    // break out
                    break;
                case 'B':
                    // this was a request battery level command
                    // print
                    Serial.print("Command Received:     "); Serial.println("['B'] REQUEST BATTERY LEVEL");
                    // break out
                    break;
                case 'L':
                    // this was a request signal level command
                    // print
                    Serial.print("Command Received:     "); Serial.println("['L'] REQUEST SIGNAL LEVEL");
                    Serial.print("Current Net State:    "); Serial.println(net_state, HEX);
                    // determine if the scanner is idle
                    if (net_state != NET_WAIT_FOR_SCAN && net_state != NET_PRINT_AP_INFO)
                    {
                        // the scanner is idle
                        Serial.println("Net state set to 'WAIT_FOR_SCAN'");
                        // save the net state
                        net_state = NET_WAIT_FOR_SCAN;
                    }
                    // break out
                    break;                
            }
            // save the state
            udp_state = UDP_READ;
            // update the connection timeout
            connection_start_time = (unsigned int)(millis());
            // break out
            break;
        case UDP_CLOSE:
            // close the client
            udp_client.close();
            // print
            Serial.println("UdpClient successfully closed!");
            // save the state
            udp_state = UDP_IS_LISTENING;
            // break out
            break;
        case UDP_EXIT:
            // there was a fatal error
            // close the client
            udp_client.close();
            // close the server
            udp_server.close();
            // print
            Serial.println("The program encountered a fatal error, ending sketch.");
            // save the state
            udp_state = UDP_DONE;
            // break out
            break;
        case UDP_DONE:
        default:
            // break out
            break;
    }
}

void loop()
{        
    // run the scan state machine
    scanStateMachine();
    // run the udp state machine
    udpStateMachine();
    // run the periodic tasks
    DNETcK::periodicTasks();
}

uint32_t updateControls(uint32_t current)
{
    // the duration
    uint32_t duration = 0;      // 125 nanoseconds per tick < at 80MHz >
                                // 8M ticks per second
                                // 8K ticks per millisecond
                                // 8  ticks per microsecond
                                
    // return the time until the next interrupt
    return current + duration;
}
