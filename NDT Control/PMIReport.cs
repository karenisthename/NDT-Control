using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDT_Control
{
    public class PMIReport
    {
        private ReportDetails _pmiReport;

        public ReportDetails PmiReport
        {
            get { return _pmiReport; }
            set { _pmiReport = value; }
        }

        public PMIReport()
        { }
        public PMIReport(ReportDetails pmireport)
        {
            _pmiReport = pmireport;
        }
    }
}
