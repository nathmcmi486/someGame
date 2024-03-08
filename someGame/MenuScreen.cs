using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace someGame
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        void exitButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void startButtonClick(object sender, EventArgs e)
        {
            Form1.changeScreen(this, new Game(0));
        }
    }
}
