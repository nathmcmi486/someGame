﻿namespace someGame
{
    partial class MenuScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ClientSize = new System.Drawing.Size(800, 450);

            this.startButton = new System.Windows.Forms.Button();
            this.startButton.Location = new System.Drawing.Point((this.Width / 2) - 100, 100);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 50);
            this.startButton.TabIndex = 0;
            this.startButton.Click += new System.EventHandler(this.startButtonClick);
            this.startButton.Text = "Start";

            this.exitButton = new System.Windows.Forms.Button();
            this.exitButton.Location = new System.Drawing.Point((this.Width / 2) - 100, 170);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(150, 50);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.exitButtonClick);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.Gray;

            this.Controls.Add(this.startButton);
            this.Controls.Add(this.exitButton);
        }

        #endregion

        System.Windows.Forms.Button startButton;
        System.Windows.Forms.Button exitButton;
    }
}