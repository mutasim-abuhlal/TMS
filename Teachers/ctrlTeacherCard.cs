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

namespace TMS.Teachers
{
    public partial class ctrlTeacherCard : UserControl
    {
        private int _TeacherID;
        private clsTeacher _Teacher;

        public int TeacherID { get { return _TeacherID; } }
        public clsTeacher SelectedTeacher { get {return _Teacher; } }

        public ctrlTeacherCard()
        {
            InitializeComponent();
        }

        public void LoadTeacherInfo(int TeacherID)
        {
            _TeacherID = TeacherID;
            _Teacher = clsTeacher.FindTeacherByTeacherID(TeacherID);

            if(_Teacher == null)
            {
                MessageBox.Show("Could not find Teacher wih ID = " + TeacherID.ToString(), "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //incase teacher was found
            lbTeacherID.Text = _TeacherID.ToString();
            lbName.Text = _Teacher.PersonInfo.FullName;
            lbNationalNo.Text = _Teacher.PersonInfo.NationalNo;
            lbGendor.Text = _Teacher.PersonInfo.GendorCaption;
            lbMajor.Text = _Teacher.MajorInfo.MajorName;
            lbNotes.Text = (string.IsNullOrEmpty(_Teacher.Notes)) ? "No Notes" : _Teacher.Notes;
            lbCreatedBy.Text = _Teacher.UserInfo.UserName;
            lbEnrollDate.Text = _Teacher.CreationDate.ToString("dd/MM/yyyy");
            lbCountry.Text = _Teacher.PersonInfo.CountryInfo.CountryName;

            if (!string.IsNullOrEmpty(_Teacher.PersonInfo.ImagePath))
                pbPersonImage.ImageLocation = _Teacher.PersonInfo.ImagePath;
            else
                pbPersonImage.Image = (!_Teacher.PersonInfo.Gendor) ? Resources.Male_512 : Resources.Female_512;

        }
    }
}
