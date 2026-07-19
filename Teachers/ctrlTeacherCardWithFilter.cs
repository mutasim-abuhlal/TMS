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

namespace TMS.Teachers
{
    public partial class ctrlTeacherCardWithFilter : UserControl
    {
        public  delegate void TeacherSelected(int TeacherID);
        public event TeacherSelected OnTeacherSelected;

        public int TeacherID { get { return ctrlTeacherCard1.TeacherID; } }
        public clsTeacher Teacher { get { return ctrlTeacherCard1.SelectedTeacher; } }
        public bool FilterEnabled { get { return groupBox1.Enabled; } set { groupBox1.Enabled = value; } }

        public void FilterFoucs()
        {
            this.ActiveControl = txtFilterValue;
        }

        public ctrlTeacherCardWithFilter()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int TeacherID = Convert.ToInt32(txtFilterValue.Text);

            ctrlTeacherCard1.LoadTeacherInfo(TeacherID);

            if (OnTeacherSelected != null && FilterEnabled)
                OnTeacherSelected?.Invoke(TeacherID);
        }

        public void FindTeacher(int TeacherID)
        {
            FilterEnabled = false;
            txtFilterValue.Text = TeacherID.ToString();
            ctrlTeacherCard1.LoadTeacherInfo(TeacherID);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
