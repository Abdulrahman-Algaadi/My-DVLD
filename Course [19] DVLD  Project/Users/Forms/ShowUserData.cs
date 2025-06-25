using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class ShowUserData : Form
    {
        public ShowUserData(int UserID)
        {
            InitializeComponent();
            clsUser User=clsUser.FindUserByID(UserID);
            ctrShowUserDetails1.LoadData(User);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
