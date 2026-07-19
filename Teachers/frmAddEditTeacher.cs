using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Global_Classes;
using TMS_Business;

namespace TMS.Teachers
{
    public partial class frmAddEditTeacher : Form
    {
        private enum enMode { AddNew, Update};
        private enMode _Mode;

        private int _TeacherID;
        private clsTeacher _Teacher;

        private void _FillMajorsInComboBox()
        {
            foreach(DataRow row in clsMajor.GetAllMajors().Rows)
            {
                cbMajors.Items.Add(row["MajorName"]);
            }
        }

        public frmAddEditTeacher()
        {
            InitializeComponent();

            _TeacherID = -1;
            _Mode = enMode.AddNew;
        }

        public frmAddEditTeacher(int TeacherID)
        {
            InitializeComponent();

            _TeacherID = TeacherID;
            _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditTeacher_Load(object sender, EventArgs e)
        {
            _FillMajorsInComboBox();
            lbCreatedBy.Text = clsGlobal.User.UserName;
            lbEnrollmentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cbMajors.SelectedIndex = 0;

            if(_Mode == enMode.Update)
            {
                lbTitle.Text = "Update Teacher";
                _Teacher = clsTeacher.FindTeacherByTeacherID(this._TeacherID);

                if(_Teacher == null)
                {
                    MessageBox.Show("Could not find Teacher with ID = " + _TeacherID, "Not Found!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    return;
                }

                //incase teacher was found
                ctrlFindPerson1.LoadPersonInfo(_Teacher.PersonID);
                ctrlFindPerson1.FilterEnabled = false;

                lbTeacherID.Text = this._TeacherID.ToString();
                cbMajors.SelectedIndex = cbMajors.FindString(_Teacher.MajorInfo.MajorName);
                txtNotes.Text = (string.IsNullOrEmpty(_Teacher.Notes)) ? "No Notes" : _Teacher.Notes;
                lbCreatedBy.Text = _Teacher.UserInfo.UserName;
                lbEnrollmentDate.Text = _Teacher.CreationDate.ToString("dd/MM/yyyy");

                btnSave.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpTeacherInfo"];
            }
            else
            {
                lbTitle.Text = "Add New Teacher";
                _Teacher = new clsTeacher();
                ctrlFindPerson1.FilterFoucs();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew)
            {
                if(ctrlFindPerson1.SelectedPerson == null)
                {
                    MessageBox.Show("Please Select a person", "Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    return;
                } 
            }

            btnSave.Enabled = true;
            tpPersonInfo.Enabled = true;
            tabControl1.SelectedTab = tabControl1.TabPages["tpTeacherInfo"];
        }

        private void ctrlFindPerson1_OnSelectPerson(int PersonID)
        {
            if(clsTeacher.IsTeacherExistByPersonID(PersonID))
            {
                MessageBox.Show("Selected person is already a teacher.\nSelect another person.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnNext.Enabled = false;
                return;
            }

            if (clsStudent.IsStudentExistByPersonID(PersonID))
            {
                MessageBox.Show("Selected Person with ID = " + PersonID.ToString() +
                     " is already a Student you cannot add a Student as a Teacher.\nSelect another person", "Not Allowed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnNext.Enabled = false;
                return;
            }

            _Teacher.PersonID = PersonID;
            tpPersonInfo.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew)
            {
                _Teacher.CreatedByUserID = clsGlobal.User.UserID;
                _Teacher.CreationDate = DateTime.Now;
            }

            _Teacher.MajorID = clsMajor.Find(cbMajors.Text).MajorID;
            _Teacher.Notes = txtNotes.Text.Trim();

            if(_Teacher.Save())
            {
                lbTeacherID.Text = _Teacher.TeacherID.ToString();
                _TeacherID = _Teacher.TeacherID;
                _Mode = enMode.Update;
                lbTitle.Text = "Update Teacher";
                MessageBox.Show("Data has been saved successfully!", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data didn't saved!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
