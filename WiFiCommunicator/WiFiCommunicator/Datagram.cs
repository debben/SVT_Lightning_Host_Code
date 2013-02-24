using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WiFiCommunicator
{
    interface IDatagram
    {
        Byte[] ToArray();
    }
    
    class MotionDatagram : IDatagram
    {
        // the datagram transmit code
        public MotionCode   Code                = MotionCode.None;
        // the datagram value
        public Byte         Value               = 0x00;

        public void SetAction
            (MotionCode action, Byte value)
        {
            // save the action
            Code    = action;
            // save the value
            Value   = value;
        }

        public Byte[] ToArray
            ()
        {
            // the result
            Byte[] result = new Byte[] { 
                                         Convert.ToByte(Code), 
                                         Value 
                                       };
            // return the result
            return result;
        }
    }

    class StereoDatagram : IDatagram
    {
        // the datagram transmit code
        public StereoCode   Code                = StereoCode.None;

        public void SetAction
            (StereoCode action)
        {
            // save the action
            Code    = action;
        }

        public Byte[] ToArray
            ()
        {
            // the result
            Byte[] result = new Byte[] { 
                                         Convert.ToByte(Code) 
                                       };
            // return the result
            return result;
        }
    }

    class SettingsDatagram : IDatagram
    {
        // the datagram transmit code
        public SettingsCode Code                = SettingsCode.SendSettings;
        // the settings flags
        public SettingFlag  Flags               = SettingFlag.None;

        public void SetSettings
            (Boolean enable_stereo, Boolean enable_signals, Boolean enable_battery)
        {
            // reset the flags
            Flags   = SettingFlag.None;
            // save the flags
            Flags  |= (enable_stereo == true) 
                        ? SettingFlag.EnableStereo 
                        : SettingFlag.None;
            Flags  |= (enable_signals == true) 
                        ? SettingFlag.EnableSignals 
                        : SettingFlag.None;
            Flags  |= (enable_battery == true) 
                        ? SettingFlag.EnableBattery
                        : SettingFlag.None;
        }

        public Byte[] ToArray
            ()
        {
            // the result
            Byte[] result = new Byte[] { 
                                         Convert.ToByte(Code), 
                                         Convert.ToByte(Flags) 
                                       };
            // return the result
            return result;
        }
    }

    class IntervalDatagram : IDatagram
    {
        // the datagram transmit code
        public IntervalCode Code                = IntervalCode.SendIntervals;
        // the interval values
        public Byte         AccelerateInterval  = 0x00;
        public Byte         DecelerateInterval  = 0x00;
        public Byte         RightInterval       = 0x00;
        public Byte         LeftInterval        = 0x00;

        public void SetIntervals
            (Decimal accelerate_value, Decimal decelerate_value,
             Decimal left_value, Decimal right_value)
        {
            // set the speed intervals
            SetSpeedIntervals(accelerate_value, decelerate_value);
            // set the direction intervals
            SetDirectionIntervals(left_value, right_value);
        }

        private void SetSpeedIntervals
            (Decimal accelerate_value, Decimal decelerate_value)
        {
            // set the intervals
            AccelerateInterval  = Convert.ToByte(accelerate_value);
            DecelerateInterval  = Convert.ToByte(decelerate_value);

        }
        private void SetDirectionIntervals
            (Decimal left_value, Decimal right_value)
        {
            // set the intervals
            LeftInterval        = Convert.ToByte(left_value);
            RightInterval       = Convert.ToByte(right_value);
        }

        public Byte[] ToArray
            ()
        {
            // the result
            Byte[] result = new Byte[] {    
                                         Convert.ToByte(Code), 
                                         AccelerateInterval, 
                                         DecelerateInterval,
                                         LeftInterval, 
                                         RightInterval 
                                       };
            // return the result
            return result;
        }
    }

    class RequestDatagram : IDatagram
    {
        // the datagram transmit code
        public RequestCode  Code                = RequestCode.None;

        public void SetAction
            (RequestCode action)
        {
            // save the action
            Code    = action;
        }

        public Byte[] ToArray
            ()
        {
            // the result
            Byte[] result = new Byte[] { Convert.ToByte(Code) };
            // return the result
            return result;
        }
    }

    class SignalColorsDatagram : IDatagram
    {
        // the color constants
        public const Byte   Red                 = 0;
        public const Byte   Green               = 1;
        public const Byte   Blue                = 2;
        // the datagram transmit code
        public SettingsCode Code                = SettingsCode.SendColors;
        // the turn signal color
        public Byte[]       TurnColor           = new Byte[3];
        // the brake signal color
        public Byte[]       BrakeColor          = new Byte[3];
        // the reverse signal color
        public Byte[]       ReverseColor        = new Byte[3];

        public void SetTurnSignalColor
            (Color color)
        {
            // save the color values
            TurnColor[Red]          = color.R;
            TurnColor[Green]        = color.G;
            TurnColor[Blue]         = color.B;
        }

        public void SetBrakeSignalColor
            (Color color)
        {
            // save the color values
            BrakeColor[Red]         = color.R;
            BrakeColor[Green]       = color.G;
            BrakeColor[Blue]        = color.B;
        }

        public void SetReverseSignalColor
            (Color color)
        {
            // save the color values
            ReverseColor[Red]       = color.R;
            ReverseColor[Green]     = color.G;
            ReverseColor[Blue]      = color.B;
        }

        public Byte[] ToArray()
        {
            // the result
            Byte[] result = new Byte[] { 
                                         Convert.ToByte(Code),
                                         TurnColor[Red], TurnColor[Green], TurnColor[Blue],
                                         BrakeColor[Red], BrakeColor[Green], BrakeColor[Blue],
                                         ReverseColor[Red], ReverseColor[Green], ReverseColor[Blue]
                                       };
            // return the result
            return result;
        }
    }

    [FlagsAttribute]
    public enum SettingFlag
    {
        None                = 0x00,             // 0x00  0000
        EnableStereo        = 0x01,             // 0x01  0001
        EnableSignals       = 0x02,             // 0x02  0002
        EnableBattery       = 0x04              // 0x04  0004
    }
    public enum MotionCode
    {
        None                = 0x00,         
        IncreaseSpeed       = '+',              // 0x2B  0043
        DecreaseSpeed       = '-',              // 0x2D  0045
        TurnLeft            = '<',              // 0x3C  0060
        TurnRight           = '>',              // 0x3E  0062
        Stop                = '0',              // 0x30  0048
        Straight            = '='               // 0x3D  0061
    }
    public enum StereoCode
    {
        None                = 0x00,         
        NextTrack           = 'N',              // 0x4E  0078
        TogglePlayback      = 'T',              // 0x54  0084
        PreviousTrack       = 'P'               // 0x50  0080
    }
    public enum SettingsCode
    {
        None                = 0x00,         
        SendSettings        = 'S',              // 0x53  0083
        SendRates           = 'R',              // 0x52  0082
        SendColors          = 'C'               // 0x43  0067
    }
    public enum IntervalCode
    {
        None                = 0x00,  
        SendIntervals       = 'I'               // 0x49  0073
    }
    public enum RequestCode
    {
        None                = 0x00,         
        RequestBattery      = 'B',              // 0x42  0066
        RequestSignal       = 'L'               // 0x4C  0076
    }
    public enum ReceiveCode
    {
        None                = 0x00,
        Battery             = 'b',              // 0x62  0098
        Signal              = 'l'               // 0x6C  0108
    }
}
