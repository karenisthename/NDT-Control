using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NDT_Control.Data_Classes
{
    public class NDT 
    {
        public string _unit;
        public string _service;
        public string _line;
        public string _train;
        public string _joint;
        public string report;
        public string result;
        public string date;
        public string ndt_type;
        public string _remarks;
        public string _welder;
        public string _active;


        public NDT()
        { }

        public NDT(string Unit, string Service, string Line, string Train, string Joint, string Report, string ReportDate, string Result, string NDT_Type)
        {
            _unit = Unit;
            _service = Service;
            _line = Line;
            _train = Train;
            _joint = Joint;
            report = Report;
            date = ReportDate;
            result = Result;
            ndt_type = NDT_Type;
        }

        public NDT(string Unit, string Service, string Line, string Train, string Joint, string Report, string ReportDate, string Result, string NDT_Type, string remarks)
        {
            _unit = Unit;
            _service = Service;
            _line = Line;
            _train = Train;
            _joint = Joint;
            report = Report;
            date = ReportDate;
            result = Result;
            ndt_type = NDT_Type;
            _remarks = remarks;
        }

        //FOR LOTNUMBERS
        public NDT(string Unit, string Service, string Line, string Train, string Joint, string lotNo)
        {
            _unit = Unit;
            _service = Service;
            _line = Line;
            _train = Train;
            _joint = Joint;
            _remarks = lotNo;
        }

        //FOR WELDERS
        public NDT(string Unit, string Service, string Line, string Train, string Joint, string welder, string Report, string ReportDate, string remarks, int mode)
        {
            _unit = Unit;
            _service = Service;
            _line = Line;
            _train = Train;
            _joint = Joint;
            report = Report;
            date = ReportDate;
            _remarks = remarks;
            _welder = welder;
        }
    }

    public class NDTCollection : Collection<NDT>
    {
        public NDT this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public NDT Add(NDT newNDT)
        {
            this.Items.Add(newNDT);
            return (NDT)this.Items[this.Items.Count -1 ];
        }
    }

    public class NDTListCollection : Collection<NDTCollection>
    {
        public NDTCollection this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public NDTCollection Add(NDTCollection newNDT)
        {
            this.Items.Add(newNDT);
            return (NDTCollection)this.Items[this.Items.Count - 1];
        }
    }


}
