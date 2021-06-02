﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace dwqeqw
{
    class Table: Opserver
    {
        Subject _subject;
        DataTable dataTable;
        string sourse;
        string target;
       public Table(DataTable dataTable,Subject subject)
        {
            _subject = subject;
            subject.registerObserver(this);
            this.dataTable = dataTable;
        }
        public void AddColumns(string parse)    =>  dataTable.Columns.Add(parse);      
        public void AddRows(string parse ,string  transelated)  => dataTable.Rows.Add(DateTime.Now.ToString("yyyyMMdd"),parse, transelated,sourse,target);
        public DataTable GetTable() => dataTable;
        void Opserver.update(int[] ls) => SetLanguage(ls);
        public void SetLanguage(int[] ls)
        {
            sourse = ls[0] == 0 ? "한국어" : "영어";
            target = ls[1] == 0 ? "한국어" : "영어";
        }   
    }
}
