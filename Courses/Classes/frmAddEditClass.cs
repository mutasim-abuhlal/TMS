using System;
using System.Windows.Forms;
using TMS.Global_Classes;
using TMS_Business;

namespace TMS.Courses.Classes
{
    public partial class frmAddEditClass : Form
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        private int _CourseID;
        private int _ClassID;

        private clsClass _Class;

        public frmAddEditClass(int CourseID)
        {
            InitializeComponent();

            this._CourseID = CourseID;
            this._ClassID = -1;

            this._Mode = enMode.AddNew;
        }

        public frmAddEditClass(int CourseID,int ClassID)
        {
            InitializeComponent();

            this._CourseID = CourseID;
            this._ClassID = ClassID;

            this._Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditClass_Load(object sender, EventArgs e)
        {
            ctrlCourseCardWithFilter1.FilterEnabled = false;
            ctrlCourseCardWithFilter1.LoadCourseInfo(_CourseID);

            lbCreatedBy.Text = clsGlobal.User.UserName;
            lbCreationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");

            if(_Mode == enMode.Update)
            {
                lbTitle.Text = "Update Class";
                _Class = clsClass.Find(_ClassID);

                if(_Class == null)
                {
                    MessageBox.Show("There's no Class with ID = " + _ClassID.ToString(), "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    return;
                }

                //incase session was found
                ctrlClassroomCardWithFilter1.FindNow(_Class.ClassroomID);
                lbSessionID.Text = _ClassID.ToString();
                lbCreatedBy.Text = _Class.UserInfo.UserName;
                lbCreationDate.Text = _Class.CreationDate.ToString("dd/MMM/yyyy");
                btnSave.Enabled = true;
            }
            else
            {
                lbTitle.Text = "Add New Class";
                _Class = new clsClass();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew)
            {
                _Class.CreatedByUserID = clsGlobal.User.UserID;
                _Class.CreationDate = DateTime.Now;
            }

            _Class.CourseID = _CourseID;
            _Class.ClassroomID = ctrlClassroomCardWithFilter1.ClassroomID;
            if (_Class.Save())
            {
                lbSessionID.Text = _Class.ClassID.ToString();
                _ClassID = _Class.ClassID;
                lbTitle.Text = "Update Class";
                MessageBox.Show("Data saved succesffully!", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data did not saved",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClassroomInfoNext_Click(object sender, EventArgs e)
        {
            if(ctrlClassroomCardWithFilter1.SelectedClassroom == null)
            {
                MessageBox.Show("Please select a classroom", "Confirm",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            //if you reach at this point that means classroom was found
            //so we have to check that classroom we found is full or not
            

            tabControl1.SelectedTab = tabControl1.TabPages["tpClassInfo"];
            btnSave.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["tpClassroomInfo"];
        }
    }
}
