namespace WiFiCommunicator
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupTargetIP = new System.Windows.Forms.GroupBox();
            this.textTargetIP = new System.Windows.Forms.TextBox();
            this.groupTargetPort = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericTargetPort = new System.Windows.Forms.NumericUpDown();
            this.groupVehicleSpeed = new System.Windows.Forms.GroupBox();
            this.labelMaximumSpeed = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelMinimumSpeed = new System.Windows.Forms.Label();
            this.trackSpeed = new System.Windows.Forms.TrackBar();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.labelSpeedStatus = new System.Windows.Forms.Label();
            this.groupVehicleDirection = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelMaximumRight = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelMaximumLeft = new System.Windows.Forms.Label();
            this.trackDirection = new System.Windows.Forms.TrackBar();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.labelDirectionStatus = new System.Windows.Forms.Label();
            this.buttonIncreaseSpeed = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonDecreaseSpeed = new System.Windows.Forms.Button();
            this.buttonTurnLeft = new System.Windows.Forms.Button();
            this.buttonTurnRight = new System.Windows.Forms.Button();
            this.buttonNextTrack = new System.Windows.Forms.Button();
            this.buttonTogglePlayback = new System.Windows.Forms.Button();
            this.buttonPreviousTrack = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.checkEnableBattery = new System.Windows.Forms.CheckBox();
            this.checkEnableSignals = new System.Windows.Forms.CheckBox();
            this.checkEnableStereo = new System.Windows.Forms.CheckBox();
            this.groupIntervals = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.numericRightInterval = new System.Windows.Forms.NumericUpDown();
            this.numericLeftInterval = new System.Windows.Forms.NumericUpDown();
            this.numericDecreaseInterval = new System.Windows.Forms.NumericUpDown();
            this.numericIncreaseInterval = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.workerTransmitter = new System.ComponentModel.BackgroundWorker();
            this.workerReceiver = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.labelBattery = new System.Windows.Forms.Label();
            this.labelSignal = new System.Windows.Forms.Label();
            this.buttonFullLeft = new System.Windows.Forms.Button();
            this.buttonFullRight = new System.Windows.Forms.Button();
            this.buttonFullForward = new System.Windows.Forms.Button();
            this.buttonFullReverse = new System.Windows.Forms.Button();
            this.buttonStraight = new System.Windows.Forms.Button();
            this.timerReceiver = new System.Windows.Forms.Timer(this.components);
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.workerPing = new System.ComponentModel.BackgroundWorker();
            this.groupSignalColors = new System.Windows.Forms.GroupBox();
            this.labelReverseSignal = new System.Windows.Forms.Label();
            this.labelBrakeSignal = new System.Windows.Forms.Label();
            this.labelTurnSignal = new System.Windows.Forms.Label();
            this.panelReverseSignal = new System.Windows.Forms.Panel();
            this.panelBrakeSignal = new System.Windows.Forms.Panel();
            this.panelTurnSignal = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.listLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupOutputPath = new System.Windows.Forms.GroupBox();
            this.linkSelect = new System.Windows.Forms.LinkLabel();
            this.textOutputPath = new System.Windows.Forms.TextBox();
            this.progressBattery = new System.Windows.Forms.ProgressBar();
            this.progressSignal = new System.Windows.Forms.ProgressBar();
            this.buttonSignal = new System.Windows.Forms.Button();
            this.buttonBattery = new System.Windows.Forms.Button();
            this.buttonSendSettings = new System.Windows.Forms.Button();
            this.groupTargetIP.SuspendLayout();
            this.groupTargetPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetPort)).BeginInit();
            this.groupVehicleSpeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).BeginInit();
            this.groupVehicleDirection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDirection)).BeginInit();
            this.groupOptions.SuspendLayout();
            this.groupIntervals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRightInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeftInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDecreaseInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncreaseInterval)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.groupSignalColors.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupOutputPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTargetIP
            // 
            this.groupTargetIP.Controls.Add(this.textTargetIP);
            this.groupTargetIP.Location = new System.Drawing.Point(12, 12);
            this.groupTargetIP.Name = "groupTargetIP";
            this.groupTargetIP.Size = new System.Drawing.Size(161, 45);
            this.groupTargetIP.TabIndex = 0;
            this.groupTargetIP.TabStop = false;
            this.groupTargetIP.Text = "Target IP Address";
            // 
            // textTargetIP
            // 
            this.textTargetIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textTargetIP.Location = new System.Drawing.Point(6, 19);
            this.textTargetIP.Name = "textTargetIP";
            this.textTargetIP.Size = new System.Drawing.Size(149, 20);
            this.textTargetIP.TabIndex = 0;
            this.textTargetIP.Text = "192.168.1.200";
            this.textTargetIP.TextChanged += new System.EventHandler(this.textTargetIP_TextChanged);
            this.textTargetIP.DoubleClick += new System.EventHandler(this.textTargetIP_DoubleClick);
            // 
            // groupTargetPort
            // 
            this.groupTargetPort.Controls.Add(this.label2);
            this.groupTargetPort.Controls.Add(this.numericTargetPort);
            this.groupTargetPort.Location = new System.Drawing.Point(179, 12);
            this.groupTargetPort.Name = "groupTargetPort";
            this.groupTargetPort.Size = new System.Drawing.Size(161, 45);
            this.groupTargetPort.TabIndex = 2;
            this.groupTargetPort.TabStop = false;
            this.groupTargetPort.Text = "Target Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "1024 to 65535";
            // 
            // numericTargetPort
            // 
            this.numericTargetPort.Location = new System.Drawing.Point(6, 19);
            this.numericTargetPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericTargetPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericTargetPort.Name = "numericTargetPort";
            this.numericTargetPort.Size = new System.Drawing.Size(56, 20);
            this.numericTargetPort.TabIndex = 0;
            this.numericTargetPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericTargetPort.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            this.numericTargetPort.ValueChanged += new System.EventHandler(this.numericTargetPort_ValueChanged);
            // 
            // groupVehicleSpeed
            // 
            this.groupVehicleSpeed.Controls.Add(this.labelMaximumSpeed);
            this.groupVehicleSpeed.Controls.Add(this.label33);
            this.groupVehicleSpeed.Controls.Add(this.label34);
            this.groupVehicleSpeed.Controls.Add(this.label11);
            this.groupVehicleSpeed.Controls.Add(this.label9);
            this.groupVehicleSpeed.Controls.Add(this.labelMinimumSpeed);
            this.groupVehicleSpeed.Controls.Add(this.trackSpeed);
            this.groupVehicleSpeed.Controls.Add(this.shapeContainer1);
            this.groupVehicleSpeed.Controls.Add(this.labelSpeedStatus);
            this.groupVehicleSpeed.Location = new System.Drawing.Point(12, 170);
            this.groupVehicleSpeed.Name = "groupVehicleSpeed";
            this.groupVehicleSpeed.Size = new System.Drawing.Size(495, 113);
            this.groupVehicleSpeed.TabIndex = 6;
            this.groupVehicleSpeed.TabStop = false;
            this.groupVehicleSpeed.Text = "Vehicle Speed";
            // 
            // labelMaximumSpeed
            // 
            this.labelMaximumSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaximumSpeed.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelMaximumSpeed.Location = new System.Drawing.Point(452, 93);
            this.labelMaximumSpeed.Name = "labelMaximumSpeed";
            this.labelMaximumSpeed.Size = new System.Drawing.Size(35, 13);
            this.labelMaximumSpeed.TabIndex = 3;
            this.labelMaximumSpeed.Text = "255";
            this.labelMaximumSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(85, 79);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(62, 13);
            this.label33.TabIndex = 4;
            this.label33.Text = "Stopped";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label34.Location = new System.Drawing.Point(85, 93);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(62, 13);
            this.label34.TabIndex = 1;
            this.label34.Text = "55";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label11.Location = new System.Drawing.Point(427, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Forward";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(6, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Reverse";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMinimumSpeed
            // 
            this.labelMinimumSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMinimumSpeed.ForeColor = System.Drawing.Color.Green;
            this.labelMinimumSpeed.Location = new System.Drawing.Point(6, 93);
            this.labelMinimumSpeed.Name = "labelMinimumSpeed";
            this.labelMinimumSpeed.Size = new System.Drawing.Size(35, 13);
            this.labelMinimumSpeed.TabIndex = 1;
            this.labelMinimumSpeed.Text = "0";
            this.labelMinimumSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackSpeed
            // 
            this.trackSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackSpeed.AutoSize = false;
            this.trackSpeed.Enabled = false;
            this.trackSpeed.Location = new System.Drawing.Point(6, 19);
            this.trackSpeed.Maximum = 255;
            this.trackSpeed.Name = "trackSpeed";
            this.trackSpeed.Size = new System.Drawing.Size(483, 35);
            this.trackSpeed.TabIndex = 0;
            this.trackSpeed.TickFrequency = 5;
            this.trackSpeed.Value = 55;
            this.trackSpeed.Scroll += new System.EventHandler(this.trackSpeed_ValueChanged);
            this.trackSpeed.ValueChanged += new System.EventHandler(this.trackSpeed_ValueChanged);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(489, 94);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.Color.DodgerBlue;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 472;
            this.lineShape3.X2 = 472;
            this.lineShape3.Y1 = 31;
            this.lineShape3.Y2 = 54;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.Green;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 16;
            this.lineShape2.X2 = 16;
            this.lineShape2.Y1 = 31;
            this.lineShape2.Y2 = 54;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 114;
            this.lineShape1.X2 = 114;
            this.lineShape1.Y1 = 31;
            this.lineShape1.Y2 = 54;
            // 
            // labelSpeedStatus
            // 
            this.labelSpeedStatus.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeedStatus.Location = new System.Drawing.Point(348, 0);
            this.labelSpeedStatus.Name = "labelSpeedStatus";
            this.labelSpeedStatus.Size = new System.Drawing.Size(141, 13);
            this.labelSpeedStatus.TabIndex = 0;
            this.labelSpeedStatus.Text = "Stopped :: 55 / 255";
            // 
            // groupVehicleDirection
            // 
            this.groupVehicleDirection.Controls.Add(this.label13);
            this.groupVehicleDirection.Controls.Add(this.label10);
            this.groupVehicleDirection.Controls.Add(this.label14);
            this.groupVehicleDirection.Controls.Add(this.labelMaximumRight);
            this.groupVehicleDirection.Controls.Add(this.label12);
            this.groupVehicleDirection.Controls.Add(this.labelMaximumLeft);
            this.groupVehicleDirection.Controls.Add(this.trackDirection);
            this.groupVehicleDirection.Controls.Add(this.shapeContainer2);
            this.groupVehicleDirection.Controls.Add(this.labelDirectionStatus);
            this.groupVehicleDirection.Location = new System.Drawing.Point(513, 170);
            this.groupVehicleDirection.Name = "groupVehicleDirection";
            this.groupVehicleDirection.Size = new System.Drawing.Size(494, 113);
            this.groupVehicleDirection.TabIndex = 7;
            this.groupVehicleDirection.TabStop = false;
            this.groupVehicleDirection.Text = "Vehicle Direction";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(216, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "128";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(216, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Straight";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(426, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Right";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMaximumRight
            // 
            this.labelMaximumRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaximumRight.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelMaximumRight.Location = new System.Drawing.Point(453, 93);
            this.labelMaximumRight.Name = "labelMaximumRight";
            this.labelMaximumRight.Size = new System.Drawing.Size(35, 13);
            this.labelMaximumRight.TabIndex = 3;
            this.labelMaximumRight.Text = "255";
            this.labelMaximumRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(7, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Left";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMaximumLeft
            // 
            this.labelMaximumLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMaximumLeft.ForeColor = System.Drawing.Color.Green;
            this.labelMaximumLeft.Location = new System.Drawing.Point(7, 93);
            this.labelMaximumLeft.Name = "labelMaximumLeft";
            this.labelMaximumLeft.Size = new System.Drawing.Size(35, 13);
            this.labelMaximumLeft.TabIndex = 1;
            this.labelMaximumLeft.Text = "0";
            this.labelMaximumLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackDirection
            // 
            this.trackDirection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackDirection.AutoSize = false;
            this.trackDirection.Enabled = false;
            this.trackDirection.Location = new System.Drawing.Point(6, 19);
            this.trackDirection.Maximum = 255;
            this.trackDirection.Name = "trackDirection";
            this.trackDirection.Size = new System.Drawing.Size(482, 35);
            this.trackDirection.TabIndex = 0;
            this.trackDirection.TickFrequency = 5;
            this.trackDirection.Value = 128;
            this.trackDirection.Scroll += new System.EventHandler(this.trackDirection_ValueChanged);
            this.trackDirection.ValueChanged += new System.EventHandler(this.trackDirection_ValueChanged);
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape6,
            this.lineShape5,
            this.lineShape4});
            this.shapeContainer2.Size = new System.Drawing.Size(488, 94);
            this.shapeContainer2.TabIndex = 7;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape6
            // 
            this.lineShape6.Name = "lineShape6";
            this.lineShape6.X1 = 244;
            this.lineShape6.X2 = 244;
            this.lineShape6.Y1 = 31;
            this.lineShape6.Y2 = 54;
            // 
            // lineShape5
            // 
            this.lineShape5.BorderColor = System.Drawing.Color.DodgerBlue;
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 472;
            this.lineShape5.X2 = 472;
            this.lineShape5.Y1 = 31;
            this.lineShape5.Y2 = 54;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.Green;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 16;
            this.lineShape4.X2 = 16;
            this.lineShape4.Y1 = 31;
            this.lineShape4.Y2 = 54;
            // 
            // labelDirectionStatus
            // 
            this.labelDirectionStatus.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDirectionStatus.Location = new System.Drawing.Point(347, 0);
            this.labelDirectionStatus.Name = "labelDirectionStatus";
            this.labelDirectionStatus.Size = new System.Drawing.Size(141, 13);
            this.labelDirectionStatus.TabIndex = 0;
            this.labelDirectionStatus.Text = "Straight :: 128 / 255";
            // 
            // buttonIncreaseSpeed
            // 
            this.buttonIncreaseSpeed.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIncreaseSpeed.Location = new System.Drawing.Point(160, 397);
            this.buttonIncreaseSpeed.Name = "buttonIncreaseSpeed";
            this.buttonIncreaseSpeed.Size = new System.Drawing.Size(197, 45);
            this.buttonIncreaseSpeed.TabIndex = 14;
            this.buttonIncreaseSpeed.Text = "INCREASE SPEED (+25)";
            this.buttonIncreaseSpeed.UseVisualStyleBackColor = true;
            this.buttonIncreaseSpeed.Click += new System.EventHandler(this.buttonIncreaseSpeed_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.ForeColor = System.Drawing.Color.Maroon;
            this.buttonStop.Location = new System.Drawing.Point(221, 448);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 75);
            this.buttonStop.TabIndex = 21;
            this.buttonStop.Text = "FULL STOP";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonDecreaseSpeed
            // 
            this.buttonDecreaseSpeed.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDecreaseSpeed.Location = new System.Drawing.Point(160, 529);
            this.buttonDecreaseSpeed.Name = "buttonDecreaseSpeed";
            this.buttonDecreaseSpeed.Size = new System.Drawing.Size(197, 45);
            this.buttonDecreaseSpeed.TabIndex = 20;
            this.buttonDecreaseSpeed.Text = "DECREASE SPEED (-10)";
            this.buttonDecreaseSpeed.UseVisualStyleBackColor = true;
            this.buttonDecreaseSpeed.Click += new System.EventHandler(this.buttonDecreaseSpeed_Click);
            // 
            // buttonTurnLeft
            // 
            this.buttonTurnLeft.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTurnLeft.Location = new System.Drawing.Point(160, 448);
            this.buttonTurnLeft.Name = "buttonTurnLeft";
            this.buttonTurnLeft.Size = new System.Drawing.Size(55, 75);
            this.buttonTurnLeft.TabIndex = 16;
            this.buttonTurnLeft.Text = "TURN\r\nLEFT\r\n(-32)";
            this.buttonTurnLeft.UseVisualStyleBackColor = true;
            this.buttonTurnLeft.Click += new System.EventHandler(this.buttonTurnLeft_Click);
            // 
            // buttonTurnRight
            // 
            this.buttonTurnRight.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTurnRight.Location = new System.Drawing.Point(302, 448);
            this.buttonTurnRight.Name = "buttonTurnRight";
            this.buttonTurnRight.Size = new System.Drawing.Size(55, 75);
            this.buttonTurnRight.TabIndex = 18;
            this.buttonTurnRight.Text = "TURN\r\nRIGHT\r\n(+32)";
            this.buttonTurnRight.UseVisualStyleBackColor = true;
            this.buttonTurnRight.Click += new System.EventHandler(this.buttonTurnRight_Click);
            // 
            // buttonNextTrack
            // 
            this.buttonNextTrack.Enabled = false;
            this.buttonNextTrack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextTrack.Location = new System.Drawing.Point(11, 339);
            this.buttonNextTrack.Name = "buttonNextTrack";
            this.buttonNextTrack.Size = new System.Drawing.Size(75, 75);
            this.buttonNextTrack.TabIndex = 9;
            this.buttonNextTrack.Text = "NEXT\r\nTRACK";
            this.buttonNextTrack.UseVisualStyleBackColor = true;
            this.buttonNextTrack.Click += new System.EventHandler(this.buttonNextTrack_Click);
            // 
            // buttonTogglePlayback
            // 
            this.buttonTogglePlayback.Enabled = false;
            this.buttonTogglePlayback.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTogglePlayback.Location = new System.Drawing.Point(11, 420);
            this.buttonTogglePlayback.Name = "buttonTogglePlayback";
            this.buttonTogglePlayback.Size = new System.Drawing.Size(75, 103);
            this.buttonTogglePlayback.TabIndex = 10;
            this.buttonTogglePlayback.Text = "PLAY/STOP\r\nTRACK";
            this.buttonTogglePlayback.UseVisualStyleBackColor = true;
            this.buttonTogglePlayback.Click += new System.EventHandler(this.buttonTogglePlayback_Click);
            // 
            // buttonPreviousTrack
            // 
            this.buttonPreviousTrack.Enabled = false;
            this.buttonPreviousTrack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreviousTrack.Location = new System.Drawing.Point(11, 529);
            this.buttonPreviousTrack.Name = "buttonPreviousTrack";
            this.buttonPreviousTrack.Size = new System.Drawing.Size(75, 75);
            this.buttonPreviousTrack.TabIndex = 11;
            this.buttonPreviousTrack.Text = "PREVIOUS\r\nTRACK";
            this.buttonPreviousTrack.UseVisualStyleBackColor = true;
            this.buttonPreviousTrack.Click += new System.EventHandler(this.buttonPreviousTrack_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(106, 298);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(305, 38);
            this.label16.TabIndex = 12;
            this.label16.Text = "MOTOR AND SERVO CONTROL";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(432, 298);
            this.label17.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 38);
            this.label17.TabIndex = 22;
            this.label17.Text = "BATTERY";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(432, 459);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 38);
            this.label19.TabIndex = 25;
            this.label19.Text = "SIGNAL";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.checkEnableBattery);
            this.groupOptions.Controls.Add(this.checkEnableSignals);
            this.groupOptions.Controls.Add(this.checkEnableStereo);
            this.groupOptions.Location = new System.Drawing.Point(12, 63);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(244, 101);
            this.groupOptions.TabIndex = 3;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // checkEnableBattery
            // 
            this.checkEnableBattery.AutoSize = true;
            this.checkEnableBattery.Location = new System.Drawing.Point(6, 56);
            this.checkEnableBattery.Name = "checkEnableBattery";
            this.checkEnableBattery.Size = new System.Drawing.Size(164, 17);
            this.checkEnableBattery.TabIndex = 3;
            this.checkEnableBattery.Text = "Enable battery readings";
            this.checkEnableBattery.UseVisualStyleBackColor = true;
            this.checkEnableBattery.CheckedChanged += new System.EventHandler(this.checkEnableBattery_CheckedChanged);
            // 
            // checkEnableSignals
            // 
            this.checkEnableSignals.AutoSize = true;
            this.checkEnableSignals.Location = new System.Drawing.Point(6, 37);
            this.checkEnableSignals.Name = "checkEnableSignals";
            this.checkEnableSignals.Size = new System.Drawing.Size(236, 17);
            this.checkEnableSignals.TabIndex = 1;
            this.checkEnableSignals.Text = "Enable turn, brake, reverse signals";
            this.checkEnableSignals.UseVisualStyleBackColor = true;
            this.checkEnableSignals.CheckedChanged += new System.EventHandler(this.checkEnableSignals_CheckedChanged);
            // 
            // checkEnableStereo
            // 
            this.checkEnableStereo.AutoSize = true;
            this.checkEnableStereo.Location = new System.Drawing.Point(6, 19);
            this.checkEnableStereo.Name = "checkEnableStereo";
            this.checkEnableStereo.Size = new System.Drawing.Size(146, 17);
            this.checkEnableStereo.TabIndex = 0;
            this.checkEnableStereo.Text = "Enable stereo system";
            this.checkEnableStereo.UseVisualStyleBackColor = true;
            this.checkEnableStereo.CheckedChanged += new System.EventHandler(this.checkEnableStereo_CheckedChanged);
            // 
            // groupIntervals
            // 
            this.groupIntervals.Controls.Add(this.label28);
            this.groupIntervals.Controls.Add(this.label27);
            this.groupIntervals.Controls.Add(this.label26);
            this.groupIntervals.Controls.Add(this.label25);
            this.groupIntervals.Controls.Add(this.numericRightInterval);
            this.groupIntervals.Controls.Add(this.numericLeftInterval);
            this.groupIntervals.Controls.Add(this.numericDecreaseInterval);
            this.groupIntervals.Controls.Add(this.numericIncreaseInterval);
            this.groupIntervals.Controls.Add(this.label22);
            this.groupIntervals.Controls.Add(this.label24);
            this.groupIntervals.Controls.Add(this.label23);
            this.groupIntervals.Controls.Add(this.label21);
            this.groupIntervals.Location = new System.Drawing.Point(262, 63);
            this.groupIntervals.Name = "groupIntervals";
            this.groupIntervals.Size = new System.Drawing.Size(245, 101);
            this.groupIntervals.TabIndex = 4;
            this.groupIntervals.TabStop = false;
            this.groupIntervals.Text = "Intervals";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(152, 79);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 11;
            this.label28.Text = "units";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(152, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(37, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "units";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(152, 41);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 13);
            this.label26.TabIndex = 5;
            this.label26.Text = "units";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(152, 22);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "units";
            // 
            // numericRightInterval
            // 
            this.numericRightInterval.Location = new System.Drawing.Point(90, 75);
            this.numericRightInterval.Name = "numericRightInterval";
            this.numericRightInterval.Size = new System.Drawing.Size(56, 20);
            this.numericRightInterval.TabIndex = 10;
            this.numericRightInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericRightInterval.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericRightInterval.ValueChanged += new System.EventHandler(this.numericRightInterval_ValueChanged);
            // 
            // numericLeftInterval
            // 
            this.numericLeftInterval.Location = new System.Drawing.Point(90, 56);
            this.numericLeftInterval.Name = "numericLeftInterval";
            this.numericLeftInterval.Size = new System.Drawing.Size(56, 20);
            this.numericLeftInterval.TabIndex = 7;
            this.numericLeftInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericLeftInterval.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericLeftInterval.ValueChanged += new System.EventHandler(this.numericLeftInterval_ValueChanged);
            // 
            // numericDecreaseInterval
            // 
            this.numericDecreaseInterval.Location = new System.Drawing.Point(90, 37);
            this.numericDecreaseInterval.Name = "numericDecreaseInterval";
            this.numericDecreaseInterval.Size = new System.Drawing.Size(56, 20);
            this.numericDecreaseInterval.TabIndex = 4;
            this.numericDecreaseInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericDecreaseInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericDecreaseInterval.ValueChanged += new System.EventHandler(this.numericDecreaseInterval_ValueChanged);
            // 
            // numericIncreaseInterval
            // 
            this.numericIncreaseInterval.Location = new System.Drawing.Point(90, 18);
            this.numericIncreaseInterval.Name = "numericIncreaseInterval";
            this.numericIncreaseInterval.Size = new System.Drawing.Size(56, 20);
            this.numericIncreaseInterval.TabIndex = 1;
            this.numericIncreaseInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericIncreaseInterval.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericIncreaseInterval.ValueChanged += new System.EventHandler(this.numericIncreaseInterval_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(23, 41);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "Speed - =";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(23, 79);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(61, 13);
            this.label24.TabIndex = 9;
            this.label24.Text = "Right   =";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(29, 60);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 13);
            this.label23.TabIndex = 6;
            this.label23.Text = "Left   =";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Speed + =";
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(11, 298);
            this.label29.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(75, 38);
            this.label29.TabIndex = 8;
            this.label29.Text = "STEREO";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // workerTransmitter
            // 
            this.workerTransmitter.WorkerReportsProgress = true;
            this.workerTransmitter.WorkerSupportsCancellation = true;
            this.workerTransmitter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerTransmitter_DoWork);
            // 
            // workerReceiver
            // 
            this.workerReceiver.WorkerReportsProgress = true;
            this.workerReceiver.WorkerSupportsCancellation = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 615);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1019, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = false;
            this.labelStatus.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(850, 17);
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelStatus.TextChanged += new System.EventHandler(this.labelStatus_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(155, 16);
            // 
            // labelBattery
            // 
            this.labelBattery.Enabled = false;
            this.labelBattery.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBattery.ForeColor = System.Drawing.Color.Red;
            this.labelBattery.Location = new System.Drawing.Point(432, 339);
            this.labelBattery.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.labelBattery.Name = "labelBattery";
            this.labelBattery.Size = new System.Drawing.Size(75, 49);
            this.labelBattery.TabIndex = 23;
            this.labelBattery.Text = "0%";
            this.labelBattery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBattery.TextChanged += new System.EventHandler(this.labelBattery_TextChanged);
            // 
            // labelSignal
            // 
            this.labelSignal.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSignal.ForeColor = System.Drawing.Color.Red;
            this.labelSignal.Location = new System.Drawing.Point(432, 500);
            this.labelSignal.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.labelSignal.Name = "labelSignal";
            this.labelSignal.Size = new System.Drawing.Size(75, 49);
            this.labelSignal.TabIndex = 26;
            this.labelSignal.Text = "0%";
            this.labelSignal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSignal.TextChanged += new System.EventHandler(this.labelSignal_TextChanged);
            // 
            // buttonFullLeft
            // 
            this.buttonFullLeft.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFullLeft.Location = new System.Drawing.Point(106, 367);
            this.buttonFullLeft.Name = "buttonFullLeft";
            this.buttonFullLeft.Size = new System.Drawing.Size(48, 237);
            this.buttonFullLeft.TabIndex = 15;
            this.buttonFullLeft.Text = "FULL\r\nLEFT\r\n(0)";
            this.buttonFullLeft.UseVisualStyleBackColor = true;
            this.buttonFullLeft.Click += new System.EventHandler(this.buttonFullLeft_Click);
            // 
            // buttonFullRight
            // 
            this.buttonFullRight.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFullRight.Location = new System.Drawing.Point(363, 367);
            this.buttonFullRight.Name = "buttonFullRight";
            this.buttonFullRight.Size = new System.Drawing.Size(48, 237);
            this.buttonFullRight.TabIndex = 17;
            this.buttonFullRight.Text = "FULL\r\nRIGHT\r\n(255)";
            this.buttonFullRight.UseVisualStyleBackColor = true;
            this.buttonFullRight.Click += new System.EventHandler(this.buttonFullRight_Click);
            // 
            // buttonFullForward
            // 
            this.buttonFullForward.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFullForward.Location = new System.Drawing.Point(160, 367);
            this.buttonFullForward.Name = "buttonFullForward";
            this.buttonFullForward.Size = new System.Drawing.Size(197, 24);
            this.buttonFullForward.TabIndex = 13;
            this.buttonFullForward.Text = "FULL FORWARD (255)";
            this.buttonFullForward.UseVisualStyleBackColor = true;
            this.buttonFullForward.Click += new System.EventHandler(this.buttonFullForward_Click);
            // 
            // buttonFullReverse
            // 
            this.buttonFullReverse.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFullReverse.Location = new System.Drawing.Point(160, 580);
            this.buttonFullReverse.Name = "buttonFullReverse";
            this.buttonFullReverse.Size = new System.Drawing.Size(197, 24);
            this.buttonFullReverse.TabIndex = 19;
            this.buttonFullReverse.Text = "FULL REVERSE (0)";
            this.buttonFullReverse.UseVisualStyleBackColor = true;
            this.buttonFullReverse.Click += new System.EventHandler(this.buttonFullReverse_Click);
            // 
            // buttonStraight
            // 
            this.buttonStraight.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStraight.Location = new System.Drawing.Point(106, 339);
            this.buttonStraight.Name = "buttonStraight";
            this.buttonStraight.Size = new System.Drawing.Size(305, 23);
            this.buttonStraight.TabIndex = 40;
            this.buttonStraight.Text = "FULL STRAIGHT (128)";
            this.buttonStraight.UseVisualStyleBackColor = true;
            this.buttonStraight.Click += new System.EventHandler(this.buttonStraight_Click);
            // 
            // timerReceiver
            // 
            this.timerReceiver.Enabled = true;
            this.timerReceiver.Tick += new System.EventHandler(this.timerReceiver_Tick);
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // workerPing
            // 
            this.workerPing.WorkerReportsProgress = true;
            this.workerPing.WorkerSupportsCancellation = true;
            this.workerPing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerPing_DoWork);
            this.workerPing.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerPing_ProgressChanged);
            this.workerPing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerPing_RunWorkerCompleted);
            // 
            // groupSignalColors
            // 
            this.groupSignalColors.Controls.Add(this.labelReverseSignal);
            this.groupSignalColors.Controls.Add(this.labelBrakeSignal);
            this.groupSignalColors.Controls.Add(this.labelTurnSignal);
            this.groupSignalColors.Controls.Add(this.panelReverseSignal);
            this.groupSignalColors.Controls.Add(this.panelBrakeSignal);
            this.groupSignalColors.Controls.Add(this.panelTurnSignal);
            this.groupSignalColors.Controls.Add(this.label32);
            this.groupSignalColors.Controls.Add(this.label31);
            this.groupSignalColors.Controls.Add(this.label30);
            this.groupSignalColors.Enabled = false;
            this.groupSignalColors.Location = new System.Drawing.Point(513, 63);
            this.groupSignalColors.Name = "groupSignalColors";
            this.groupSignalColors.Size = new System.Drawing.Size(244, 101);
            this.groupSignalColors.TabIndex = 41;
            this.groupSignalColors.TabStop = false;
            this.groupSignalColors.Text = "Signal Colors";
            // 
            // labelReverseSignal
            // 
            this.labelReverseSignal.AutoSize = true;
            this.labelReverseSignal.Location = new System.Drawing.Point(140, 75);
            this.labelReverseSignal.Name = "labelReverseSignal";
            this.labelReverseSignal.Size = new System.Drawing.Size(49, 13);
            this.labelReverseSignal.TabIndex = 2;
            this.labelReverseSignal.Text = "#000000";
            // 
            // labelBrakeSignal
            // 
            this.labelBrakeSignal.AutoSize = true;
            this.labelBrakeSignal.Location = new System.Drawing.Point(140, 49);
            this.labelBrakeSignal.Name = "labelBrakeSignal";
            this.labelBrakeSignal.Size = new System.Drawing.Size(49, 13);
            this.labelBrakeSignal.TabIndex = 2;
            this.labelBrakeSignal.Text = "#000000";
            // 
            // labelTurnSignal
            // 
            this.labelTurnSignal.AutoSize = true;
            this.labelTurnSignal.Location = new System.Drawing.Point(140, 23);
            this.labelTurnSignal.Name = "labelTurnSignal";
            this.labelTurnSignal.Size = new System.Drawing.Size(49, 13);
            this.labelTurnSignal.TabIndex = 2;
            this.labelTurnSignal.Text = "#000000";
            // 
            // panelReverseSignal
            // 
            this.panelReverseSignal.BackColor = System.Drawing.Color.Black;
            this.panelReverseSignal.Location = new System.Drawing.Point(109, 71);
            this.panelReverseSignal.Name = "panelReverseSignal";
            this.panelReverseSignal.Size = new System.Drawing.Size(25, 20);
            this.panelReverseSignal.TabIndex = 1;
            this.panelReverseSignal.DoubleClick += new System.EventHandler(this.panelReverseSignal_DoubleClick);
            // 
            // panelBrakeSignal
            // 
            this.panelBrakeSignal.BackColor = System.Drawing.Color.Black;
            this.panelBrakeSignal.Location = new System.Drawing.Point(109, 45);
            this.panelBrakeSignal.Name = "panelBrakeSignal";
            this.panelBrakeSignal.Size = new System.Drawing.Size(25, 20);
            this.panelBrakeSignal.TabIndex = 1;
            this.panelBrakeSignal.DoubleClick += new System.EventHandler(this.panelBrakeSignal_DoubleClick);
            // 
            // panelTurnSignal
            // 
            this.panelTurnSignal.BackColor = System.Drawing.Color.Black;
            this.panelTurnSignal.Location = new System.Drawing.Point(109, 19);
            this.panelTurnSignal.Name = "panelTurnSignal";
            this.panelTurnSignal.Size = new System.Drawing.Size(25, 20);
            this.panelTurnSignal.TabIndex = 1;
            this.panelTurnSignal.DoubleClick += new System.EventHandler(this.panelTurnSignal_DoubleClick);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 75);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(97, 13);
            this.label32.TabIndex = 0;
            this.label32.Text = "Reverse Signal:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(19, 49);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(85, 13);
            this.label31.TabIndex = 0;
            this.label31.Text = "Brake Signal:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(20, 23);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "Turn Signal:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.listLog);
            this.groupBox10.Location = new System.Drawing.Point(513, 298);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox10.Size = new System.Drawing.Size(494, 306);
            this.groupBox10.TabIndex = 42;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Log";
            // 
            // listLog
            // 
            this.listLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.listLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLog.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.listLog.FullRowSelect = true;
            this.listLog.GridLines = true;
            this.listLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listLog.Location = new System.Drawing.Point(8, 21);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(478, 277);
            this.listLog.TabIndex = 0;
            this.listLog.UseCompatibleStateImageBehavior = false;
            this.listLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 87;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Event";
            this.columnHeader3.Width = 370;
            // 
            // groupOutputPath
            // 
            this.groupOutputPath.Controls.Add(this.linkSelect);
            this.groupOutputPath.Controls.Add(this.textOutputPath);
            this.groupOutputPath.Location = new System.Drawing.Point(346, 12);
            this.groupOutputPath.Name = "groupOutputPath";
            this.groupOutputPath.Size = new System.Drawing.Size(661, 45);
            this.groupOutputPath.TabIndex = 43;
            this.groupOutputPath.TabStop = false;
            this.groupOutputPath.Text = "Output Path";
            // 
            // linkSelect
            // 
            this.linkSelect.AutoSize = true;
            this.linkSelect.Location = new System.Drawing.Point(612, 23);
            this.linkSelect.Name = "linkSelect";
            this.linkSelect.Size = new System.Drawing.Size(43, 13);
            this.linkSelect.TabIndex = 1;
            this.linkSelect.TabStop = true;
            this.linkSelect.Text = "Select";
            this.linkSelect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelect_LinkClicked);
            // 
            // textOutputPath
            // 
            this.textOutputPath.Location = new System.Drawing.Point(6, 19);
            this.textOutputPath.Name = "textOutputPath";
            this.textOutputPath.Size = new System.Drawing.Size(600, 20);
            this.textOutputPath.TabIndex = 0;
            this.textOutputPath.TextChanged += new System.EventHandler(this.textOutputPath_TextChanged);
            // 
            // progressBattery
            // 
            this.progressBattery.Enabled = false;
            this.progressBattery.Location = new System.Drawing.Point(432, 391);
            this.progressBattery.Maximum = 255;
            this.progressBattery.Name = "progressBattery";
            this.progressBattery.Size = new System.Drawing.Size(75, 23);
            this.progressBattery.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBattery.TabIndex = 44;
            // 
            // progressSignal
            // 
            this.progressSignal.Location = new System.Drawing.Point(432, 552);
            this.progressSignal.Maximum = 255;
            this.progressSignal.Name = "progressSignal";
            this.progressSignal.Size = new System.Drawing.Size(75, 23);
            this.progressSignal.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressSignal.TabIndex = 44;
            // 
            // buttonSignal
            // 
            this.buttonSignal.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSignal.Location = new System.Drawing.Point(432, 581);
            this.buttonSignal.Name = "buttonSignal";
            this.buttonSignal.Size = new System.Drawing.Size(75, 23);
            this.buttonSignal.TabIndex = 45;
            this.buttonSignal.Text = "UPDATE";
            this.buttonSignal.UseVisualStyleBackColor = true;
            this.buttonSignal.Click += new System.EventHandler(this.buttonSignal_Click);
            // 
            // buttonBattery
            // 
            this.buttonBattery.Enabled = false;
            this.buttonBattery.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBattery.Location = new System.Drawing.Point(432, 420);
            this.buttonBattery.Name = "buttonBattery";
            this.buttonBattery.Size = new System.Drawing.Size(75, 23);
            this.buttonBattery.TabIndex = 45;
            this.buttonBattery.Text = "UPDATE";
            this.buttonBattery.UseVisualStyleBackColor = true;
            this.buttonBattery.Click += new System.EventHandler(this.buttonBattery_Click);
            // 
            // buttonSendSettings
            // 
            this.buttonSendSettings.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSendSettings.Location = new System.Drawing.Point(763, 63);
            this.buttonSendSettings.Name = "buttonSendSettings";
            this.buttonSendSettings.Size = new System.Drawing.Size(244, 101);
            this.buttonSendSettings.TabIndex = 46;
            this.buttonSendSettings.Text = "SEND PROGRAM SETTINGS";
            this.buttonSendSettings.UseVisualStyleBackColor = true;
            this.buttonSendSettings.Click += new System.EventHandler(this.buttonSendSettings_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 637);
            this.Controls.Add(this.buttonSendSettings);
            this.Controls.Add(this.buttonBattery);
            this.Controls.Add(this.buttonSignal);
            this.Controls.Add(this.progressSignal);
            this.Controls.Add(this.progressBattery);
            this.Controls.Add(this.groupOutputPath);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupSignalColors);
            this.Controls.Add(this.buttonStraight);
            this.Controls.Add(this.buttonFullRight);
            this.Controls.Add(this.buttonFullReverse);
            this.Controls.Add(this.buttonFullForward);
            this.Controls.Add(this.buttonFullLeft);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupIntervals);
            this.Controls.Add(this.groupOptions);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.labelSignal);
            this.Controls.Add(this.labelBattery);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.buttonTurnRight);
            this.Controls.Add(this.buttonTurnLeft);
            this.Controls.Add(this.buttonDecreaseSpeed);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonTogglePlayback);
            this.Controls.Add(this.buttonPreviousTrack);
            this.Controls.Add(this.buttonNextTrack);
            this.Controls.Add(this.buttonIncreaseSpeed);
            this.Controls.Add(this.groupVehicleDirection);
            this.Controls.Add(this.groupVehicleSpeed);
            this.Controls.Add(this.groupTargetPort);
            this.Controls.Add(this.groupTargetIP);
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "WiFi R/C Car Communicator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupTargetIP.ResumeLayout(false);
            this.groupTargetIP.PerformLayout();
            this.groupTargetPort.ResumeLayout(false);
            this.groupTargetPort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTargetPort)).EndInit();
            this.groupVehicleSpeed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).EndInit();
            this.groupVehicleDirection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackDirection)).EndInit();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.groupIntervals.ResumeLayout(false);
            this.groupIntervals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRightInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLeftInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDecreaseInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncreaseInterval)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupSignalColors.ResumeLayout(false);
            this.groupSignalColors.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupOutputPath.ResumeLayout(false);
            this.groupOutputPath.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTargetIP;
        private System.Windows.Forms.TextBox textTargetIP;
        private System.Windows.Forms.GroupBox groupTargetPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericTargetPort;
        private System.Windows.Forms.GroupBox groupVehicleSpeed;
        private System.Windows.Forms.Label labelMaximumSpeed;
        private System.Windows.Forms.Label labelMinimumSpeed;
        private System.Windows.Forms.TrackBar trackSpeed;
        private System.Windows.Forms.GroupBox groupVehicleDirection;
        private System.Windows.Forms.Label labelMaximumRight;
        private System.Windows.Forms.Label labelMaximumLeft;
        private System.Windows.Forms.TrackBar trackDirection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonIncreaseSpeed;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonDecreaseSpeed;
        private System.Windows.Forms.Button buttonTurnLeft;
        private System.Windows.Forms.Button buttonTurnRight;
        private System.Windows.Forms.Button buttonNextTrack;
        private System.Windows.Forms.Button buttonTogglePlayback;
        private System.Windows.Forms.Button buttonPreviousTrack;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.CheckBox checkEnableSignals;
        private System.Windows.Forms.CheckBox checkEnableStereo;
        private System.Windows.Forms.GroupBox groupIntervals;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown numericRightInterval;
        private System.Windows.Forms.NumericUpDown numericLeftInterval;
        private System.Windows.Forms.NumericUpDown numericDecreaseInterval;
        private System.Windows.Forms.NumericUpDown numericIncreaseInterval;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkEnableBattery;
        private System.Windows.Forms.Label label29;
        private System.ComponentModel.BackgroundWorker workerTransmitter;
        private System.ComponentModel.BackgroundWorker workerReceiver;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Label labelBattery;
        private System.Windows.Forms.Label labelSignal;
        private System.Windows.Forms.Button buttonFullLeft;
        private System.Windows.Forms.Button buttonFullRight;
        private System.Windows.Forms.Button buttonFullForward;
        private System.Windows.Forms.Button buttonFullReverse;
        private System.Windows.Forms.Button buttonStraight;
        private System.Windows.Forms.Timer timerReceiver;
        private System.Windows.Forms.Timer timerStatus;
        private System.ComponentModel.BackgroundWorker workerPing;
        private System.Windows.Forms.GroupBox groupSignalColors;
        private System.Windows.Forms.Label labelReverseSignal;
        private System.Windows.Forms.Label labelBrakeSignal;
        private System.Windows.Forms.Label labelTurnSignal;
        private System.Windows.Forms.Panel panelReverseSignal;
        private System.Windows.Forms.Panel panelBrakeSignal;
        private System.Windows.Forms.Panel panelTurnSignal;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ListView listLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupOutputPath;
        private System.Windows.Forms.TextBox textOutputPath;
        private System.Windows.Forms.LinkLabel linkSelect;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label10;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private System.Windows.Forms.Label labelSpeedStatus;
        private System.Windows.Forms.Label labelDirectionStatus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ProgressBar progressBattery;
        private System.Windows.Forms.ProgressBar progressSignal;
        private System.Windows.Forms.Button buttonSignal;
        private System.Windows.Forms.Button buttonBattery;
        private System.Windows.Forms.Button buttonSendSettings;
    }
}

