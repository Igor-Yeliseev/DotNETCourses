using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.ExcelExport
{
    /// <summary>
    /// The dynamics of changes in the average grade for the subject
    /// </summary>
    public class ReportSessionsSubject
    {
        /// <summary>
        /// Subject name
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Average grade
        /// </summary>
        public List<double> AvgGrades { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ReportSessionsSubject()
        {
            AvgGrades = new List<double>();
        }
    }
}
