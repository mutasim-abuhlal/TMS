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

namespace TMS.People
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        private clsPerson _Person;

        public int PersonID { get { return this._PersonID; } }
        public clsPerson SelectedPerson { get { return this._Person; } }    

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void LoadInfo()
        {
            lbPersonID.Text = _Person.PersonID.ToString();
            lbName.Text = _Person.FullName;
            lbNationalNo.Text = _Person.NationalNo;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToString("dd/MMM/yyyy");
            lbGendor.Text = _Person.GendorCaption;
            pbGendorImage.Image = (!_Person.Gendor) ? Resources.Man_32 : Resources.Woman_32;
            lbEmail.Text = (string.IsNullOrEmpty(_Person.Email)) ? "Not Set" : _Person.Email;
            lbPhone.Text = _Person.Phone;
            lbAddress.Text = _Person.Address;
            lbCountry.Text = _Person.CountryInfo.CountryName;
            if (_Person.ImagePath != "")
                pbPersonImage.ImageLocation = _Person.ImagePath;
        }

        public void LoadPersonInfo(int PersonID)
        {
            this._PersonID = PersonID;
            this._Person = clsPerson.Find(PersonID);

            if(this._Person == null)
            {
                MessageBox.Show("Could not find Person with ID = " + PersonID.ToString(), "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //incase person was found

            LoadInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            this._Person = clsPerson.Find(NationalNo);
           

            if (this._Person == null)
            {
                MessageBox.Show("Could not find Person with National No = " + NationalNo.ToString(), "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //incase person was found

            this._PersonID = _Person.PersonID;
            LoadInfo();
        }
    }
}
