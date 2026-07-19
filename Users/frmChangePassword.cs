using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Business;

namespace TMS.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);

            if(ctrlUserCard1.User == null)
            {
                btnSave.Enabled = false;
                return;
            }

            //incase user was found
            txtCurrentPassword.Text = ctrlUserCard1.User.Password;
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtCurrentPassword.Text != ctrlUserCard1.User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "password you have entered does not match current user's password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "this field is rquired");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "confirm password does not match new password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are some empty fields please fill them.", "Wraning",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ctrlUserCard1.User.Password = txtNewPassword.Text.Trim();
            if(ctrlUserCard1.User.UpdatePassword())
            {
                MessageBox.Show("Password has been changed successfully", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Password has not been changed", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
