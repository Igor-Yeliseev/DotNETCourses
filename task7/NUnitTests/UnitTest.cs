using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    /// <summary>
    /// Unit tests class
    /// </summary>
    [TestFixture]
    public class UnitTest
    {
        string connectionString = null;

        /// <summary>
        /// Initializes a new instance of the UnitTest class
        /// </summary>
        public UnitTest()
        {
            connectionString = ConfigurationManager.ConnectionStrings["task7ConnectionString"].ConnectionString;
            
        }

        /// <summary>
        /// Testing CRUD operations for SessionExams factory
        /// </summary>
        [Test]
        public void TestDaoSessionExamsCRUD()
        {

        }
    }
}
