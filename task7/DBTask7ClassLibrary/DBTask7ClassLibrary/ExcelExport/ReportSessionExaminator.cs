using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.ExcelExport
{
    /// <summary>
    /// Average grade for examinator 
    /// </summary>
    public class ReportSessionExaminator
    {
        /// <summary>
        /// Specialty name
        /// </summary>
        public string ExaminatorName { get; set; }

        /// <summary>
        /// Session number
        /// </summary>
        public int SessionNumber { get; set; }

        /// <summary>
        /// Average grade
        /// </summary>
        public double AvgGrade { get; set; }
    }
}
