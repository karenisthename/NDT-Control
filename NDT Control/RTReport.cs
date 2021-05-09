using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDT_Control
{
    public class RTReport 
    {
        private ReportDetails rt1Report;
        private ReportDetails rt2Report;
        private ReportDetails rt3Report;
        private ReportDetails reshoot1Report;
        private ReportDetails reshoot2Report;
        
        public ReportDetails Rt1Report
        {
            get { return rt1Report; }
            set { rt1Report = value; }
        }
        public ReportDetails Rt2Report
        {
            get { return rt2Report; }
            set { rt2Report = value; }
        }
        public ReportDetails Rt3Report
        {
            get { return rt3Report; }
            set { rt3Report = value; }
        }
        public ReportDetails Reshoot1Report
        {
            get { return reshoot1Report; }
            set { reshoot1Report = value; }
        }
        public ReportDetails Reshoot2Report
        {
            get { return reshoot2Report; }
            set { reshoot2Report = value; }
        }      

        public RTReport()
        { }
        public RTReport(ReportDetails rt1, ReportDetails rt2, ReportDetails rt3) : this(rt1,rt2,rt3,null,null){}
        public RTReport(ReportDetails rt1, ReportDetails rt2, ReportDetails rt3, ReportDetails reshoot1, ReportDetails reshoot2)
        {
            this.Rt1Report = rt1;
            this.Rt2Report = rt2;
            this.Rt3Report = rt3;
            this.Reshoot1Report = reshoot1;
            this.Reshoot2Report = reshoot2;
        }
    }
}
