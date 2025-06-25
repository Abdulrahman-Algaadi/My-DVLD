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
        
      
  
        public ctrShowUserDetails()
        {
            InitializeComponent();

        }

       public void LoadData(clsUser User)
        {

            ctrShowPersonDetail2.PersonID = User.PersonID;
            
            if (User!=null)
            {
             
                lblUserID.Text = User.UserID.ToString();
                lblUserName.Text = User.UserName.ToString();
                lblIsActive.Text = (Convert.ToBoolean(User.IsActive) == false) ? "No" : "Yes";

            }

        }

      
    }
}
