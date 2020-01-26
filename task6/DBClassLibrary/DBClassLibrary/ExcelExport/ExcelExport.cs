using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace DBClassLibrary
{
    /// <summary>
    /// Class for saving tables in Excel
    /// </summary>
    public class ExcelExport
    {
        /// <summary>
        /// Save reports to Excel tables
        /// </summary>
        /// <typeparam name="T"> Report type</typeparam>
        /// <param name="filePath"> File path</param>
        /// <param name="fileName"> File name</param>
        /// <param name="reports"> reports list</param>
        public static void SaveToXlsx<T>(string filePath, string fileName, List<T> reports)
        {
            string finalPath = filePath + fileName;
            
            if(reports == null)
            {
                throw new ArgumentNullException();
            }

            var excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = workBook.Sheets[1];

            Type type = typeof(T);
            PropertyInfo[] fields = type.GetProperties();

            for (int i = 0; i < fields.Length; i++)
            {
                workSheet.Cells[1, i + 1] = fields[i].Name;
            }
            
            var dss = type.GetProperty(fields[0].Name).GetValue(reports[0]);

            for (int i = 0; i < reports.Count; i++)
            {
                for (int j = 0; j < fields.Length; j++)
                {
                    workSheet.Cells[i + 2, j + 1] = type.GetProperty(fields[j].Name).GetValue(reports[i]); ;
                }
            }
            
            workBook.SaveAs(finalPath);
            workBook.Close();
            excelApp.Quit();
        }
    }
}
