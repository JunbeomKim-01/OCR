using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace dwqeqw
{
    class Table
    {
        DataTable dataTable;
       public Table()
        {
            this.dataTable = new DataTable();
        }
        public void Add(string parse ,string  transelated)  
        {
            dataTable.Rows.Add(DateTime.Now.ToString("yyyyMMdd"), parse, transelated);
        }
        public DataTable GetTable()
        {
            return dataTable; 
        }

    }
}
