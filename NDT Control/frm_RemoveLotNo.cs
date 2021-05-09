using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NDT_Control
{
    public partial class frm_RemoveLotNo : MetroForm
    {
        public frm_RemoveLotNo()
        {
            InitializeComponent();
            //Utilities.DTtoCmb(Utilities.GetDBData("SELECT DISTINCT replace(Subcontractor,'2','') as Subcontractor FROM WelderList ORDER BY Subcontractor"), cmb_subc);
        }

        private void btn_lotnum_upload_Click(object sender, EventArgs e)
        {
            string subc = "";

            if (cmb_subc.SelectedItem.Equals("ABJ"))
            {
                subc = "AJ";            
            }
            else if (cmb_subc.SelectedItem.Equals("NSH"))
            {
                subc = "N";  
            }
            else if (cmb_subc.SelectedItem.Equals("ELECO"))
            {
                subc = "EL";  
            }
            else if (cmb_subc.SelectedItem.Equals("SINOPEC"))
            {
                subc = "H";  
            }

            try
            {
                Utilities.PerformSQLQuery("update joints set BatchNum = '' where welder1 like '"+ subc +"%'");
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
