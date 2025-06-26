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
        public delegate void SendDataBack1(object Sender, string NationalNo);
        public event SendDataBack1 DataBack1;
        public string FilterTextBoxValue
        {
            get => txtFilter.Text;
            set => txtFilter.Text = value;
        }
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAdd.Visible = _ShowAddPerson;
            }
        }
        public void FocusFilter()
        {
            txtFilter.Focus();
        }
        private bool _FilterEnabled =true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
            _FilterEnabled = value;
             groupBox1.Enabled =_FilterEnabled;

            }
        }
        public int PersonID
        {
            get { return _Person_ID; }
            set
            {
                _Person_ID = value;
                txtFilter.Text = _Person_ID.ToString();
            
            }
        }

        clsPerson _Person;
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
               
                    PersonID = int.Parse(txtFilter.Text);
                    _Person = clsPerson.FindPerson(PersonID);
                    DataBack?.Invoke(this, PersonID);
                    break;
        
                case 1:
          
                    NationalNo=txtFilter.Text.Trim();

                    _Person = clsPerson.FindPerson(NationalNo);
                    DataBack1?.Invoke(this, NationalNo);
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
            if (e.KeyChar==(char)13)
            {
                btnSearch.PerformClick();
            }
        }


    }
}
