﻿namespace FunOrange_Gaming_Software
{
    partial class DebugForm
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
            this.button_connect_keypad = new System.Windows.Forms.Button();
            this.button_disconnect_keypad = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.SetRisingDebounceControl = new System.Windows.Forms.NumericUpDown();
            this.SetFallingDebounceControl = new System.Windows.Forms.NumericUpDown();
            this.SetSideButtonDebounceControl = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RemapLeftKeyControl = new System.Windows.Forms.NumericUpDown();
            this.RemapRightKeyControl = new System.Windows.Forms.NumericUpDown();
            this.RemapSideButtonControl = new System.Windows.Forms.NumericUpDown();
            this.ActivateProfileControl = new System.Windows.Forms.NumericUpDown();
            this.ReadProfileControl = new System.Windows.Forms.NumericUpDown();
            this.COMPortControl = new System.Windows.Forms.TextBox();
            this.DebugPanel = new System.Windows.Forms.Panel();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UserColorDisplay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SetRisingDebounceControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetFallingDebounceControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetSideButtonDebounceControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemapLeftKeyControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemapRightKeyControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemapSideButtonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivateProfileControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReadProfileControl)).BeginInit();
            this.DebugPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_connect_keypad
            // 
            this.button_connect_keypad.Location = new System.Drawing.Point(3, 3);
            this.button_connect_keypad.Name = "button_connect_keypad";
            this.button_connect_keypad.Size = new System.Drawing.Size(121, 23);
            this.button_connect_keypad.TabIndex = 0;
            this.button_connect_keypad.Text = "Connect Keypad";
            this.button_connect_keypad.UseVisualStyleBackColor = true;
            this.button_connect_keypad.Click += new System.EventHandler(this.button_connect_keypad_Click);
            // 
            // button_disconnect_keypad
            // 
            this.button_disconnect_keypad.Location = new System.Drawing.Point(3, 32);
            this.button_disconnect_keypad.Name = "button_disconnect_keypad";
            this.button_disconnect_keypad.Size = new System.Drawing.Size(121, 23);
            this.button_disconnect_keypad.TabIndex = 0;
            this.button_disconnect_keypad.Text = "Disconnect Keypad";
            this.button_disconnect_keypad.UseVisualStyleBackColor = true;
            this.button_disconnect_keypad.Click += new System.EventHandler(this.button_disconnect_keypad_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Erase EEPROM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "SetDebounce";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 258);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Read Debounce";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(196, 169);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "RemapLeftKey";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(196, 198);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "RemapRightKey";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(196, 227);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "RemapSideButton";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(196, 256);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "Read Keybinds";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(196, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(121, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "Activate Profile";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(196, 33);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(121, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "Get Active Profile";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(196, 62);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(121, 23);
            this.button10.TabIndex = 10;
            this.button10.Text = "Read Profile";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(196, 91);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(121, 23);
            this.button11.TabIndex = 11;
            this.button11.Text = "Write Profile";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(3, 90);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(121, 23);
            this.button12.TabIndex = 12;
            this.button12.Text = "Show COM Ports";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // SetRisingDebounceControl
            // 
            this.SetRisingDebounceControl.Location = new System.Drawing.Point(4, 203);
            this.SetRisingDebounceControl.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SetRisingDebounceControl.Name = "SetRisingDebounceControl";
            this.SetRisingDebounceControl.Size = new System.Drawing.Size(50, 20);
            this.SetRisingDebounceControl.TabIndex = 13;
            // 
            // SetFallingDebounceControl
            // 
            this.SetFallingDebounceControl.Location = new System.Drawing.Point(60, 203);
            this.SetFallingDebounceControl.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SetFallingDebounceControl.Name = "SetFallingDebounceControl";
            this.SetFallingDebounceControl.Size = new System.Drawing.Size(47, 20);
            this.SetFallingDebounceControl.TabIndex = 14;
            // 
            // SetSideButtonDebounceControl
            // 
            this.SetSideButtonDebounceControl.Location = new System.Drawing.Point(113, 203);
            this.SetSideButtonDebounceControl.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SetSideButtonDebounceControl.Name = "SetSideButtonDebounceControl";
            this.SetSideButtonDebounceControl.Size = new System.Drawing.Size(49, 20);
            this.SetSideButtonDebounceControl.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "rise";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "fall";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "side";
            // 
            // RemapLeftKeyControl
            // 
            this.RemapLeftKeyControl.Location = new System.Drawing.Point(323, 169);
            this.RemapLeftKeyControl.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RemapLeftKeyControl.Name = "RemapLeftKeyControl";
            this.RemapLeftKeyControl.Size = new System.Drawing.Size(42, 20);
            this.RemapLeftKeyControl.TabIndex = 18;
            // 
            // RemapRightKeyControl
            // 
            this.RemapRightKeyControl.Location = new System.Drawing.Point(323, 201);
            this.RemapRightKeyControl.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RemapRightKeyControl.Name = "RemapRightKeyControl";
            this.RemapRightKeyControl.Size = new System.Drawing.Size(42, 20);
            this.RemapRightKeyControl.TabIndex = 18;
            // 
            // RemapSideButtonControl
            // 
            this.RemapSideButtonControl.Location = new System.Drawing.Point(323, 230);
            this.RemapSideButtonControl.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RemapSideButtonControl.Name = "RemapSideButtonControl";
            this.RemapSideButtonControl.Size = new System.Drawing.Size(42, 20);
            this.RemapSideButtonControl.TabIndex = 18;
            // 
            // ActivateProfileControl
            // 
            this.ActivateProfileControl.Location = new System.Drawing.Point(323, 7);
            this.ActivateProfileControl.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ActivateProfileControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ActivateProfileControl.Name = "ActivateProfileControl";
            this.ActivateProfileControl.Size = new System.Drawing.Size(42, 20);
            this.ActivateProfileControl.TabIndex = 19;
            this.ActivateProfileControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ReadProfileControl
            // 
            this.ReadProfileControl.Location = new System.Drawing.Point(323, 65);
            this.ReadProfileControl.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ReadProfileControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ReadProfileControl.Name = "ReadProfileControl";
            this.ReadProfileControl.Size = new System.Drawing.Size(42, 20);
            this.ReadProfileControl.TabIndex = 19;
            this.ReadProfileControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // COMPortControl
            // 
            this.COMPortControl.Location = new System.Drawing.Point(132, 6);
            this.COMPortControl.MaxLength = 6;
            this.COMPortControl.Name = "COMPortControl";
            this.COMPortControl.Size = new System.Drawing.Size(58, 20);
            this.COMPortControl.TabIndex = 20;
            this.COMPortControl.Text = "COM7";
            // 
            // DebugPanel
            // 
            this.DebugPanel.Controls.Add(this.PortTextBox);
            this.DebugPanel.Controls.Add(this.label4);
            this.DebugPanel.Controls.Add(this.UserColorDisplay);
            this.DebugPanel.Controls.Add(this.label1);
            this.DebugPanel.Controls.Add(this.label2);
            this.DebugPanel.Controls.Add(this.label3);
            this.DebugPanel.Controls.Add(this.RemapLeftKeyControl);
            this.DebugPanel.Controls.Add(this.RemapRightKeyControl);
            this.DebugPanel.Controls.Add(this.RemapSideButtonControl);
            this.DebugPanel.Controls.Add(this.SetSideButtonDebounceControl);
            this.DebugPanel.Controls.Add(this.ActivateProfileControl);
            this.DebugPanel.Controls.Add(this.SetFallingDebounceControl);
            this.DebugPanel.Controls.Add(this.ReadProfileControl);
            this.DebugPanel.Controls.Add(this.SetRisingDebounceControl);
            this.DebugPanel.Controls.Add(this.COMPortControl);
            this.DebugPanel.Controls.Add(this.button11);
            this.DebugPanel.Controls.Add(this.button_connect_keypad);
            this.DebugPanel.Controls.Add(this.button_disconnect_keypad);
            this.DebugPanel.Controls.Add(this.button1);
            this.DebugPanel.Controls.Add(this.button12);
            this.DebugPanel.Controls.Add(this.button2);
            this.DebugPanel.Controls.Add(this.button3);
            this.DebugPanel.Controls.Add(this.button8);
            this.DebugPanel.Controls.Add(this.button5);
            this.DebugPanel.Controls.Add(this.button6);
            this.DebugPanel.Controls.Add(this.button7);
            this.DebugPanel.Controls.Add(this.button9);
            this.DebugPanel.Controls.Add(this.button10);
            this.DebugPanel.Controls.Add(this.button4);
            this.DebugPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugPanel.Location = new System.Drawing.Point(0, 0);
            this.DebugPanel.Name = "DebugPanel";
            this.DebugPanel.Size = new System.Drawing.Size(378, 290);
            this.DebugPanel.TabIndex = 21;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(5, 120);
            this.PortTextBox.Multiline = true;
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.ReadOnly = true;
            this.PortTextBox.Size = new System.Drawing.Size(157, 64);
            this.PortTextBox.TabIndex = 24;
            this.PortTextBox.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Set Custom Color:";
            // 
            // UserColorDisplay
            // 
            this.UserColorDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.UserColorDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserColorDisplay.Location = new System.Drawing.Point(290, 122);
            this.UserColorDisplay.Name = "UserColorDisplay";
            this.UserColorDisplay.Size = new System.Drawing.Size(27, 23);
            this.UserColorDisplay.TabIndex = 22;
            this.UserColorDisplay.UseVisualStyleBackColor = false;
            this.UserColorDisplay.Click += new System.EventHandler(this.UserColorDisplay_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 290);
            this.Controls.Add(this.DebugPanel);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DebugForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DebugForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.SetRisingDebounceControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetFallingDebounceControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetSideButtonDebounceControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemapLeftKeyControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemapRightKeyControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemapSideButtonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActivateProfileControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReadProfileControl)).EndInit();
            this.DebugPanel.ResumeLayout(false);
            this.DebugPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_connect_keypad;
        private System.Windows.Forms.Button button_disconnect_keypad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.NumericUpDown SetRisingDebounceControl;
        private System.Windows.Forms.NumericUpDown SetFallingDebounceControl;
        private System.Windows.Forms.NumericUpDown SetSideButtonDebounceControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RemapLeftKeyControl;
        private System.Windows.Forms.NumericUpDown RemapRightKeyControl;
        private System.Windows.Forms.NumericUpDown RemapSideButtonControl;
        private System.Windows.Forms.NumericUpDown ActivateProfileControl;
        private System.Windows.Forms.NumericUpDown ReadProfileControl;
        private System.Windows.Forms.TextBox COMPortControl;
        private System.Windows.Forms.Panel DebugPanel;
        private System.Windows.Forms.Button UserColorDisplay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PortTextBox;
    }
}

