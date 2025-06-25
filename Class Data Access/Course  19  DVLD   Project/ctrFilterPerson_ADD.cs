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
    public partial class ctrFilterPerson_ADD : UserControl
    {
        public delegate void SendDataBack(object Sender, int ID);
        public event SendDataBack DataBack;
        private int _Person_ID;
        public string FilterTextBoxValue
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public int PersonID
        {
            get { return _Person_ID; }
            set
            {
                _Person_ID = value;
            
            }
        }

        clsBusiness _Person;
        public ctrFilterPerson_ADD()
        {
            InitializeComponent();
          

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add_Person_EditForm frm = new Add_Person_EditForm(-1);

            frm.DataBack2+= DataBackFromAddPerson;
            frm.ShowDialog();
            return;
        }
       private  void DataBackFromAddPerson(object obj ,int ID)
        {
            DataBack?.Invoke(this,ID);
        } 
    
        private void btnSearch_Click(object sender, EventArgs e)
        {
        
          
        
            string NationalNo = "";
            int PersonID = -1;
            
            int IndexOfCombo = cbFilterBy.SelectedIndex;
            switch (IndexOfCombo)
            {
                case 0:
               
                    PersonID = int.Parse(textBox1.Text);
                    _Person = clsBusiness.FindPerson(PersonID);
                    break;
        
                case 1:
          
                    NationalNo=textBox1.Text.Trim();
                    _Person = clsBusiness.FindPerson(NationalNo);
                    break;

            }

            if (_Person!=null)
            {
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show($"There is no Match With To What You are Searching For !!");
            }
        }

        private void ctrFilterPerson_ADD_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex==0)
            {


                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Cancel the key press
                } 
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
