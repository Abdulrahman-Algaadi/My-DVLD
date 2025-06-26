using clsLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course__19__DVLD___Project
{
    public partial class ctrFilterAndShowPersonData : UserControl
    {
        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PerosnID)
        {
            Action<int>handler = OnPersonSelected;
            if (handler!=null)
            {
                OnPersonSelected(PerosnID);
            }


        }

        clsPerson _Person;
        int _PersonID = -1;
        public ctrFilterAndShowPersonData()
        {
            InitializeComponent();
        }

        private void txtFilterPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex==0) 
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Cancel the key press
                }
            }

          
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form frm = new Add_Person_EditForm(-1);
            frm.ShowDialog();
            
        }

        public void FilterFocus()
        {
            txtFilterPerson.Focus();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            switch (cbFilter.SelectedIndex)
            {

                case 0:
                    
                    if (clsPerson.IsColumnExists((txtFilterPerson.Text.Trim()), "PersonID"))
                    {
                        _PersonID = int.Parse(txtFilterPerson.Text);
                    }
                    else
                    {
                        MessageBox.Show($"There is No Perosn With ID OF {txtFilterPerson.Text}","Error");
                        return;
                    }
                    break;
                case 1:
                    if (clsPerson.IsColumnExists((txtFilterPerson.Text.Trim()), "NationalNo"))
                    {
                      _Person =clsPerson.FindPerson(txtFilterPerson.Text.Trim());
                  
                    }
                    else
                    {
                        MessageBox.Show($"There is No Perosn With The National No OF  {txtFilterPerson.Text}", "Error");
                        return;
                    }
                    break;

            }

            FindNow();
        }
        private void FindNow()
        {
            if (_PersonID != -1)
            {
                OnPersonSelected(_PersonID);
                ctrShowPersonDetail1.PersonID =_PersonID;
            }
            else
            {
                if (_Person!=null)
                {
                    OnPersonSelected(_Person.PersonID);
                    _PersonID =_Person.PersonID;
                    ctrShowPersonDetail1.PersonID = _PersonID;
                }
            }

            return;
        }
    }
}
