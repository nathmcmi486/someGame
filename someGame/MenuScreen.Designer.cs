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
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 450);

            this.startButton = new System.Windows.Forms.Button();
            this.startButton.Location = new System.Drawing.Point((this.Width / 2) - 100, 100);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 50);
            this.startButton.TabIndex = 0;
            this.startButton.Click += new System.EventHandler(this.startButtonClick);
            this.startButton.Text = "Start Level 1";

            this.exitButton = new System.Windows.Forms.Button();
            this.exitButton.Location = new System.Drawing.Point((this.Width / 2) - 100, 170);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(150, 50);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.exitButtonClick);

            this.instructionsLabel = new System.Windows.Forms.Label();
            this.instructionsLabel.Location = new System.Drawing.Point((this.Width / 2) + 150, 200);
            this.instructionsLabel.Name = "exitButton";
            this.instructionsLabel.Size = new System.Drawing.Size(220, 120);
            this.instructionsLabel.TabIndex = 0;
            this.instructionsLabel.Text = "Controls:\nW - To jump\nA - To move left\nD - To move right\nH - To heal\nSpace - To shoot\nKeep moving right!";

            this.level2Button = new System.Windows.Forms.Button();
            this.level2Button.Location = new System.Drawing.Point((this.Width / 4) - 100, 200);
            this.level2Button.Name = "level2Button";
            this.level2Button.Size = new System.Drawing.Size(100, 25);
            this.level2Button.TabIndex = 0;
            this.level2Button.Click += new System.EventHandler(this.startLevel2);
            this.level2Button.Text = "Start Level 2";


            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.Gray;

            this.Controls.Add(this.startButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.level2Button);
            this.ResumeLayout(false);
        }

        #endregion

        System.Windows.Forms.Button startButton;
        System.Windows.Forms.Button exitButton;
        System.Windows.Forms.Label instructionsLabel;
        System.Windows.Forms.Button level2Button;
    }
}
