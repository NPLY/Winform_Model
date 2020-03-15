using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace System_Winform_Model.Form_Dir
{
    public partial class Login_Fm : Form
    {

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        StringBuilder exeini = new StringBuilder(255);
        StringBuilder verini = new StringBuilder(255);

        public static string user_id { get; set; }
        public static string user_password { get; set; }
        public static string global_ip { get; set; }
        public static string program_ver { get; set; }
        public static string program_exe { get; set; }

        public Login_Fm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            user_id = UserId.Text.Trim();
            user_password = PassWord.Text.Trim();

        }
        //get Global ip
        private string GetGlobalIP()
        {
            string externalIP = "";
            externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
            externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches(externalIP)[0].ToString();
            return externalIP;
        }

        private void Login_Fm_Shown(object sender, EventArgs e)
        {
            GetPrivateProfileString("ver", "exe", null, exeini, 255, Application.StartupPath + @"\cfg.ini");
            GetPrivateProfileString("ver", "ver", null, verini, 255, Application.StartupPath + @"\cfg.ini");

            program_ver = verini.ToString();
            program_exe = exeini.ToString();
            Version.Text = program_ver;
            global_ip = GetGlobalIP();
        }
        private void exchangeBackColor(object sender, EventArgs e)
        {
           
            if (ActiveControl == UserId)
            {
                UserId.BackColor = Color.Yellow;
   
                PassWord.BackColor = Color.White;
            }
            if (ActiveControl == PassWord)
            {
                UserId.BackColor = Color.White;
 
                PassWord.BackColor = Color.Yellow;
            }
            if (ActiveControl == btnLogin)
            {
                UserId.BackColor = Color.White;

                PassWord.BackColor = Color.White;
            }
        }

        private void exchangeBackColor(object sender, CancelEventArgs e)
        {
            if (ActiveControl == UserId)
            {
                UserId.BackColor = Color.Yellow;
               
                PassWord.BackColor = Color.White;
            }
            if (ActiveControl == PassWord)
            {
                UserId.BackColor = Color.White;
                PassWord.BackColor = Color.Yellow;
            }
            if (ActiveControl == btnLogin)
            {
                UserId.BackColor = Color.White;
                PassWord.BackColor = Color.White;
            }
        }

        private void UserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ActiveControl = PassWord;
            }
        }

        private void PassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    
    }
}
