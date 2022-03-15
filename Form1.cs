using System;
using System.Text;
using System.Windows.Forms;

namespace Password_Generator
{
    public partial class Form1 : Form
    {
        #region UI

        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            RadioLength08.Checked = true;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            RadioLength16.Checked = true;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            RadioLength20.Checked = true;
        }

        #endregion

        #region PasswordGenerator

        public void CodeParthGeneratedPassword(int Length)
        {
            const string PasswordCharacters = "abcdefghijklmnopqrstuvwxyz"+"ABCDEFGHIJKLMNOPQRSTUVWXYZ"+"0123456789"+"!@#$%&()?";
            StringBuilder GeneratedPassword = new StringBuilder();
            Random Pass = new Random();
            while (0 < Length--)
            {
                GeneratedPassword.Append(PasswordCharacters[Pass.Next(PasswordCharacters.Length)]);
            }
            GeneratedPasswordBox.Text = GeneratedPassword.ToString();
        }
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GeneratedPasswordBox.Text);
            GeneratedPasswordBox.Text = null;
        }
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (RadioLength08.Checked == true)
            {
                CodeParthGeneratedPassword(8);
            }
            else if (RadioLength16.Checked == true)
            {
                CodeParthGeneratedPassword(16);
            }
            else if (RadioLength20.Checked == true)
            {
                CodeParthGeneratedPassword(20);
            }
            else
            {

            }
        }

        #endregion

        #region TrayIcon

        private void Form1_Load(object sender, EventArgs e)
        {
            var desktopWorkingArea = Screen.PrimaryScreen.WorkingArea;
            this.Left = desktopWorkingArea.Right - 415;
            this.Top = desktopWorkingArea.Bottom - 215;
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                TrayIcon.Visible = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}