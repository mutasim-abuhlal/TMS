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
    public partial class ctrlClassroomCardWithFilter : UserControl
    {
        public int ClassroomID { get { return ctrlClassroomCard1.ClassroomID; } }
        public clsClassroom SelectedClassroom { get { return ctrlClassroomCard1.SelectedClassroom; } }

        public void FilterFocus()
        {
            this.ActiveControl = txtFilterValue;
        }
        public bool FilterEnabled { get { return groupBox1.Enabled; } set {  groupBox1.Enabled = value; } }

        public delegate void ClassroomSelected(int ClassroomID);
        public event ClassroomSelected OnClassroomSelected;

        public ctrlClassroomCardWithFilter()
        {
            InitializeComponent();
        }

        private void FindNow()
        {
            ctrlClassroomCard1.LoadClassroomInfo(Convert.ToInt32(txtFilterValue.Text));
        }

        public void FindNow(int ClassroomID)
        {
            txtFilterValue.Text = ClassroomID.ToString();
            FindNow();

            if (OnClassroomSelected != null && FilterEnabled)
                OnClassroomSelected?.Invoke(ClassroomID);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindNow();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                if (!string.IsNullOrEmpty(txtFilterValue.Text))
                    FindNow();

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
