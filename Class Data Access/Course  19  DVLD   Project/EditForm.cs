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
    public partial class ShowDetailForm : Form
    {
      
        public ShowDetailForm(int PersonID)
        {
            InitializeComponent();
         
              ctrShowPersonDetail1.PersonID = PersonID;
            ctrShowPersonDetail1.LoadPersonData();
        }

       
    }
}
