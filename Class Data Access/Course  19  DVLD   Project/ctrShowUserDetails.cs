using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class ctrShowUserDetails : UserControl
    {
        
        private int _PersonID;
        public delegate void SendDataBack(object obj,clsUser User);
        public event SendDataBack DataBack;
        public int PersonID
        {
            get { return _PersonID; }
            set { 
                _PersonID = value;
              
                 LoadData(_PersonID);
                
           
            }
        }
        clsUser _User;
        public ctrShowUserDetails()
        {
            InitializeComponent();

        }

       private  void LoadData(int Person_ID)
        {
            ctrShowPersonDetail2.PersonID = Person_ID;
            _User = clsUser.FindUserByPersonID(Person_ID);
            if (_User!=null)
            {
                DataBack?.Invoke(this, _User);
                lblUserID.Text = _User.UserID.ToString();
                lblUserName.Text = _User.UserName.ToString();
                lblIsActive.Text = (Convert.ToBoolean(_User.IsActive) == false) ? "No" : "Yes";

            }


        }

        private void ctrShowUserDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
