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

namespace TMS.Courses.Classes.ClassAppointments
{
    public partial class ctrlAppointmentCard : UserControl
    {
        public int AppointmentID;
        public clsClassAppointment SelectedAppointment;

        public ctrlAppointmentCard()
        {
            InitializeComponent();
        }

        public void LoadAppointmentInfo(int AppointmentID)
        {
            this.AppointmentID = AppointmentID;
            this.SelectedAppointment = clsClassAppointment.Find(this.AppointmentID);

            if(this.SelectedAppointment == null)
            {
                MessageBox.Show($"Could not find appointment with ID = {this.AppointmentID}", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbAppointmentID.Text = this.AppointmentID.ToString();
            lbDay.Text = this.SelectedAppointment.DayCaption;
            lbTime.Text = this.SelectedAppointment.StartAt.ToString();
            lbClassID.Text = this.SelectedAppointment.ClassID.ToString();
            lbCreatedBy.Text = this.SelectedAppointment.UserInfo.UserName;
            lbCreationDate.Text = this.SelectedAppointment.CreationDate.ToString("dd/MMM/yyyy");
        }
    }
}
