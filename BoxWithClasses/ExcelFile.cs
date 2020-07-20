using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Data;

namespace CSVReader
{
    class ExcelFile
    {
        public System.Data.DataTable Read(string path)
        {
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Open(path);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];

            int rows = worksheet.UsedRange.Rows.Count;
            int columns = worksheet.UsedRange.Columns.Count;
            System.Data.DataTable table = new System.Data.DataTable();
            int NFR = 1;
            

            for(int c = 1; c<=columns; c++)
            {
                string colName = worksheet.Cells[1, c].Text;
                table.Columns.Add(colName);
                NFR = 2;
            }
            for(int r = NFR; r<=rows;r++)
            {
                DataRow dr = table.NewRow();
                for(int c = 1; c<=columns; c++)
                {
                    dr[c - 1] = worksheet.Cells[r, c].Text;
                }
                table.Rows.Add(dr);
            }
            workbook.Close();
            application.Quit();
            return table;
        }
    }
}
