using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace NDT_Control
{
    public class ExtractExcel
    {
        public string flepath;
        public string classType;


        public ExtractExcel()
        {

            //string fullpath = @"" + filepath.Replace(@"\", "/") + "/" + System.IO.Path.GetFileName(filepath);

            //Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;

            //xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //Excel.Range firstCell = xlWorkSheet.get_Range("A2", "I2");
            //Excel.Range lastCell = xlWorkSheet.Range[xlWorkSheet.PageSetup.PrintArea];
            //Excel.Range worksheetCells = xlWorkSheet.get_Range(firstCell, lastCell);

            //return worksheetCells;


            //if (classType.Equals("NDT"))
            //{

            //    NDT_Control.Data_Classes.NDTCollection NDTdataCollection = new Data_Classes.NDTCollection();

            //    for (int i = 2; i < worksheetCells.Rows.Count + 1; i++)
            //    {
            //        Excel.Range NDT_data = xlWorkSheet.get_Range("A" + i, "I" + i);

            //        if (NDT_data.Value2[1, 1] != null)
            //        {
            //            NDT_Control.Data_Classes.NDT newNDT = new Data_Classes.NDT(Convert.ToString(NDT_data.Value2[1, 1]),
            //                                                                       Convert.ToString(NDT_data.Value2[1, 2]),
            //                                                                       Convert.ToString(NDT_data.Value2[1, 3]),
            //                                                                       Convert.ToString(NDT_data.Value2[1, 4]),
            //                                                                       Convert.ToString(NDT_data.Value2[1, 5]),
            //                                                                       Convert.ToString(NDT_data.Value2[1, 6]),
            //                                                                       Convert.ToString(NDT_data.Value2[1, 7]),
            //                                                                       Convert.ToString(NDT_data.Value2[1, 8]),
            //                                                                       Convert.ToString(NDT_data.Value2[1, 9])
            //                );

            //            NDTdataCollection.Add(newNDT);
            //        }


            //    }

            //    xlWorkBook.Close(0);
            //    xlApp.Quit();

            //    return NDTdataCollection;
            //}
            //else
            //{
            //    return null;
            
            //}

        }

    }



}
