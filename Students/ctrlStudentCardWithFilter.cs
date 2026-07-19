using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Business;

namespace TMS.Students
{
    public partial class ctrlStudentCardWithFilter : UserControl
    {
        public delegate void OnStudentSelectedEvent(int StudentID);
        public event OnStudentSelectedEvent OnStudentSelected;

        public int StudentID { get { return ctrlStudentCard1.StudentID; } }
        public clsStudent SelectedStudent { get { return ctrlStudentCard1.SelectedStudent; } }
        public bool FilterEnabled { get { return groupBox1.Enabled; }set { groupBox1.Enabled = value; } }

        public void FilterFoucs()
        {
            this.ActiveControl = txtFilterValue;
        }
        public ctrlStudentCardWithFilter()
        {
            InitializeComponent();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFind.PerformClick();

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int StudentID = Convert.ToInt32(txtFilterValue.Text);
            ctrlStudentCard1.LoadStudentInfo(StudentID);

            if (OnStudentSelected != null && FilterEnabled)
                OnStudentSelected?.Invoke(StudentID);
        }

        public void LoadStudentInfo(int StudentID)
        {
            txtFilterValue.Text = StudentID.ToString();
            ctrlStudentCard1.LoadStudentInfo(StudentID);
        }
    }
}
