﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.ExcelExport
{
    /// <summary>
    /// Group session report
    /// </summary>
    public class ReportSessionGroup
    {
        /// <summary>
        /// Group Name
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Min grade
        /// </summary>
        public int MinGrade { get; set; }

        /// <summary>
        /// Max grade
        /// </summary>
        public int MaxGrade { get; set; }

        /// <summary>
        /// Average grade
        /// </summary>
        public double AverageGrade { get; set; }
    }
}
