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
        public ManagePeople()
        {
            InitializeComponent();
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            _RefreshPeopleData();
           
   
        }
        private void _FillCountriesInComboBox() { 
        DataTable dt = clsBusiness.GetAllCountries();
            foreach (DataRow Row in dt.Rows)
            {
                cbFilter.Items.Add(Row["CountryName"]);
            }

        }
        private void _RefreshPeopleData()
        {
           dgvPeople.DataSource= clsBusiness.GetAllPeople();
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
                case 0:
                    ColumnName = "PersonID";
                    break;
                case 1:
                    ColumnName = "FirstName";
                        break;
                case 2:
                    ColumnName = "SecondName";
                    break;
                case 3:
                    ColumnName = "ThirdName";
                    break;
                case 4:
                    ColumnName = "LastName";
                    break;

                case 5:
                    ColumnName = "NationalNo";
                    break;

                case 6:
                    ColumnName = "CountryName";
                    break;
                case 7:
                    ColumnName = "Email";
                    break;
                case 8:
                    ColumnName = "Phone";
                    break;
                case 9:
                    ColumnName = "Gendor";
                    break;





            }
            string Filter =txtSearchByFilter.Text.Trim();
            dgvPeople.DataSource = clsBusiness.FilterBy(ColumnName,Filter,out errormessage);
            if (errormessage!=null)
            {
                MessageBox.Show("The Error Is : "+errormessage);
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
                if (clsBusiness.DeletePerson("PersonID", RecordToDelete))
                {
                    MessageBox.Show($"The Person With ID {RecordToDelete} IS Deleted Seccussfully .. ");
                }

            }
            else
                MessageBox.Show("Delete Is Canceled .. .");

            _RefreshPeopleData();
           
        }
    }
}
