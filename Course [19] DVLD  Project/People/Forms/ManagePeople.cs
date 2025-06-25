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
    public partial class ManagePeople : Form
    {
        private static  DataTable  _dtAllPeople =clsPerson.GetAllPeople();

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "FirstName", "SecondName", "ThirdName", "LastName",
                                "NationalNo","CountryName","Email","Phone","Gendor");


        public ManagePeople()
        {
            InitializeComponent();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            _RefreshPeopleData();
            if (dgvPeople.Rows.Count>0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 100;

                dgvPeople.Columns[1].HeaderText = "First Name";
                dgvPeople.Columns[1].Width = 120;

                dgvPeople.Columns[5].HeaderText = "National No";
                dgvPeople.Columns[5].Width = 120;

            }
            cbFilter.SelectedIndex = 0;


        }
        private void _FillCountriesInComboBox() { 
        DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow Row in dt.Rows)
            {
                cbFilter.Items.Add(Row["CountryName"]);
            }

        }
        private void _RefreshPeopleData()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "FirstName", "SecondName", "ThirdName", "LastName",
                                     "NationalNo", "CountryName", "Email", "Phone", "Gendor");
            dgvPeople.DataSource = _dtPeople;

            lblCountRecord.Text =$"# {dgvPeople.RowCount.ToString()} Records ";
        }
        private void RefreshFilterBy()
            {
                string errormessage = "";
            
                if (cbFilter.SelectedIndex<0)
                {
                    return;
                }
                string ColumnName = "";
                int IndexOfCombo = cbFilter.SelectedIndex;
                switch (IndexOfCombo)
                {
                    case 1:
                        ColumnName = "PersonID";
                        break;
                    case 2:
                        ColumnName = "FirstName";
                            break;
                    case 3:
                        ColumnName = "SecondName";
                        break;
                    case 4:
                        ColumnName = "ThirdName";
                        break;
                    case 5:
                        ColumnName = "LastName";
                        break;

                    case 6:
                        ColumnName = "NationalNo";
                        break;

                    case 7:
                        ColumnName = "CountryName";
                        break;
                    case 8:
                        ColumnName = "Email";
                        break;
                    case 9:
                        ColumnName = "Phone";
                        break;
                    case 10:
                        ColumnName = "Gendor";
                        break;
                }
                string Filter =txtSearchByFilter.Text.Trim();

            if (Filter==""||cbFilter.SelectedIndex==0)
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblCountRecord.Text =_dtPeople.Rows.Count.ToString();
                return;

            }


            if (ColumnName=="PersonID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}",ColumnName,Filter);
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", ColumnName, Filter);
            }

    }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   
        private void txtSearchByFilter_TextChanged(object sender, EventArgs e)
        {
            RefreshFilterBy();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Add_Person_EditForm(-1);
            form.ShowDialog();
            _RefreshPeopleData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm =new ShowDetailForm((int)dgvPeople.CurrentRow.Cells[0].Value);            
            frm.ShowDialog();
            _RefreshPeopleData();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Add_Person_EditForm(-1);
            form.ShowDialog();
            _RefreshPeopleData();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            if (ID > 0)
            {
                Form form = new Add_Person_EditForm(ID);
                form.ShowDialog();
            }
            //else
            //    MessageBox.Show($"The ID Is Mistaken {ID} ,Go Fix Your Code Loser");
            


            _RefreshPeopleData();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RecordToDelete = (int)dgvPeople.CurrentRow.Cells[0].Value;
            if (MessageBox.Show($"Are You Sure To Delete The Record With ID {RecordToDelete}",
                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPerson.DeletePerson("PersonID", RecordToDelete))
                {
                    MessageBox.Show($"The Person With ID {RecordToDelete} IS Deleted Seccussfully .. ");
                }

            }
            else
                MessageBox.Show("Delete Is Canceled .. .");

            _RefreshPeopleData();
           
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                txtSearchByFilter.Visible = false;
                _dtPeople.DefaultView.RowFilter = "";
                lblCountRecord.Text ="# Records : "+_dtPeople.Rows.Count.ToString();
            }
            else
            {
                txtSearchByFilter.Visible = true;
                txtSearchByFilter.Focus();
            }
            txtSearchByFilter.Text = "";
        }
    }
}
