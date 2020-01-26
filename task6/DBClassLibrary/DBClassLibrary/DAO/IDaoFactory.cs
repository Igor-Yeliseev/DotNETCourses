
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
