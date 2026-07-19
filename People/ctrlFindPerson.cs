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

namespace TMS.People
{
    public partial class ctrlFindPerson : UserControl
    {
        private int _PersonID;
     
        public clsPerson SelectedPerson { get { return ctrlPersonCard1.SelectedPerson; } }

        public bool FilterEnabled { get { return gbFilter.Enabled; }set { gbFilter.Enabled = value; } }

        public void FilterFoucs()
        {
            this.ActiveControl = txtFilterValue;
        }

        public event Action<int> OnSelectPerson;

        public ctrlFindPerson()
        {
            InitializeComponent();
        }

        private void _FindNow()
        {
           switch(cbFilterBy.Text)
            {
                case "National No":
                    ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text);
                    break;
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(Convert.ToInt32(txtFilterValue.Text));
                    break;
            }

            this._PersonID = ctrlPersonCard1.PersonID;

            if (ctrlPersonCard1.SelectedPerson != null && FilterEnabled)
                OnSelectPerson?.Invoke(this._PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            ctrlPersonCard1.LoadPersonInfo(PersonID);
            txtFilterValue.Text = PersonID.ToString();
            cbFilterBy.SelectedIndex = 1;
            this._PersonID = PersonID;
        }

        public void LoadPersonInfo(string NationalNo)
        {
            ctrlPersonCard1.LoadPersonInfo(NationalNo);
            txtFilterValue.Text = NationalNo;
            cbFilterBy.SelectedIndex = 0;
            this._PersonID = ctrlPersonCard1.PersonID;
        }

        private void ctrlFindPerson_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _FindNow();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
                return;
            }

            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.OnAddNewPerson += AddNewPersonEvent;

            frm.ShowDialog();
        }

        private void AddNewPersonEvent(int PersonID)
        {
            this._PersonID = PersonID;
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            LoadPersonInfo(PersonID);
        }
    }
}
