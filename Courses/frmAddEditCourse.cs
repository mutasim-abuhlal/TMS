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

namespace TMS.Courses
{
    public partial class frmAddEditCourse : Form
    {
        private enum enMode { AddNew, Update };
        private enMode _Mode;

        private int _CourseID;
        private clsCourse _Course;

        public frmAddEditCourse()
        {
            InitializeComponent();

            _CourseID = -1;
            _Mode = enMode.AddNew;
        }

        public frmAddEditCourse(int CourseID)
        {
            InitializeComponent();

            _CourseID = CourseID;
            _Mode = enMode.Update;
        }

        private void _FillSubjectsInComboBox()
        {
            foreach (DataRow row in clsSubject.GetAllSubjects().Rows)
            {
                cbSubjects.Items.Add(row["SubjectName"]);
            }
        }

        private void frmAddEditCourse_Load(object sender, EventArgs e)
        {
            _FillSubjectsInComboBox();
            cbSubjects.SelectedIndex = 0;

            dtpStart.MinDate = DateTime.Now;
            dtpEnd.MinDate = new DateTime
                (dtpStart.MinDate.Year, dtpStart.MinDate.Month, dtpStart.MinDate.Day + 1,
                dtpStart.MinDate.Hour,dtpStart.MinDate.Minute,dtpStart.MinDate.Second);

            if (_Mode == enMode.Update)
            {
                _Course = clsCourse.Find(_CourseID);

                if (_Course == null)
                {
                    MessageBox.Show("Could not find Course with ID = " + _CourseID.ToString(),
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //incase course was found
                if (DateTime.Compare(_Course.EndDate, dtpStart.MinDate) < 0)
                {
                    MessageBox.Show("Selected course is already out of date.\nYou cannot update any information about it",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                if (DateTime.Compare(_Course.StartDate, dtpStart.MinDate) < 0)
                {
                    dtpStart.MinDate = _Course.StartDate;
                    dtpStart.Value = dtpStart.MinDate;
                }

                ctrlTeacherCardWithFilter1.FindTeacher(_Course.TeacherID);
                lbCourseID.Text = _Course.CourseID.ToString();
                dtpEnd.Value = _Course.EndDate;
                cbSubjects.SelectedIndex = cbSubjects.FindString(_Course.SubjectInfo.SubjectName);
                txtCourseName.Text = _Course.CourseName;

                lbTitle.Text = "Update Course";
                btnSave.Enabled = true;
            }
            else
            {
                lbTitle.Text = "Add New Course";
                _Course = new clsCourse();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (ctrlTeacherCardWithFilter1.Teacher == null)
                {
                    MessageBox.Show("Select a teacher", "Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            tabControl1.SelectedTab = tabControl1.TabPages["tpCourseInfo"];
            btnSave.Enabled = true;
            cbSubjects.Focus();
        }

        private void ctrlTeacherCardWithFilter1_OnTeacherSelected(int TeacherID)
        {
            _Course.TeacherID = TeacherID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are some empty fields please fill them.", "Wraning",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DateTime.Compare(dtpEnd.Value, dtpStart.Value) < 0)
            {
                MessageBox.Show("End Date must be after Start date", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            if (_Mode == enMode.AddNew)
            {
                _Course.CreatedByUserID = clsGlobal.User.UserID;
                _Course.CreationDate = DateTime.Now;
            }

            _Course.SubjectID = clsSubject.Find(cbSubjects.Text).SubjectID;
            _Course.CourseName = txtCourseName.Text.Trim();
            _Course.StartDate = dtpStart.Value;
            _Course.EndDate = dtpEnd.Value;

            if (_Course.Save())
            {
                _CourseID = _Course.CourseID;
                lbCourseID.Text = _CourseID.ToString();
                _Mode = enMode.Update;
                lbTitle.Text = "Update Course";
                MessageBox.Show("Data Saved Successfully!", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data didn't saved!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtCourseName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCourseName, "this field cannot be blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCourseName, null);
            }

            if(clsCourse.IsCourseExist(txtCourseName.Text))
            {
                if(_Mode == enMode.Update)
                {
                    if (_Course.CourseName == txtCourseName.Text)
                        return;
                }

                e.Cancel = true;
                errorProvider1.SetError(txtCourseName, "Please use another name because it's used\nby another course");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCourseName, null);
            }
        }
    }
}
