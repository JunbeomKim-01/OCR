using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace dwqeqw
{
    class SaveImage : ImageSetter
    {
        Table Table;
        
        public SaveImage(Table table)
        {
            this.Table = table;
        }
        public void SetPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "저장경로를 지정하세요";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "";
        }
        public void Set()
        {
            Excels excels = new Excels(Table);
            excels.Add();
        }
    }
}
