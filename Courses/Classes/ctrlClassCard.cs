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

namespace TMS.Courses.Classes
{ 
    public partial class ctrlClassCard : UserControl
    {
        public int ClassID;
        public clsClass _SelectedClass;

        public ctrlClassCard()
        {
            InitializeComponent();
        }

        public void LoadClassInfo(int ClassID)
        {
            this.ClassID = ClassID;
            _SelectedClass = clsClass.Find(this.ClassID);

            if(_SelectedClass == null)
            {
                MessageBox.Show("Could not find class with ID = " +  this.ClassID.ToString(),"Not Found!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //incase session was found
            lbClassID.Text = _SelectedClass.ClassID.ToString();
            lbCourseName.Text = _SelectedClass.CourseInfo.CourseName;
            lbClassroomID.Text = _SelectedClass.ClassroomID.ToString();
            lbNumberOfStudents.Text = _SelectedClass.NumberOfStudents.ToString();
            lbCreatedBy.Text = _SelectedClass.UserInfo.UserName;
            lbCreationDate.Text = _SelectedClass.CreationDate.ToString("dd/MMM/yyyy");
        }
    }
}
