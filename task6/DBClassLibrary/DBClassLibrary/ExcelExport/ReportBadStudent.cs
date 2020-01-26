using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary
{
    /// <summary>
    ///  Bad student report
    /// </summary>
    public class ReportBadStudent
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
        /// Student gender
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Birth date 
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
