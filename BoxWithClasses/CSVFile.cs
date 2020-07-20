using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVReader
{
    class CSVFile
    {
        
        public DataTable Read(string path,char separator)
        {
            DataTable dt = new DataTable();
            using(StreamReader reader = new StreamReader(path))
            {
                string[] headers = reader.ReadLine().Split(separator);
                foreach(string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while(!reader.EndOfStream)
                {
                    string[] rows = reader.ReadLine().Split(separator);
                    DataRow dr = dt.NewRow();
                    for(int i = 0; i<headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
