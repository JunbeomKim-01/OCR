using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace dwqeqw
{
    class BringImage : ImageSetter
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public void SetPath()=>  openFileDialog.InitialDirectory = @"C:\";
        
       public string Set()
        {
            string imgsrc = null;
            SetPath();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                 imgsrc = openFileDialog.FileName;
            return imgsrc;
        }
    }
}
