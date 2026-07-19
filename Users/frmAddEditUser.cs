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
    public partial class frmAddEditUser : Form
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        private int _UserID;
        private clsUser _User;

        public frmAddEditUser()
        {
            InitializeComponent();

            _UserID = -1;
            _Mode = enMode.AddNew;
        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew)
            {
                ctrlFindPerson1.FilterFoucs();
                lbTitle.Text = "Add New User";
                _User = new clsUser();
            }
            else
            {
                _User = clsUser.FindUserByUserID(_UserID);

                if(_User == null)
                {
                    MessageBox.Show("Could not find User with ID = " + _UserID.ToString(),"Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //incase user was found
                lbTitle.Text = "Update User";

                ctrlFindPerson1.LoadPersonInfo(_User.PersonID);
                ctrlFindPerson1.FilterEnabled = false;

                lbUserID.Text = _User.UserID.ToString();
                txtUserName.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                txtConfirmPassword.Text = _User.Password;

                btnSave.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew)
            {
                if(ctrlFindPerson1.SelectedPerson == null)
                {
                    MessageBox.Show("Please select a person","Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (clsUser.IsUserExistByPersonID(_User.PersonID))
                {
                    MessageBox.Show("Selected Person is already user. Select another person", "Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            btnSave.Enabled = true;
            tabControl1.SelectedTab = tabControl1.TabPages["tpUserInfo"];
            txtUserName.Focus();
        }

        private void ctrlFindPerson1_OnSelectPerson(int obj)
        {
            _User.PersonID = obj;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "this field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, null);
            }

            if(txtUserName.Text != _User.UserName)
            {
                if(clsUser.IsUserExistByUserName(txtUserName.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "User name is used by another user\nchoose aonther one");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUserName, null);
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "this field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm password does not match password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are some empty fields please fill them.","Wraning",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chbIsActive.Checked;

            if(_User.Save())
            {
                _UserID = _User.UserID;
                lbTitle.Text = "Update User";
                this._Mode = enMode.Update;
                lbUserID.Text = _User.UserID.ToString();
                MessageBox.Show("Data Saved Successfully", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Dat dit saved","Error!",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
