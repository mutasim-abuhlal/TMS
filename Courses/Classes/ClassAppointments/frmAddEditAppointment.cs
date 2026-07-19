using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Global_Classes;
using TMS_Business;

namespace TMS.Courses.Classes.ClassAppointments
{
    public partial class frmAddEditAppointment : Form
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        private int _ClassID;
        private int _AppointmentID;
        private clsClassAppointment _Appointment;

        private int _GetDayNumber(string DayName)
        {
            Dictionary<string,int> MappingDayNameAndNumbers = new Dictionary<string,int>();
            MappingDayNameAndNumbers.Add("Satrday", 0);
            MappingDayNameAndNumbers.Add("Sunday", 1);
            MappingDayNameAndNumbers.Add("Monday", 2);
            MappingDayNameAndNumbers.Add("Thuesday", 3);
            MappingDayNameAndNumbers.Add("Wednesday", 4);
            MappingDayNameAndNumbers.Add("Thursday", 5);
            MappingDayNameAndNumbers.Add("Friday", 6);

            return MappingDayNameAndNumbers[DayName];

        }

        public frmAddEditAppointment(int ClassID)
        {
            InitializeComponent();

            this._ClassID = ClassID;
            this._AppointmentID = -1;

            this._Mode = enMode.AddNew;
        }

        public frmAddEditAppointment(int ClassID,int AppointmentID)
        {
            InitializeComponent();

            this._ClassID = ClassID;
            this._AppointmentID = -1;

            this._Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditAppointment_Load(object sender, EventArgs e)
        {
            cbDays.SelectedIndex = 0;
            lbCreatedBy.Text = clsGlobal.User.UserName;
            lbCreationDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lbClassID.Text = _ClassID.ToString();
            dtpStartAt.Value = DateTime.Now;
            dtpEndAt.Value = dtpStartAt.Value.AddHours(2);

            if (_Mode == enMode.Update)
            {
                lbTitle.Text = "Update Appointment";
                _Appointment = clsClassAppointment.Find(_AppointmentID);

                if(_Appointment == null)
                {
                    MessageBox.Show("Could not find appointment with ID = " + _AppointmentID.ToString());
                    btnSave.Enabled = false;
                    return;
                }

                //incase appointment was found
                lbAppointmentID.Text = _AppointmentID.ToString();
                cbDays.SelectedIndex = cbDays.FindString(_Appointment.DayCaption);
                dtpStartAt.Value = Convert.ToDateTime(new TimeSpan(_Appointment.StartAt.Hours,
                                             _Appointment.StartAt.Minutes,
                                             _Appointment.StartAt.Seconds));
                dtpEndAt.Value = Convert.ToDateTime(new TimeSpan(_Appointment.EndAt.Hours,
                                             _Appointment.EndAt.Minutes,
                                             _Appointment.EndAt.Seconds));
                lbClassID.Text = _ClassID.ToString();
                lbCreatedBy.Text = _Appointment.UserInfo.UserName;
                lbCreationDate.Text = _Appointment.CreationDate.ToString("dd/MM/yyyy");
            }
            else
            {
                lbTitle.Text = "Add New Appointment";
                _Appointment = new clsClassAppointment();
                _Appointment.ClassID = _ClassID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erroe", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsClassAppointment.IsThereAnotherAppointmentAtSameTime(dtpStartAt.Value.TimeOfDay,
                dtpEndAt.Value.TimeOfDay,this._GetDayNumber(cbDays.Text)))
            {
                MessageBox.Show("The Selected time period overlaps with an\nexisiting period.Please choose a different\nstart or end time", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_Mode == enMode.AddNew)
            {
                _Appointment.CreatedByUserID = clsGlobal.User.UserID;
                _Appointment.CreationDate = DateTime.Now;
            }

            _Appointment.Day = Convert.ToByte(cbDays.SelectedIndex);
            _Appointment.StartAt = dtpStartAt.Value.TimeOfDay;
            _Appointment.EndAt = dtpEndAt.Value.TimeOfDay;
            if(_Appointment.Save())
            {
                lbAppointmentID.Text = _Appointment.AppointmentID.ToString();
                _Mode = enMode.Update;
                lbTitle.Text = "Update Appointment";
                _AppointmentID = _Appointment.AppointmentID;
                MessageBox.Show("Data Saved Successfully!", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data didn't save!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dtpStartAt_Validating(object sender, CancelEventArgs e)
        {
            TimeSpan StartAt = dtpStartAt.Value.TimeOfDay;
            TimeSpan MinDate = new TimeSpan(12, 0, 0);
            TimeSpan MaxDate = new TimeSpan(23, 59, 59);


            if (StartAt < MinDate || StartAt > MaxDate)         
            {
                e.Cancel = true;
                errorProvider1.SetError(dtpStartAt,
                    $"Please Enter time between {MinDate} and {MaxDate}");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(dtpStartAt,null);
            }
        }

        private void dtpEndAt_Validating(object sender, CancelEventArgs e)
        {
            TimeSpan EndtAt = dtpEndAt.Value.TimeOfDay;
            TimeSpan MinDate = new TimeSpan(12, 0, 0);
            TimeSpan MaxDate = new TimeSpan(23, 59, 59);


            if (EndtAt < MinDate || EndtAt > MaxDate)
            {
                e.Cancel = true;
                errorProvider1.SetError(dtpEndAt,
                    $"Please Enter time between {MinDate} and {MaxDate}");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(dtpEndAt, null);
            }
        }
    }
}
