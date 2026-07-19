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
using TMS.People;

namespace TMS.Students
{
    public partial class ctrlStudentCard : UserControl
    {
        private int _StudentID;
        private clsStudent _Student;

        public int StudentID { get { return _StudentID; } }
        public clsStudent SelectedStudent { get { return _Student; } }

        public ctrlStudentCard()
        {
            InitializeComponent();
        }

        private void _LoadInfo()
        {
            lbStudentID.Text = _StudentID.ToString();
            lbName.Text = _Student.PersonInfo.FullName;
            lbNationalNo.Text = _Student.PersonInfo.NationalNo;
            lbGendor.Text = _Student.PersonInfo.GendorCaption;
            lbEnrollDate.Text = _Student.CreationDate.ToString("dd/MM/yyyy");
            lbNotes.Text = (string.IsNullOrEmpty(_Student.Notes)) ? "No Notes" : _Student.Notes;
            lbAddress.Text = _Student.PersonInfo.Address;
            lbCountry.Text = _Student.PersonInfo.CountryInfo.CountryName;
            lbCreatedBy.Text = _Student.UserInfo.UserName;

            if (!string.IsNullOrEmpty(_Student.PersonInfo.ImagePath))
                pbGendorImage.ImageLocation = _Student.PersonInfo.ImagePath;
            else
                pbPersonImage.Image = (!_Student.PersonInfo.Gendor) ? Resources.Male_512 : Resources.Female_512;
        }

        public void LoadStudentInfo(int StudentID)
        {
            _StudentID = StudentID;
            _Student = clsStudent.FindStudentByStudentID(StudentID);

            if(_Student == null)
            {
                MessageBox.Show("Could not find Student with ID = " + StudentID.ToString(), "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lkbEditPersonInfo.Enabled = false;
                return;
            }

            //incase student was found we will load all student info
            _LoadInfo();
        }

        private void lkbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmAddEditPerson(_Student.PersonID);
            frm.ShowDialog();

            _LoadInfo();
        }
    }
}
