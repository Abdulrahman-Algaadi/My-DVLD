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
    public partial class Add_Person_EditForm : Form
    {
        public delegate void SendDataBack(object Sender, int ID);
        public event SendDataBack DataBack2;
        public int Person_ID {  get; set; }
        public Add_Person_EditForm(int PersonID)
        {
            InitializeComponent();
            ctrAddNewPerson2.PersonID = PersonID;
            ctrAddNewPerson2.DataBack +=DataBackFromAddUser ;
        }

      private void DataBackFromAddUser(object obj ,int ID)
        {
            Person_ID= ID;
            DataBack2?.Invoke(this,Person_ID);
        }
       
    }
}
