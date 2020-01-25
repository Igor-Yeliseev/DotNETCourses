using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary.DAO
{
    public interface IDaoFactory
    {
        DaoGroups GetDaoGroups();
        DaoSubjects GetDaoSubjects();
        DaoStudents GetDaoStudents();
        DaoSessionExams GetDaoSessExams();
        DaoSessionResults GetDaoSessResults();
    }
}
