using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS.Courses.Classes.ClassAppointments
{
    public partial class frmAppointmentDetails : Form
    {
        private int _AppointmentID;
        public frmAppointmentDetails(int appointmentID)
        {
            InitializeComponent();
            _AppointmentID = appointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAppointmentDetails_Load(object sender, EventArgs e)
        {
            ctrlAppointmentCard1.LoadAppointmentInfo(_AppointmentID);
        }
    }
}
