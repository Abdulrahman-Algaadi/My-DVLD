using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__19__DVLD___Project
{
    public  class clsLogger
    {
        public delegate void Logger(string Messae);

        private Logger _loggerAction;
        public clsLogger(Logger loggerAction)
        {
            _loggerAction = loggerAction;
        }

        public void Log(string Message)
        {
            _loggerAction(Message);
        }
    }
}
