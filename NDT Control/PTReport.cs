using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDT_Control
{
    public class PTReport
    {
        private ReportDetails _ptReport;

        public ReportDetails PtReport
        {
            get { return _ptReport; }
            set { _ptReport = value; }
        }

        public PTReport()
        {

        }
        public PTReport(ReportDetails ptreport)
        {
            this._ptReport = ptreport;
        }
    }
}
