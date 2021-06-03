using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace dwqeqw
{
    class SaveData
    {
        Table Table;
        
        public SaveData(Table table)
        {
            this.Table = table;
        }
        public void Set()
        {
            Excels excels = new Excels(Table);
            excels.Add();
        }
    }
}
