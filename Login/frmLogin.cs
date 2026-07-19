using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using TMS;
using TMS.Global_Classes;
using TMS_Business;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.Serialization.Json;

namespace TMS.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void _SaveUserCredintial(string userName, string password)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(clsUserCredintialRecord));
            clsUserCredintialRecord userCredintial = new clsUserCredintialRecord { UserName = userName ,Password = password };

            using(TextWriter writer = new StreamWriter("Credintials.xml"))
            {
                xmlSerializer.Serialize(writer, userCredintial);
            }
           
        }

        private clsUserCredintialRecord _ReadUserCredintial()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(clsUserCredintialRecord));
            clsUserCredintialRecord userCredintial = null;

            if (File.Exists("Credintials.xml"))
            {
                using (TextReader reader = new StreamReader("Credintials.xml"))
                {
                    userCredintial = (clsUserCredintialRecord)xmlSerializer.Deserialize(reader);
                    return userCredintial;
                }
            }

            return null;
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox temp = sender as TextBox;

            if(string.IsNullOrEmpty(temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "this field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(temp, null);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if(user == null)
            {
                lbUserMessage.Text = "Invalid Username or Password";
                lbUserMessage.Visible = true;
                return;
            }

            //incase user was found
            if(!user.IsActive)
            {
                lbUserMessage.Text = "this user is not active. contact admin";
                lbUserMessage.Visible = true;
                return;
            }

            if (chbRememberMe.Checked)
                _SaveUserCredintial(user.UserName, user.Password);

            //incase user was found and he is active
            clsGlobal.User = user;
            clsGlobal.User.Login();
            Form frm = new frmMain();
            this.Hide();
            frm.ShowDialog();
            clsGlobal.User.Logout();
            clsGlobal.User = null;
            this.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsUserCredintialRecord userCredintialRecord = _ReadUserCredintial();

            if (userCredintialRecord == null)
            {
                return;
            }
                txtUserName.Text = userCredintialRecord.UserName;
                txtPassword.Text = userCredintialRecord.Password;
        }
    }
}
