﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary.DAO
{
    /// <summary>
    /// SessionResults factory
    /// </summary>
    public class DaoSessionResults : Dao<SessionResult>
    {
        /// <summary>
        /// Initializes a new instance of the DaoSessionResults class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public DaoSessionResults(string connectionString) : base(connectionString)
        {

        }
    }
}
