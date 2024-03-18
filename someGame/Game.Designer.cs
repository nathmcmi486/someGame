namespace someGame
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.mainTimer.Interval = 30;
            this.mainTimer.Tick += new System.EventHandler(this.gameLoop);
            this.mainTimer.Enabled = true;
            this.mainTimer.Start();

            this.partNumberLabel = new System.Windows.Forms.Label();
            this.partNumberLabel.Location = new System.Drawing.Point(10, 10);
            this.partNumberLabel.Name = "partNumberLabel";
            this.partNumberLabel.Size = new System.Drawing.Size(10, 10);
            this.partNumberLabel.Text = "";

            this.healthLabel = new System.Windows.Forms.Label();
            this.healthLabel.Location = new System.Drawing.Point(30, 10);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(40, 10);
            this.healthLabel.Text = "";

            this.debugLabel = new System.Windows.Forms.Label();
            this.debugLabel.Location = new System.Drawing.Point(this.Width, 100);
            this.debugLabel.ForeColor = Color.White;
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(200, 100);
            this.debugLabel.Text = "";

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
            this.Controls.Add(this.partNumberLabel);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.debugLabel);

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownHandler);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUpHandler);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paintHandler);
        }

        #endregion

        System.Windows.Forms.Label partNumberLabel;
        System.Windows.Forms.Label healthLabel;
        System.Windows.Forms.Timer mainTimer;
        System.Windows.Forms.Label debugLabel;
    }
}
