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

namespace TMS.Courses.Classrooms
{
    public partial class ctrlClassroomCard : UserControl
    {
        private int _ClassroomID;
        private clsClassroom _Classroom;

        public int ClassroomID { get { return _ClassroomID; } }
        public clsClassroom SelectedClassroom { get { return _Classroom; } }

        public ctrlClassroomCard()
        {
            InitializeComponent();
        }

        public void LoadClassroomInfo(int ClassroomID)
        {
            _ClassroomID = ClassroomID;
            _Classroom = clsClassroom.Find(_ClassroomID);

            if(_Classroom == null)
            {
                MessageBox.Show("Could not find classroom with ID = " + _ClassroomID.ToString()
                    + "\nSelect another one!", "Not Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            //incase classrooom was found
            lbClassroomID.Text = _ClassroomID.ToString();
            lbMaxNumberOfStudents.Text = _Classroom.MaxNumberOfStudents.ToString();
            
        }
    }
}
