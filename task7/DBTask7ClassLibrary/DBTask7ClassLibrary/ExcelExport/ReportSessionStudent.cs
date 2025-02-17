﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.ExcelExport
{
    /// <summary>
    /// Student session report
    /// </summary>
    public class ReportSessionStudent
    {
        /// <summary>
        /// Student last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Student first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Student middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Group Name
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Subject name
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Exam type
        /// </summary>
        public string ExamType { get; set; }

        /// <summary>
        /// Exam grade
        /// </summary>
        public int Grade { get; set; }

    }
}
