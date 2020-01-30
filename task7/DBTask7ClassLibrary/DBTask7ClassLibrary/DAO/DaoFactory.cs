
namespace DBTask7ClassLibrary.DAO
{
    /// <summary>
    /// Dao factory
    /// </summary>
    public class DaoFactory : IDaoFactory
    {
        private static DaoFactory instance = null;
        private DaoGroups daoGroups = null;
        private DaoSubjects daoSubjects = null;
        private DaoStudents daoStudents = null;
        private DaoSessionExams daoSessionExams = null;
        private DaoSessionResults daoSessionResults = null;

        static string ConnectionString = null;

        private DaoFactory()
        {
        }

        /// <summary>
        /// Create DaoFactory instance
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DaoFactory GetInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new DaoFactory();
                ConnectionString = connectionString;
            }

            return instance;
        }

        /// <summary>
        /// Create DaoGroups instance
        /// </summary>
        /// <returns></returns>
        public DaoGroups GetDaoGroups()
        {
            if (daoGroups == null)
            {
                daoGroups = new DaoGroups(ConnectionString);
            }
            return daoGroups;
        }

        /// <summary>
        /// Create DaoSessionExams instance
        /// </summary>
        /// <returns></returns>
        public DaoSessionExams GetDaoSessExams()
        {
            if (daoSessionExams == null)
            {
                daoSessionExams = new DaoSessionExams(ConnectionString);
            }
            return daoSessionExams;
        }

        /// <summary>
        /// Create DaoSessionResults instance
        /// </summary>
        /// <returns></returns>
        public DaoSessionResults GetDaoSessResults()
        {
            if (daoSessionResults == null)
            {
                daoSessionResults = new DaoSessionResults(ConnectionString);
            }
            return daoSessionResults;
        }

        /// <summary>
        /// Create DaoStudents instance
        /// </summary>
        /// <returns></returns>
        public DaoStudents GetDaoStudents()
        {
            if (daoStudents == null)
            {
                daoStudents = new DaoStudents(ConnectionString);
            }
            return daoStudents;
        }

        /// <summary>
        /// Create DaoSubjects instance
        /// </summary>
        /// <returns></returns>
        public DaoSubjects GetDaoSubjects()
        {
            if (daoSubjects == null)
            {
                daoSubjects = new DaoSubjects(ConnectionString);
            }
            return daoSubjects;
        }
    }
}
