using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WiFiCommunicator
{
    public partial class FormMain : Form
    {
        // speed constants
        const Byte          MaximumSpeed        = 255;
        const Byte          Stop                = 55;
        const Byte          MinimumSpeed        = 0;
        // speed threshold constants
        const Byte          ForwardThreshold    = 56;
        const Byte          ReverseThreshold    = 54;
        // direction constants
        const Byte          MaximumDirection    = 255;
        const Byte          Straight            = 128;
        const Byte          MinimumDirection    = 0;
        // direction threshold constants
        const Byte          LeftThreshold       = 127;
        const Byte          RightThreshold      = 129;
        // the current speed
        private Byte        CurrentSpeed        = Stop;
        // the current direction
        private Byte        CurrentDirection    = Straight;
        // the current battery value
        private Byte        CurrentBattery      = 0x00;
        // the current signal value
        private Byte        CurrentSignal       = 0x00;
        // the intervals
        private Byte        IncreaseInterval    = 25;
        private Byte        DecreaseInterval    = 10;
        private Byte        LeftInterval        = 32;
        private Byte        RightInterval       = 32;
        // the raw accelerometer values
        private Int16       X_Acceleration      = 0x0000;
        private Int16       Y_Acceleration      = 0x0000;
        private Int16       Z_Acceleration      = 0x0000;
        // the estimated raw velocity values
        private Int16       X_Velocity          = 0x0000;
        private Int16       Y_Velocity          = 0x0000;
        private Int16       Z_Velocity          = 0x0000;
        // the estimated raw position values
        private Int32       X_Position          = 0x0000;
        private Int32       Y_Position          = 0x0000;
        private Int32       Z_Position          = 0x0000;
        // the status stopwatch
        private Stopwatch   StatusStopwatch     = null;
        // the target ip address
        private IPAddress   TargetAddress       = IPAddress.Parse("192.168.1.200");
        // the target port
        private Int16       TargetPort          = 0x0000;
        // the udp interface
        private UdpClient   UdpClient              = null;
        
        public FormMain()
        {
            // required for designer support
            InitializeComponent();
        }

        private void numericIncreaseInterval_ValueChanged
            (object sender, EventArgs e)
        {
            // save the new interval
            IncreaseInterval            = Convert.ToByte(numericIncreaseInterval.Value);
            // change the "increase speed" button text
            buttonIncreaseSpeed.Text    = String.Format("INCREASE\nSPEED\n(+{0})", 
                                                        IncreaseInterval);
        }

        private void numericDecreaseInterval_ValueChanged
            (object sender, EventArgs e)
        {
            // save the new interval
            DecreaseInterval            = Convert.ToByte(numericDecreaseInterval.Value);
            // change the "decrease speed" button text
            buttonDecreaseSpeed.Text    = String.Format("DECREASE\nSPEED\n(-{0})", 
                                                        Convert.ToInt32(numericDecreaseInterval.Value));
        }

        private void numericLeftInterval_ValueChanged
            (object sender, EventArgs e)
        {
            // save the new interval
            LeftInterval                = Convert.ToByte(numericLeftInterval.Value);
            // change the "turn left" button text
            buttonTurnLeft.Text         = String.Format("TURN\nLEFT\n(-{0})", 
                                                        Convert.ToInt32(numericLeftInterval.Value));
        }

        private void numericRightInterval_ValueChanged
            (object sender, EventArgs e)
        {
            // save the new interval
            RightInterval               = Convert.ToByte(numericRightInterval.Value);
            // change the "turn right" button text
            buttonTurnRight.Text        = String.Format("TURN\nRIGHT\n(+{0})", 
                                                        Convert.ToInt32(numericRightInterval.Value));
        }

        private void textTargetIP_TextChanged
            (object sender, EventArgs e)
        {
            // the parsed ip address
            IPAddress address = IPAddress.None;
            // determine if there is anything in the target ip textbox
            if (String.IsNullOrWhiteSpace(textTargetIP.Text))
            {
                // there is nothing in the textbox
                // set the colors of the textbox
                textTargetIP.BackColor = Color.White;
                textTargetIP.ForeColor = Color.Black;
            }
            else
            {
                // try to parse the address
                if (IPAddress.TryParse(textTargetIP.Text, out address))
                {
                    // the address is valid
                    // save the address
                    TargetAddress           = address;
                    // set the colors of the textbox
                    textTargetIP.BackColor  = Color.FromArgb(192, 255, 192);
                    textTargetIP.ForeColor  = Color.Black;
                }
                else
                {
                    // the address is invalid
                    // set the colors of the textbox
                    textTargetIP.BackColor  = Color.FromArgb(255, 192, 192);
                    textTargetIP.ForeColor  = Color.Black;
                }
            }
        }

        private void FormMain_Load
            (object sender, EventArgs e)
        {
            // save the default address
            TargetAddress   = IPAddress.Parse(textTargetIP.Text);
            // save the default port
            TargetPort      = Convert.ToInt16(numericTargetPort.Value);
        }

        private void ReportEvent(String message)
        {
            // create a listviewitem
            ListViewItem event_item = new ListViewItem();
            // set the time
            event_item.Text         = DateTime.Now.ToString("HH:mm:ss.fff");
            // set the event text
            event_item.SubItems.Add(message);
            // save the item
            listLog.Items.Add(event_item);
            // ensure that the event item is visible
            event_item.EnsureVisible();
        }
        private void SendDatagram(IDatagram datagram)
        {
            // determine if the worker is busy
            if (workerTransmitter.IsBusy == false)
            {
                // the background worker is not busy
                // determine if the client exists
                if (UdpClient == null)
                {
                    // the client does not exist
                    UdpClient = new UdpClient();
                    // set the properties of the client
                    UdpClient.DontFragment         = true;
                    UdpClient.ExclusiveAddressUse  = false;
                }
                // determine if the client is connected
                if (UdpClient.Client == null)
                {
                    // the client is not connected
                    // connect
                    UdpClient.Connect(TargetAddress, TargetPort);
                }
                // update the current speed
                trackSpeed.Value        = CurrentSpeed;
                // update the current direction
                trackDirection.Value    = CurrentDirection;
                // send the datagram
                workerTransmitter.RunWorkerAsync(new IDatagram[] { datagram });
            }
            else
            {
                // the background worker is busy
                // warn the user
                MessageBox.Show("The transmitter worker thread is currently busy, please wait until the current transmission has been sent.",
                                "WiFi R/C Car Communicator",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void SendDatagrams(IDatagram[] datagrams)
        {
            // determine if the worker is busy
            if (workerTransmitter.IsBusy == false)
            {
                // the background worker is not busy
                // determine if the client exists
                if (UdpClient == null)
                {
                    // the client does not exist
                    UdpClient = new UdpClient();
                    // set the properties of the client
                    UdpClient.DontFragment         = true;
                    UdpClient.ExclusiveAddressUse  = false;
                }
                //// determine if the client is connected
                //if ((UdpClient.Client == null) || 
                //    (UdpClient.Client != null && UdpClient.Client.Connected == false))
                //{
                //    // the client is not connected
                //    // connect
                //    UdpClient.Connect(TargetAddress, TargetPort);
                //}
                // send the datagrams
                workerTransmitter.RunWorkerAsync(datagrams);
            }
            else
            {
                // the background worker is busy
                // warn the user
                MessageBox.Show("The transmitter worker thread is currently busy, please wait until the current transmission has been sent.",
                                "WiFi R/C Car Communicator",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void buttonNextTrack_Click
            (object sender, EventArgs e)
        {
            // create a stereo datagram
            StereoDatagram datagram = new StereoDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action of the datagram
                datagram.SetAction(StereoCode.NextTrack);
                // report the event
                ReportEvent("Playing next track.");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private void buttonTogglePlayback_Click
            (object sender, EventArgs e)
        {
            // create a stereo datagram
            StereoDatagram datagram = new StereoDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action of the datagram
                datagram.SetAction(StereoCode.TogglePlayback);
                // report the event
                ReportEvent("Playback toggled.");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private void buttonPreviousTrack_Click
            (object sender, EventArgs e)
        {
            // create a stereo datagram
            StereoDatagram datagram = new StereoDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action of the datagram
                datagram.SetAction(StereoCode.PreviousTrack);
                // report the event
                ReportEvent("Playing previous track.");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private void buttonFullForward_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.IncreaseSpeed, FullForward());
                // report the event
                ReportEvent("Setting speed to full forward (255).");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte FullForward
            ()
        {
            // the result
            Byte result         = MaximumSpeed;
            // save the current speed
            CurrentSpeed        = result;
            // return the result
            return result;
        }

        private void buttonIncreaseSpeed_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.IncreaseSpeed, IncreaseSpeed());
                // report the event
                ReportEvent(String.Format("Increasing speed to {0}.", CurrentSpeed));
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte IncreaseSpeed
            ()
        {
            // the result
            Byte result         = Convert.ToByte(Math.Min(CurrentSpeed + IncreaseInterval, 
                                                          Byte.MaxValue));
            // save the current speed
            CurrentSpeed        = result;
            // return the current speed
            return result;
        }

        private void buttonFullReverse_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.DecreaseSpeed, FullReverse());
                // report the event
                ReportEvent("Setting speed to full reverse (0).");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte FullReverse
            ()
        {
            // the result
            Byte result         = MinimumSpeed;
            // save the current speed
            CurrentSpeed        = result;
            // return the result
            return result;
        }

        private void buttonDecreaseSpeed_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.DecreaseSpeed, DecreaseSpeed());
                // report the event
                ReportEvent(String.Format("Decreasing speed to {0}.", CurrentSpeed));
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte DecreaseSpeed
            ()
        {
            // the result
            Byte result         = Convert.ToByte(Math.Max(CurrentSpeed - DecreaseInterval,
                                                          Byte.MinValue));
            // save the current speed
            CurrentSpeed        = result;
            // return the result
            return result;
        }

        private void buttonFullLeft_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.TurnLeft, FullLeft());
                // report the event
                ReportEvent("Setting heading to full left (0).");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte FullLeft
            ()
        {
            // the result
            Byte result         = MinimumDirection;
            // save the current direction
            CurrentDirection    = result;
            // return the result
            return result;
        }

        private void buttonTurnLeft_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.TurnLeft, TurnLeft());
                // report the event
                ReportEvent(String.Format("Adjusting heading left to {0}.", CurrentDirection));
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte TurnLeft
            ()
        {
            // the result
            Byte result         = Convert.ToByte(Math.Max(CurrentDirection - LeftInterval,
                                                          Byte.MinValue));
            // save the current direction
            CurrentDirection    = result;
            // return the result
            return result;
        }

        private void buttonFullRight_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.TurnRight, FullRight());
                // report the event
                ReportEvent("Setting heading to full right (255).");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte FullRight
            ()
        {
            // the result
            Byte result         = MaximumDirection;
            // save the current direction
            CurrentDirection = result;
            // return the result
            return result;
        }

        private void buttonTurnRight_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.TurnRight, TurnRight());
                // report the event
                ReportEvent(String.Format("Adjusting heading right to {0}.", CurrentDirection));
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte TurnRight
            ()
        {
            // the result
            Byte result         = Convert.ToByte(Math.Min(CurrentDirection + RightInterval,
                                                          Byte.MaxValue));
            // save the current direction
            CurrentDirection    = result;
            // return the result
            return result;
        }

        private void buttonStop_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.Stop, FullStop());
                // report the event
                ReportEvent("Stopping vehicle (55).");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte FullStop
            ()
        {
            // the result
            Byte result         = Stop;
            // save the current speed
            CurrentSpeed        = result;
            // return the result
            return result;
        }

        private void buttonStraight_Click
            (object sender, EventArgs e)
        {
            // create a motion datagram
            MotionDatagram datagram = new MotionDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(MotionCode.Straight, FullStraight());
                // report the event
                ReportEvent("Adjusting heading to straight ahead (128).");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private Byte FullStraight
            ()
        {
            // the result
            Byte result         = Straight;
            // save the current direction
            CurrentDirection    = result;
            // return the result
            return result;
        }

        private void buttonBattery_Click
            (object sender, EventArgs e)
        {
            // create a request datagram
            RequestDatagram datagram = new RequestDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(RequestCode.RequestBattery);
                // report the event
                ReportEvent("Requesting battery status.");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private void buttonSignal_Click
            (object sender, EventArgs e)
        {
            // create a request datagram
            RequestDatagram datagram = new RequestDatagram();
            // determine if the worker is available
            if (workerTransmitter.IsBusy == false)
            {
                // set the action
                datagram.SetAction(RequestCode.RequestSignal);
                // report the event
                ReportEvent("Requesting signal status.");
                // send the datagram
                SendDatagram(datagram);
            }
        }

        private void labelBattery_TextChanged
            (object sender, EventArgs e)
        {
            // the adjusted text of the label
            String  value_text          = labelBattery.Text.Replace("%", String.Empty);
            // the actual value
            Double  actual_value        = Double.Parse(value_text);
            // the adjusted value
            Byte    adjusted_value      = Convert.ToByte(Math.Min((actual_value / 100.00) * 255.00, 255));
            // set the progressbar value
            progressBattery.Value       = adjusted_value;
            // set the label's color
            SetPercentageColor(adjusted_value, ref labelBattery);
        }
        private void labelSignal_TextChanged
            (object sender, EventArgs e)
        {
            // the adjusted text of the label
            String  value_text          = labelBattery.Text.Replace("%", String.Empty);
            // the actual value
            Double  actual_value        = Double.Parse(value_text);
            // the adjusted value
            Byte    adjusted_value      = Convert.ToByte(Math.Min((actual_value / 100.00) * 255.00, 255));
            // set the progressbar value
            progressSignal.Value        = adjusted_value;
            // set the label's color
            SetPercentageColor(adjusted_value, ref labelSignal);
        }
        private void SetSpeedColor
            (Byte value)
        {
            // determine the value
            if (value <= MaximumSpeed && 
                value >= ForwardThreshold)
            {
                // the vehicle is moving forward
                // set the color
                labelSpeedStatus.ForeColor          = Color.DodgerBlue;
            }
            else
            if (value == Stop)
            {
                // the vehicle is stopped
                labelSpeedStatus.ForeColor          = Color.Black;
            }
            else
            if (value <= ReverseThreshold &&
                value >= MinimumSpeed)
            {
                // the vehicle is moving backward
                labelSpeedStatus.ForeColor          = Color.Green;
            }
        }
        private void SetDirectionColor
            (Byte value)
        {
            // determine the value
            if (value <= MaximumDirection && 
                value >= RightThreshold)
            {
                // the vehicle is turned right
                // set the color
                labelDirectionStatus.ForeColor      = Color.DodgerBlue;
            }
            else
            if (value == Straight)
            {
                // the vehicle is turned straight
                labelDirectionStatus.ForeColor      = Color.Black;
            }
            else
            if (value <= LeftThreshold &&
                value >= MinimumDirection)
            {
                // the vehicle is turned left
                labelDirectionStatus.ForeColor      = Color.Green;
            }
        }
        private void SetPercentageColor
            (Byte value, ref Label label)
        {
            // the threshold values
            const Byte Maximum          = 250;
            const Byte HighThreshold    = 200;
            const Byte MediumThreshold  = 100;
            const Byte LowThreshold     = 50;
            // determine the value
            if (value <= Byte.MaxValue &&
                value >= Maximum)
            {
                // set the color of the label
                label.ForeColor = Color.LimeGreen;
            }
            else
            if (value < Maximum &&
                value >= HighThreshold)
            {
                // set the color of the label
                label.ForeColor = Color.DarkGreen;
            }
            else
            if (value < HighThreshold &&
                value >= MediumThreshold)
            {
                // set the color of the label
                label.ForeColor = Color.DarkGoldenrod;
            }
            else
            if (value < MediumThreshold &&
                value >= LowThreshold)
            {
                // set the color of the label
                label.ForeColor = Color.DarkRed;
            }
            else
            if (value < LowThreshold &&
                value >= Byte.MinValue)
            {
                // set the color of the label
                label.ForeColor = Color.Red;
            }
        }

        private void trackSpeed_ValueChanged
            (object sender, EventArgs e)
        {
            // set the current speed text
            labelSpeedStatus.Text      = GetSpeedStatus();
            // set the speed color
            SetSpeedColor(Convert.ToByte(trackSpeed.Value));
        }

        private void trackDirection_ValueChanged
            (object sender, EventArgs e)
        {
            // set the current direction text
            labelDirectionStatus.Text  = GetDirectionStatus();
            // set the direction color
            SetDirectionColor(Convert.ToByte(trackDirection.Value));
        }

        private String GetSpeedStatus()
        {
            // the result
            String  result      = "{0} :: {1} / 255";
            // the speed
            Int32   speed       = trackSpeed.Value;
            // determine the speed
            if (speed > Stop)
            {
                // the vehicle is moving forward
                // format the status
                result = String.Format(result, "Forward", speed);
            }
            else
            if (speed < Stop)
            {
                // the vehicle is moving backward
                // format the status
                result = String.Format(result, "Reverse", speed);
            }
            else
            if (speed == Stop)
            {
                // the vehicle is stopped
                // format the status
                result = String.Format(result, "Stopped", speed);
            }
            // return the result
            return result;
        }
        private String GetDirectionStatus()
        {
            // the result
            String  result      = "{0} :: {1} / 255";
            // the direction
            Int32   direction   = trackDirection.Value;
            // determine the direction
            if (direction > Straight)
            {
                // the vehicle is turned right
                // format the status
                result = String.Format(result, "Right", direction);
            }
            else
            if (direction < Straight)
            {
                // the vehicle is turned left
                // format the status
                result = String.Format(result, "Left", direction);
            }
            else
            if (direction == Straight)
            {
                // the vehicle is turned straight
                // format the status
                result = String.Format(result, "Straight", direction);
            }
            // return the result
            return result;
        }

        private void workerTransmitter_DoWork(object sender, DoWorkEventArgs e)
        {
            // get the datagram
            IDatagram[] datagrams           = e.Argument as IDatagram[];
            // get the contents of the datagram
            Byte[]      contents            = null;
            // the ipendpoint
            IPEndPoint  endpoint            = new IPEndPoint(TargetAddress, TargetPort);
            // iterate through the datagrams
            foreach (IDatagram datagram in datagrams)
            {
                // get the contents of this datagram
                contents = datagram.ToArray();
                // send the contents of the array
                UdpClient.Send(contents, contents.Length, endpoint);
                // sleep
                System.Threading.Thread.Sleep(100);
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            // determine if the stopwatch exists
            if (StatusStopwatch != null)
            {
                // the stopwatch exists
                // determine if the status message is old
                if (StatusStopwatch.ElapsedMilliseconds > 5000)
                {
                    // it is
                    // clear the status message
                    labelStatus.Text    = String.Empty;
                    // reset the progressbar style
                    progressBar.Style   = ProgressBarStyle.Continuous;
                    // reset the progressbar value
                    progressBar.Value   = 0;
                }
            }
        }

        private void textTargetIP_DoubleClick(object sender, EventArgs e)
        {
            // create the address
            IPAddress address = null;
            // determine if the address is valid
            if (IPAddress.TryParse(textTargetIP.Text, out address))
            {
                // the address is valid
                // report the event
                ReportEvent("Pinging target IP address.");
                // run the ping worker
                workerPing.RunWorkerAsync(address);
            }
            else
            {
                // the address is invalid
                // do nothing
            }
        }

        private void workerPing_DoWork(object sender, DoWorkEventArgs e)
        {
            // get the ipaddress
            IPAddress   address = e.Argument as IPAddress;
            // create a ping class
            Ping        ping    = new Ping();
            // the pingreply
            PingReply   reply   = null;
            // attempt to ping the target address
            reply               = ping.Send(address);
            // report the event
            workerPing.ReportProgress(0, String.Format("Pinging '{0}'...", address.ToString()));
            // save the result
            e.Result = reply;
        }

        private void workerPing_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // update the status
            labelStatus.Text    = e.UserState as String;
            // update the progressbar
            progressBar.Style   = ProgressBarStyle.Marquee;
        }

        private void workerPing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // get the ping reply
            PingReply reply = e.Result as PingReply;
            // determine the status
            switch (reply.Status)
            {
                case IPStatus.Success:
                    // the ping was successful
                    // update the status label
                    labelStatus.Text = "Ping successful!";
                    // break out
                    break;
                default:
                    // the ping was unsuccessful
                    // update the status label
                    labelStatus.Text = "ERROR: '" + Enum.GetName(typeof(IPStatus), reply.Status) + "'";
                    // break out
                    break;
            }
            // stop the progressbar
            progressBar.Style = ProgressBarStyle.Continuous;
        }

        private void labelStatus_TextChanged(object sender, EventArgs e)
        {
            // create a new stopwatch
            StatusStopwatch = new Stopwatch();
            // start the stopwatch
            StatusStopwatch.Start();
        }

        private void Kinematic_TextChanged(object sender, EventArgs e)
        {
            // get the label
            Label   label   = sender as Label;
            // get the value
            Double  value   = 0.00;
            // determine if the contents of the label is a valid double
            if (Double.TryParse(label.Text, out value))
            {
                // the text is valid
                // determine the value
                if (value == 0.00)
                {
                    // the value is zero
                    // set the colors of the label
                    label.ForeColor = Color.Black;
                }
                else
                if (value > 0.000)
                {
                    // the value is positive

                    label.ForeColor = Color.DarkGreen;
                }
                else
                if (value < 0.000)
                {
                    // the value is negative
                    // set the colors of the label
                    label.ForeColor = Color.DarkRed;
                }
            }
        }

        private void panelReverseSignal_DoubleClick(object sender, EventArgs e)
        {
            // create a color dialog
            using (ColorDialog dialog = new ColorDialog())
            {
                // set the properties of the dialog
                dialog.Color = panelReverseSignal.BackColor;
                // show the dialog
                switch (dialog.ShowDialog())
                {
                    case DialogResult.OK:
                        // the user chose a color
                        // save the color
                        panelReverseSignal.BackColor    = dialog.Color;
                        // save the color code
                        labelReverseSignal.Text         = GetHexColor(dialog.Color);
                        // break out
                        break;
                    default:
                        // the user did not choose a color
                        // break out
                        break;
                }
            }
        }

        private void panelBrakeSignal_DoubleClick(object sender, EventArgs e)
        {
            // create a color dialog
            using (ColorDialog dialog = new ColorDialog())
            {
                // set the properties of the dialog
                dialog.Color = panelBrakeSignal.BackColor;
                // show the dialog
                switch (dialog.ShowDialog())
                {
                    case DialogResult.OK:
                        // the user chose a color
                        // save the color
                        panelBrakeSignal.BackColor      = dialog.Color;
                        // save the color code
                        labelBrakeSignal.Text           = GetHexColor(dialog.Color);
                        // break out
                        break;
                    default:
                        // the user did not choose a color
                        // break out
                        break;
                }
            }
        }

        private void panelTurnSignal_DoubleClick(object sender, EventArgs e)
        {
            // create a color dialog
            using (ColorDialog dialog = new ColorDialog())
            {
                // set the properties of the dialog
                dialog.Color = panelTurnSignal.BackColor;
                // show the dialog
                switch (dialog.ShowDialog())
                {
                    case DialogResult.OK:
                        // the user chose a color
                        // save the color
                        panelTurnSignal.BackColor       = dialog.Color;
                        // save the color code
                        labelTurnSignal.Text            = GetHexColor(dialog.Color);
                        // break out
                        break;
                    default:
                        // the user did not choose a color
                        // break out
                        break;
                }
            }
        }
        private String GetHexColor(Color color)
        {
            // the result
            String result = String.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
            // return the result
            return result;
        }

        private void textOutputPath_TextChanged(object sender, EventArgs e)
        {
            // determine if there is anything in the textbox
            if (String.IsNullOrWhiteSpace(textOutputPath.Text))
            {
                // there is nothing in the textbox
                // set the colors of the textbox
                textOutputPath.ForeColor = Color.Black;
                textOutputPath.BackColor = Color.White;
            }
            else
            {
                // there is something in the textbox
                // determine if this is a valid directory
                if (Directory.Exists(textOutputPath.Text))
                {
                    // the path is valid
                    // set the colors of the textbox
                    textOutputPath.ForeColor = Color.Black;
                    textOutputPath.BackColor = Color.FromArgb(192, 255, 192);
                }
                else
                {
                    // the path is invalid
                    // set the colors of the textbox
                    textOutputPath.ForeColor = Color.Black;
                    textOutputPath.BackColor = Color.FromArgb(255, 192, 192);
                }
            }
        }

        private void linkSelect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // create a folderbrowserdialog
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                // set the properties of the dialog
                dialog.Description          = "Select Output Path...";
                dialog.ShowNewFolderButton  = true;
                // show the dialog
                switch (dialog.ShowDialog())
                {
                    case DialogResult.OK:
                        // the user selected a directory
                        // save the path
                        textOutputPath.Text = dialog.SelectedPath;
                        // break out
                        break;
                    default:
                        // the user did not select a directory
                        // break out
                        break;
                }
            }
        }

        private void checkEnableStereo_CheckedChanged(object sender, EventArgs e)
        {
            // change the state of the stereo controls
            buttonNextTrack.Enabled             = checkEnableStereo.Checked;
            buttonTogglePlayback.Enabled        = checkEnableStereo.Checked;
            buttonPreviousTrack.Enabled         = checkEnableStereo.Checked;
        }

        private void checkEnableSignals_CheckedChanged(object sender, EventArgs e)
        {
            // change the state of the signal colors
            groupSignalColors.Enabled           = checkEnableSignals.Checked;
        }

        private void numericTargetPort_ValueChanged(object sender, EventArgs e)
        {
            // save the target port
            TargetPort  = Convert.ToInt16(numericTargetPort.Value);
        }

        private void buttonSendSettings_Click(object sender, EventArgs e)
        {
            // the datagram list
            List<IDatagram>                 datagrams   = new List<IDatagram>();
            // the settings datagram
            SettingsDatagram                settings    = new SettingsDatagram();
            // the signal colors datagram
            SignalColorsDatagram            colors      = new SignalColorsDatagram();
            // store the settings
            settings.SetSettings(checkEnableStereo.Checked,
                                 checkEnableSignals.Checked,
                                 checkEnableBattery.Checked);
            // add the datagram
            datagrams.Add(settings);
            // determine if the colors should be sent
            if (checkEnableSignals.Checked)
            {
                // store the colors
                colors.SetTurnSignalColor(panelTurnSignal.BackColor);
                colors.SetBrakeSignalColor(panelBrakeSignal.BackColor);
                colors.SetReverseSignalColor(panelReverseSignal.BackColor);
                // add the datagram
                datagrams.Add(colors);
            }
            // report the event
            ReportEvent("Sending program settings.");
            // send the datagrams
            SendDatagrams(datagrams.ToArray());
        }

        private void checkEnableBattery_CheckedChanged(object sender, EventArgs e)
        {
            // enable the battery controls
            labelBattery.Enabled    = checkEnableBattery.Checked;
            progressBattery.Enabled = checkEnableBattery.Checked;
            buttonBattery.Enabled   = checkEnableBattery.Checked;
        }

        private void timerReceiver_Tick(object sender, EventArgs e)
        {

        }
    }
}
