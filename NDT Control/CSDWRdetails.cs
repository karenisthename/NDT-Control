using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NDT_Control
{
    public class CSDWRdetails
    {
        private string unit { get; set; }
        private string service { get; set; }
        private string line { get; set; }
        private string train { get; set; }
        private string joint { get; set; }
        private string lineclass { get; set; }
        private string revision { get; set; }
        private string location { get; set; }
        private string spool { get; set; }
        private string jointtype { get; set; }
        private string dia { get; set; }
        private string sch { get; set; }
        private string itemdesc1 { get; set; }
        private string matgrade1 { get; set; }
        private string heat1 { get; set; }
        private string itemdesc2 { get; set; }
        private string matgrade2 { get; set; }
        private string heat2 { get; set; }
        private string fitupdate { get; set; }
        private string welder1 { get; set; }
        private string welder2 { get; set; }
        private string wps { get; set; }
        private string rod { get; set; }
        private string heatrod { get; set; }
        private string electrode { get; set; }
        private string heatelectrode { get; set; }
        private string cc { get; set; }
        private string olddwr { get; set; }
        private string olddateofweld { get; set; }

        public CSDWRdetails(List<string> dwrdetails)
        {
            unit = dwrdetails[0];
            service = dwrdetails[1];
            line = dwrdetails[2];
            train = dwrdetails[3];
            joint = dwrdetails[4];
            lineclass = dwrdetails[5];
            revision = dwrdetails[6];
            location = dwrdetails[7];
            spool = dwrdetails[8];
            jointtype = dwrdetails[9];
            dia = dwrdetails[10];
            sch = dwrdetails[11];
            itemdesc1 = dwrdetails[12];
            matgrade1 = dwrdetails[13];
            heat1 = dwrdetails[14];
            itemdesc2 = dwrdetails[15];
            matgrade2 = dwrdetails[16];
            heat2 = dwrdetails[17];
            fitupdate = dwrdetails[18];
            welder1 = dwrdetails[19];
            welder2 = dwrdetails[20];
            wps = dwrdetails[21];
            rod = dwrdetails[22];
            heatrod = dwrdetails[23];
            electrode = dwrdetails[24];
            heatelectrode = dwrdetails[25];
            cc = dwrdetails[26];
            olddateofweld = dwrdetails[27];
            olddateofweld = dwrdetails[28];
        }

    }

    public class DWR : Collection<CSDWRdetails>
    {
        public CSDWRdetails this[int ctr]
        {
            get { return this.Items[ctr]; }
            set { this.Items[ctr] = value; }
        }

        new public CSDWRdetails Add(CSDWRdetails newData)
        {
            this.Items.Add(newData);
            return (CSDWRdetails)this.Items[this.Items.Count - 1];
        }

    }
}
