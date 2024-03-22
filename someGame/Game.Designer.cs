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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.Paint += new PaintEventHandler(this.paintHandler);
            this.KeyDown += new KeyEventHandler(this.keyDownHandler);
            this.KeyUp += new KeyEventHandler(this.keyUpHandler);

            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.mainTimer.Interval = 30;
            this.mainTimer.Tick += new System.EventHandler(this.gameLoop);
            this.mainTimer.Enabled = true;
            this.mainTimer.Start();

            this.partNumberLabel = new System.Windows.Forms.Label();
            this.partNumberLabel.Location = new System.Drawing.Point(5, 10);
            this.partNumberLabel.Name = "partNumberLabel";
            this.partNumberLabel.ForeColor = Color.White;
            this.partNumberLabel.Size = new System.Drawing.Size(50, 30);
            this.partNumberLabel.Text = "";

            this.healthLabel = new System.Windows.Forms.Label();
            this.healthLabel.Location = new System.Drawing.Point(60, 10);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.ForeColor = Color.White;
            this.healthLabel.Size = new System.Drawing.Size(75, 15);
            this.healthLabel.Text = "";

            this.healLabel = new System.Windows.Forms.Label();
            this.healLabel.Location = new System.Drawing.Point(140, 10);
            this.healLabel.Name = "healLabel";
            this.healLabel.ForeColor = Color.White;
            this.healLabel.Size = new System.Drawing.Size(75, 15);
            this.healLabel.Text = "";

            this.bulletCountLabel = new System.Windows.Forms.Label();
            this.bulletCountLabel.Location = new System.Drawing.Point(215, 10);
            this.bulletCountLabel.Name = "bulletCountLabel";
            this.bulletCountLabel.ForeColor = Color.White;
            this.bulletCountLabel.Size = new System.Drawing.Size(100, 15);
            this.bulletCountLabel.Text = "";

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
            //this.Controls.Add(this.debugLabel);
            this.Controls.Add(this.healLabel);
            this.Controls.Add(this.bulletCountLabel);
        }

        #endregion

        System.Windows.Forms.Label partNumberLabel;
        System.Windows.Forms.Label healthLabel;
        System.Windows.Forms.Label healLabel;
        System.Windows.Forms.Label bulletCountLabel;
        System.Windows.Forms.Timer mainTimer;
        System.Windows.Forms.Label debugLabel;
    }
}
