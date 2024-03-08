namespace someGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            changeScreen(this, new MenuScreen());
        }

        public static void changeScreen(UserControl currentScreen, UserControl newScreen)
        {
            Form f = currentScreen.FindForm();
            f.Controls.Remove(currentScreen);
            f.ActiveControl = null;

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
    }
}