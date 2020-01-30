using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary
{
    /// <summary>
    /// Initializes database tables with values
    /// </summary>
    public class DBInitializer
    {
        /// <summary>
        /// Insert groups, subjects, students, exams and results to tables
        /// </summary>
        /// <param name="connectionString"></param>
        public static void InsertData(string connectionString)
        {
            InsertGroups(connectionString);
            InsertSubjects(connectionString);
            InsertStudents(connectionString);
            InsertExams(connectionString);
            InsertResults(connectionString);
        }

        static string[] firstNames = new string[20]
        {
            "Евгений", "Дмитрий", "Ольга", "Светлана", "Петр", "Василий",
            "Константин", "Игорь", "Виктория", "Александр", "Алексей", "Федор",
            "Руслан", "Максим", "Анастасия", "Ангелина", "Андрей", "Владимир", "Сергей", "Ирина"
        };

        static string[] genders = new string[20]
        {
            "муж", "муж", "жен", "жен", "муж", "муж",
            "муж", "муж", "жен", "муж", "муж", "муж", "муж",
            "муж", "жен", "жен", "муж", "муж", "муж", "жен"
        };

        static string[] lastNames = new string[20]
        {
            "Синицин", "Елисеев", "Карась", "Иванов", "Стельченко", "Гумар",
            "Бартновск", "Малиновск", "Гончар", "Шучалин", "Степанов", "Василевск", "Петрушкин",
            "Гаврилов", "Сидоров", "Федоренко", "Петров", "Павленко", "Друзь", "Вакулин"
        };

        static string[] middleNames = new string[20]
        {
            "Евгеньев", "Сергеев", "Андреев", "Алексеев", "Дмитриев", "Константинов",
            "Вячеславов", "Максимов", "Денисов", "Борисов", "Григорьев", "Федоров", "Владимиров",
            "Павлов", "Кириллов", "Игорев", "Петров", "Владиславов", "Валерьев", "Васильев"
        };

        static Dictionary<int, int> exIDgrID = new Dictionary<int, int>();
        static Dictionary<int, int> stIDgrID = new Dictionary<int, int>();

        /// <summary>
        /// Insert students to the table
        /// </summary>
        /// <param name="connectionString"> Connection string</param>
        private static void InsertStudents(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                Random random = new Random();
                SqlCommand command = null;

                connection.Open();

                string lastName = "";
                string firstName = "";
                string middleName = "";
                string gender = "";
                int groupId = 1;

                for (int i = 0; i < 400; i++)
                {
                    int index = random.Next(20);
                    firstName = firstNames[index];
                    gender = genders[index];
                    lastName = lastNames[random.Next(20)];
                    middleName = middleNames[random.Next(20)];

                    if (i % 20 == 0 && i != 0)
                        groupId++;

                    lastName += (gender == "жен" && lastName.Last() == 'в') ? "a" : "";
                    lastName += (gender == "жен" && lastName.Last() == 'н') ? "a" : "";
                    int indx = lastName.Length - 2;
                    lastName += (gender == "жен" && lastName.Substring(indx) == "ск") ? "aя" : "";
                    lastName += (gender == "муж" && lastName.Substring(indx) == "ск") ? "ий" : "";
                    middleName += (gender == "жен") ? "на" : "ич";

                    string query = $"INSERT INTO students (LastName, FirstName, MiddleName, GroupID, Sex, BirthDate) " +
                                    $"VALUES(@LastName, @FirstName, @MiddleName, @GroupID, @Sex, @BirthDate)";

                    stIDgrID.Add((i + 1), groupId);

                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@MiddleName", middleName);
                    command.Parameters.AddWithValue("@GroupID", groupId);
                    command.Parameters.AddWithValue("@Sex", gender);
                    command.Parameters.AddWithValue("@BirthDate", new DateTime(1998, 10, index + 1));
                    command.ExecuteNonQuery();
                }

            }


        }

        static string[] groupNames = new string[5]
        {
            "ИТИ-", "ИТП-", "ЭТ-", "ПР-", "ПС-"
        };

        static string[] specNames = new string[5]
        {
            "Инженер системный программист", "Инженер системный программист",
            "Инженер электрик", "Инженер реконструктор", "Инженер строитель"
        };

        /// <summary>
        /// Insert groups to the table
        /// </summary>
        /// <param name="connectionString"> Connection string</param>
        private static void InsertGroups(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = null;

                connection.Open();

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < groupNames.Length; j++)
                    {
                        string name = groupNames[j] + (i + 1) + 1;
                        string query = "INSERT INTO groups (Name, SpecID) VALUES(@Name, @SpecID)";

                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@SpecID", j + 1);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        static string[] subjectNames = new string[14]
        {
            "Математика", "Физика", "История", "Английский язык", "Экономика", "Программирование",
            "Физическая культура", "Философия", "Начертательная геометрия", "Теоретическая механика",
            "Компьютерные сети", "Политология", "Химия", "Введение в специальность"
        };

        static string[] examTypes = new string[14]
        {
            "экз", "экз", "экз", "экз", "экз", "экз",
            "дет. зач", "экз", "экз", "экз",
            "экз", "дет. зач", "экз", "дет. зач"
        };

        /// <summary>
        /// Insert subjects to the table
        /// </summary>
        /// <param name="connectionString"> Connection string</param>
        private static void InsertSubjects(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = null;

                connection.Open();

                for (int i = 0; i < subjectNames.Length; i++)
                {
                    string query = "INSERT INTO subjects (Name) VALUES(@Name)";

                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", subjectNames[i]);
                    command.ExecuteNonQuery();
                }
            }
        }
        
        /// <summary>
        /// Insert exams to the table
        /// </summary>
        /// <param name="connectionString"> Connection string</param>
        private static void InsertExams(string connectionString)
        {
            int coursCount = 4;
            int studCount = groupNames.Length * firstNames.Length;
            int groupsCount = groupNames.Length * coursCount;
            int subjCount = subjectNames.Length;
            int[] daysBetween = new int[5] { 0, 155, 365, 520, 730 };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                short iter = 0;
                SqlCommand command = null;
                Random rand = new Random();
                connection.Open();

                for (int session = 0; session < 4; session++)
                {
                    for (int i = 0; i < groupsCount; i++)
                    {
                        int examCount = rand.Next(4, 5);
                        int exIndx = rand.Next(subjCount - 1);
                        int dayInterval = 5;

                        for (int j = 1; j <= examCount; j++)
                        {
                            if (exIndx == subjCount - 1)
                                exIndx = 0;

                            int mounth = 1;
                            int day = (i + 1) + j * dayInterval;
                            if (day > 30)
                            {
                                mounth = 2;
                                day = day - 30;
                            }
                            DateTime date = new DateTime(2017, mounth, day);
                            if (session != 0)
                                date = date.Add(new TimeSpan(daysBetween[session], 0, 0, 0));

                            string query = "INSERT INTO sessionexams (GroupID, SubjectID, Type, SessionNumber, Date)" +
                                        "VALUES(@GroupID, @SubjectID, @Type, @SessionNumber, @Date)";

                            iter++;
                            exIDgrID.Add(iter, i + 1);

                            command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@GroupID", i + 1);
                            command.Parameters.AddWithValue("@SubjectID", exIndx + 1);
                            command.Parameters.AddWithValue("@Type", examTypes[exIndx]);
                            command.Parameters.AddWithValue("@SessionNumber", session + 1);
                            command.Parameters.AddWithValue("@Date", date);
                            command.ExecuteNonQuery();

                            exIndx++;
                        }
                        exIndx = 0;
                    }
                }
            }

        }

        /// <summary>
        /// Insert results to the table
        /// </summary>
        /// <param name="connectionString"> Connection string</param>
        private static void InsertResults(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = null;
                Random rand = new Random();
                connection.Open();
                int grade;

                for (int i = 0; i < exIDgrID.Count; i++)
                {
                    var Ids = stIDgrID.Where(x => x.Value.Equals(exIDgrID[i + 1])).Select(x => x.Key);

                    for (int j = 0; j < Ids.Count(); j++)
                    {
                        grade = rand.Next(1, 11);

                        string query = "INSERT INTO sessionresults (StudentID, ExamID, Grade)" +
                                            "VALUES(@StudentID, @ExamID, @Grade)";

                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@StudentID", Ids.ElementAt(j));
                        command.Parameters.AddWithValue("@ExamID", i + 1);
                        command.Parameters.AddWithValue("@Grade", grade);
                        command.ExecuteNonQuery();
                    }

                }
            }


        }
    }
}
