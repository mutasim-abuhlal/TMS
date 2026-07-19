using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Properties;
using TMS_Business;
using TMS.Global_Classes;
using System.Diagnostics.Eventing.Reader;
using System.IO;

namespace TMS.People
{
    public partial class frmAddEditPerson : Form
    {
        private enum enMode { AddNew, Update};
        private enMode _Mode;

        public delegate void OnAddNewPersonEvent(int PersonID);
        public OnAddNewPersonEvent OnAddNewPerson;

        private int? _PersonID;
        private clsPerson _Person;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _PersonID = null;
            _Mode = enMode.AddNew;
        }

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = enMode.Update;
        }


        private void _FillCountriesInComboBox()
        {
            foreach(DataRow row in clsCountry.GetAllCountries().Rows)
            {
                cbCountries.Items.Add(row["CountryName"].ToString());
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            this._Person = (this._PersonID.HasValue) ? clsPerson.Find(this._PersonID.Value) : null;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            _FillCountriesInComboBox();
            cbCountries.SelectedIndex = cbCountries.FindString("Jordan");

            rbMale.Checked = true;


            if(_Mode == enMode.Update)
            {
                if (_Person == null)
                {
                    MessageBox.Show("Could not find Person with ID = " + this._PersonID, "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lbTitle.Text = "Update Person";

                lbPersonID.Text = this._PersonID?.ToString();
                txtFirst.Text = this._Person.FirstName;
                txtSecond.Text = this._Person.SecondName;
                txtThird.Text = this._Person.ThirdName;
                txtLast.Text = this._Person.LastName;
                txtNationlNo.Text = this._Person.NationalNo;
                dtpDateOfBirth.Value = this._Person.DateOfBirth;
                if (!this._Person.Gendor)
                    rbMale.Checked = true;
                else
                    rbFemale.Checked = true;

                txtPhone.Text = this._Person.Phone;
                txtEmail.Text = this._Person.Email;
                cbCountries.SelectedIndex = cbCountries.FindString(this._Person.CountryInfo.CountryName);
                txtAddress.Text = this._Person.Address;

                if (this._Person.ImagePath != "")
                    pbPersonImage.ImageLocation = this._Person.ImagePath;

                lkbRemove.Visible = lkbRemove.Visible = (pbPersonImage.ImageLocation != null);
            }
            else
            {
                lbTitle.Text = "Add New Person";
                this._Person = new clsPerson();
            }
        }

        private void frmAddEditPerson_Activated(object sender, EventArgs e)
        {
            this.ActiveControl = txtFirst;
        }

        private void lkbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.ImageLocation = openFileDialog1.FileName;
            }

            lkbRemove.Visible = (pbPersonImage.ImageLocation != null);
        }

        private void lbRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pbPersonImage.ImageLocation != null)
            {
                pbPersonImage.ImageLocation = null;
                pbPersonImage.Image = (rbMale.Checked) ? Resources.Male_512 : Resources.Female_512;
            }

            lkbRemove.Visible = (pbPersonImage.ImageLocation != null);
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtTemp = sender as TextBox;

            if(string.IsNullOrEmpty(txtTemp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTemp, "this field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTemp, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(!clsValidation.IsValidEmail(txtEmail.Text) && !string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "invalid email format");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtNationlNo_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNationlNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationlNo, "this field is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationlNo, null);
            }
            
            if(this._Person != null)
            {
                if(this._Person.NationalNo != txtNationlNo.Text)
                {
                    if (clsPerson.IsPersonExist(txtNationlNo.Text))
                    {

                        e.Cancel = true;
                        errorProvider1.SetError(txtNationlNo, "this National No is used by another person.\nPlease choose another one");
                    }
                    else
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtNationlNo, null);
                    }
                }
            }
        }

        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                try
                {
                    if (_Person.ImagePath != "")
                    {
                        File.Delete(_Person.ImagePath);
                    }
                }
                catch
                {
                    MessageBox.Show("Somthing went wrong while deleting the image", "Cannot Delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (pbPersonImage.ImageLocation != null)
            {
                string NewImagePath = pbPersonImage.ImageLocation;
                if (clsUtil.CopyImageToFolderImages(ref NewImagePath))
                {
                    pbPersonImage.ImageLocation = NewImagePath;
                    return true;
                }
                else
                    return false;

            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are some empty fields please fill them.", "Wraning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_HandlePersonImage())
                return;

            _Person.NationalNo = txtNationlNo.Text;
            _Person.FirstName = txtFirst.Text;
            _Person.SecondName = txtSecond.Text;
            _Person.ThirdName = txtThird.Text;
            _Person.LastName = txtLast.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gendor = (rbMale.Checked) ? false : true;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.NationalityCountryID = clsCountry.Find(cbCountries.Text).CountryID;
            _Person.Address = txtAddress.Text;
            _Person.ImagePath = pbPersonImage.ImageLocation;

            if(_Person.Save())
            {
                _PersonID = _Person.PersonID;
                lbTitle.Text = "Update Person";
                this._Mode = enMode.Update;
                lbPersonID.Text = _Person.PersonID.ToString();

                MessageBox.Show("Data Saved Successfully", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data did save", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (OnAddNewPerson != null)
                OnAddNewPerson(this._PersonID.Value);
        }
        }
    }

