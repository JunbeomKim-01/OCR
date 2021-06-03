using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
namespace dwqeqw
{
    class Excels:ImageSetter
    {
        static Microsoft.Office.Interop.Excel.Application excelApp = null; 
        static Microsoft.Office.Interop.Excel.Workbook workBook = null; 
        static Microsoft.Office.Interop.Excel.Worksheet workSheet = null;
        Table table;
        string desktopPath;
        string path;

        public Excels(Table table)
        {
            this.table = table;
        } 
      public void Add()
        {
            try
            {
                SetPath();
                excelApp = new Microsoft.Office.Interop.Excel.Application(); // 엑셀 어플리케이션 생성
                workBook = excelApp.Workbooks.Add(); // 워크북 추가
                workSheet = workBook.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel.Worksheet; // 엑셀 첫번째 워크시트 가져오기 workSheet.Cells[1, 1] = "이름"; workSheet.Cells[1, 2] = "종류"; workSheet.Cells[1, 3] = "성별";
                
                workSheet.Cells[1, 1] = "날짜";
                workSheet.Cells[1, 2] = "원문내용";
                workSheet.Cells[1, 3] = "번역내용";
                workSheet.Cells[1, 4] = "원문언어";
                workSheet.Cells[1, 5] = "번역언어";

                for (int i = 0; i < table.dataTable.Rows.Count; ++i)
                    for (int e = 0; e < 5; ++e)
                       workSheet.Cells[2 + i, e+1] = table.dataTable.Rows[i][e];

               workSheet.Columns.AutoFit(); // 열 너비 자동 맞춤
               workBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault); //  엑셀 파일 저장
               workBook.Close(true);
                excelApp.Quit();

            

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ReleaseObject(workSheet); 
                ReleaseObject(workBook);
                ReleaseObject(excelApp);

           
            }
        } 
      static void ReleaseObject(Object ob)// 엑셀 겍체  헤제
        {
            try
            {
                if(ob !=null)
                {
                    Marshal.ReleaseComObject(ob);
                    ob = null;

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        public void SetPath()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // 바탕화면 경로
            string path = Path.Combine(desktopPath, "Exl.xlsx"); // 엑셀 파일 저장 경로
        }
    }
}
