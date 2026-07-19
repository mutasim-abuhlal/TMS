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
    public partial class ctrlClassCardWithFilter : UserControl
    {
        public int ClassID { get { return ctrlClassCard1.ClassID; } }
        public clsClass SelectedClass { get { return ctrlClassCard1._SelectedClass; } }
        public bool FilterEnabled { get { return groupBox1.Enabled; }
            set {  groupBox1.Enabled = value; } }

        public event Action<int> OnSelectedClass;

        public void FilterFoucs()
        {
            this.ActiveControl = txtFilterValue;
        }

        private void _FindNow(int ClassID)
        {
            ctrlClassCard1.LoadClassInfo(ClassID);
        }

        public ctrlClassCardWithFilter()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int ClassID = Convert.ToInt32(txtFilterValue.Text);
            _FindNow(ClassID);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char 13 means Enter press
            if(e.KeyChar == (char)13)
            {
                btnFind_Click(null, null);
            }

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void LoadClassInfo(int ClassID)
        {
            ctrlClassCard1.LoadClassInfo(ClassID);

            if (OnSelectedClass != null)
                OnSelectedClass?.Invoke(ClassID);
        }
    }
}
