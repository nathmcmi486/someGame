namespace someGame
{
    public partial class Form1 : Form
    {
        public static bool keydown = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            changeScreen(this, new MenuScreen());
        }

        public static void changeScreen(UserControl currentScreen, UserControl newScreen)
        {
            Form f = currentScreen.FindForm();
            f.Controls.Remove(currentScreen);

            newScreen.Location = new Point((f.ClientSize.Width - newScreen.Width) / 2, (f.ClientSize.Height - newScreen.Height) / 2);
            newScreen.Focus();
            f.Controls.Add(newScreen);
        }

        public static void changeScreen(Form currentForm, UserControl newScreen)
        {
            Form f = currentForm.FindForm();
            f.Controls.Remove(currentForm);

            newScreen.Location = new Point((f.ClientSize.Width - newScreen.Width) / 2, (f.ClientSize.Height - newScreen.Height) / 2);
            newScreen.Focus();
            f.Controls.Add(newScreen);
        }

        public void keyDownHandler(object sender, KeyEventArgs e)
        {
            keydown = true;
        }
    }
}