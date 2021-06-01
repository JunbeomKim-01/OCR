using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace dwqeqw
{
    public class SetLanguage
    {
        public static string soursLanuage;
        public static string targetLanguage;
   
       public void SetSoursLanuage(ComboBox cd)
        {
            soursLanuage = cd.SelectedIndex > -1 ? cd.SelectedItem.ToString() : null;
          // MessageBox.Show(soursLanuage);
        }
        public void SetTargetLanuage(ComboBox cd)
        {
            targetLanguage = cd.SelectedIndex > -1 ? cd.SelectedItem.ToString() : null;
           // MessageBox.Show(targetLanguage);
        }
    }
}
