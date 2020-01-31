using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace DBTask7ClassLibrary.ExcelExport
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

            if (reports == null)
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
                if(!fields[i].PropertyType.IsGenericType)
                {
                    workSheet.Cells[1, i + 1] = fields[i].Name;
                }
                else
                {
                    List<double> list = type.GetProperty(fields[i].Name).GetValue(reports[0]) as List<double>;
                    for (int j = 0; j < list.Count; j++)
                    {
                        workSheet.Cells[1, i + 1 + j + 1] = "Session " + (j + 1);
                    }
                }
            }
            
            for (int i = 0; i < reports.Count; i++)
            {
                for (int j = 0; j < fields.Length; j++)
                {
                    if (!fields[j].PropertyType.IsGenericType)
                    {
                        workSheet.Cells[i + 2, j + 1] = type.GetProperty(fields[j].Name).GetValue(reports[i]);
                    }
                    else
                    {
                        List<double> list = type.GetProperty(fields[j].Name).GetValue(reports[i]) as List<double>;
                        for (int x = 0; x < list.Count; x++)
                        {
                            workSheet.Cells[i + 2, j + 1 + x + 1] = list[x];
                        }
                    }
                }
            }

            workBook.SaveAs(finalPath);
            workBook.Close();
            excelApp.Quit();
        }
    }
}
