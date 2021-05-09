
namespace NDT_Control
{
    public class ReportDetails
    {
        private string _reportNumber;
        private string _reportDate;
        private string _reportResult;

        public string ReportNumber
        {
            get { return _reportNumber; }
            set { _reportNumber = value; }
        }
        public string ReportDate
        {
            get { return _reportDate; }
            set { _reportDate = value; }
        }
        public string ReportResult
        {
            get { return _reportResult; }
            set { _reportResult = value; }
        }

        public ReportDetails()
        {}
        public ReportDetails(string reportNumber, string reportDate) : this(reportNumber, reportDate,null)
        {

        }
        public ReportDetails(string reportNumber, string reportDate, string reportResult)
        {
            this._reportNumber = reportNumber;
            this._reportDate = reportDate;
            this._reportResult = reportResult;
        }
    }
}
