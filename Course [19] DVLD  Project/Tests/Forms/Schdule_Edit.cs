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
    public partial class Schdule_Edit : Form
    {
        
        private int _AppointmentID=-1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypes.enTestType _TestTypeID;
        public Schdule_Edit(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID, int AppointmentID=-1)
        {
            InitializeComponent();
     
            this.AutoSize = true;    
            _AppointmentID = AppointmentID;
            _TestTypeID = TestTypeID;
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Schdule_Edit_Load(object sender, EventArgs e)
        {
            ctrScheduleTest1.TestTypeID = _TestTypeID;
            ctrScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID,_AppointmentID);
        }
    }
}
