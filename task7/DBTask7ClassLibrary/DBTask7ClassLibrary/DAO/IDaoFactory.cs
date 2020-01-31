using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.DAO
{
    interface IDaoFactory
    {
        DaoGroups GetDaoGroups();
        DaoSubjects GetDaoSubjects();
        DaoStudents GetDaoStudents();
        DaoSessionExams GetDaoSessExams();
        DaoSessionResults GetDaoSessResults();
        DaoExaminators GetDaoExaminators();
        DaoSpecialties GetDaoSpecialties();
    }
}
