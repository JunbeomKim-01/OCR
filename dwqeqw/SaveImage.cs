using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace dwqeqw
{
    class SaveImage
    {
        Table Table;
        
        public SaveImage(Table table)
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
