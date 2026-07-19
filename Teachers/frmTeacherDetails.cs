using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS.Teachers
{
    public partial class frmTeacherDetails : Form
    {
        private int _TeacherID;

        public frmTeacherDetails(int TeacherID)
        {
            InitializeComponent();

            _TeacherID = TeacherID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTeacherDetails_Load(object sender, EventArgs e)
        {
            ctrlTeacherCard1.LoadTeacherInfo(_TeacherID);
        }
    }
}
