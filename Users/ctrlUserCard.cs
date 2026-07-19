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

namespace TMS.Users
{
    public partial class ctrlUserCard : UserControl
    {
        private int _UserID;
        private clsUser _User;

        public int UserID { get { return _UserID; } }
        public clsUser User { get { return _User; } }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUser.FindUserByUserID(UserID);

            if(_User == null)
            {
                MessageBox.Show("Could not find User with ID = " + _UserID.ToString(), "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lbUserID.Text = _UserID.ToString();
            lbUserName.Text = _User.UserName;
            lbIsActive.Text = (_User.IsActive) ? "Yes" : "No";
        }
    }
}
