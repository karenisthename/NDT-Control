using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDT_Control
{
    public class PWHTReport
    {
        private ReportDetails _pwht1;
        private ReportDetails _pwht2;
        private ReportDetails _pwht3;
        
        public ReportDetails Pwht1
        {
            get { return _pwht1; }
            set { _pwht1 = value; }
        }
        public ReportDetails Pwht2
        {
            get { return _pwht2; }
            set { _pwht2 = value; }
        }
        public ReportDetails Pwht3
        {
            get { return _pwht3; }
            set { _pwht3 = value; }
        }

        public PWHTReport()
        {
        }
        public PWHTReport(ReportDetails pwht1, ReportDetails pwht2, ReportDetails pwht3)
        {
            this._pwht1 = pwht1;
            this._pwht2 = pwht2;
            this._pwht3 = pwht3;
        }
    }
}
