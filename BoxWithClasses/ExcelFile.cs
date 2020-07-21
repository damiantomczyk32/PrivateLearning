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
        public void CreateExcelFile(string destinationPath)
        {
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            application.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = application.ActiveSheet;

            if(!string.IsNullOrEmpty(destinationPath))
            {
                try
                {
                    worksheet.SaveAs(destinationPath);
                    application.Quit();
                }
                catch(Exception e)
                {
                    throw new Exception("Exception:\n"+e.Message);
                }
            }
            else
            {
                application.Visible = false;
            }
        }
        public System.Data.DataTable ReadCellByCell(string path)
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
        public void ExportData(System.Data.DataTable table, string destinationPath, string workSheetName, int sheetNumber)
        {
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Open(destinationPath);
            application.DisplayAlerts = false;

            Microsoft.Office.Interop.Excel.Worksheet worksheet = application.Sheets[sheetNumber];
            var data = new object[table.Rows.Count + 1,table.Columns.Count];
            for (int i = 0; i < table.Columns.Count; i++)
                data[0, i] = table.Columns[i].ColumnName;
            for (int i = 0; i < table.Rows.Count; i++)
                for (int j = 0; j < table.Columns.Count; j++)
                    data[i + 1, j] = table.Rows[i][j];
            var startCell = (Range)worksheet.Cells[1, 1];
            var endCell = (Range)worksheet.Cells[table.Rows.Count + 1, table.Columns.Count];
            var writeRange = worksheet.Range[startCell, endCell];

            writeRange.Value2 = data;

            if(!string.IsNullOrEmpty(destinationPath))
            {
                try
                {
                    worksheet.SaveAs(destinationPath);
                    application.Quit();
                }
                catch(Exception e)
                {
                    throw new Exception("Exception:\n" + e.Message);
                }
            }
            else
            {
                application.Visible = true;
            }
        }
        public void ExportCellByCell(System.Data.DataTable table, string destinationPath, string workSheetName)
        {
            try
            {
                if (table == null || table.Columns.Count == 0)
                    throw new Exception("Null or Empty");

                var application = new Microsoft.Office.Interop.Excel.Application();
                application.Visible = false;
                application.DisplayAlerts = false;

                application.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = application.ActiveSheet;
                worksheet.Name = workSheetName;

                for(int i=0; i<table.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = table.Columns[i].ColumnName;
                }

                for(var i=0; i<table.Rows.Count; i++)
                {
                    for(var j=0; j < table.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = table.Rows[i][j];
                    }
                }
                
                if(!string.IsNullOrEmpty(destinationPath))
                {
                    try
                    {
                        worksheet.SaveAs(destinationPath);
                        application.Quit();
                    }
                    catch(Exception e)
                    {
                        throw new Exception("Exception:\n" + e.Message);
                    }
                }
                else
                {
                    application.Visible = true;
                }
            }
            catch(Exception e)
            {
                throw new Exception("Exception:\n" + e.Message);
            }
        }
    }
}
