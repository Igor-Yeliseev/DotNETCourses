using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DBClassLibrary
{
    /// <summary>
    /// Initializes database tables with values
    /// </summary>
    public class DBInitializer
    {
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
            "Бартновск", "Малиновск", "Гончар", "Шучалин", "Степанов", "Стефановск", "Петрушкин",
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
        public static void InsertStudents(string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                Random random = new Random();
                MySqlCommand command = null;

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

                    lastName += (gender == "жен" && lastName.Last() == 'в' ) ? "a" : "";
                    lastName += (gender == "жен" && lastName.Last() == 'н' ) ? "a" : "";
                    int indx = lastName.Length - 2;
                    lastName += (gender == "жен" && lastName.Substring(indx) == "cк") ? "aя" : "";
                    lastName += (gender == "муж" && lastName.Substring(indx) == "ск") ? "ий" : "";
                    middleName += (gender == "жен") ? "на" : "ич";
 
                    string query = $"INSERT INTO students (LastName, FirstName, MiddleName, GroupID, Sex, BirthDate) " +
                                    $"VALUES(@LastName, @FirstName, @MiddleName, @GroupID, @Sex, @BirthDate)";

                    stIDgrID.Add((i + 1), groupId);

                    command = new MySqlCommand(query, connection);
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
            "ИТИ-", "ИТП-", "ИП-", "ПР-", "ПС-"
        };

        /// <summary>
        /// Insert groups to the table
        /// </summary>
        /// <param name="connectionString"> Connection string</param>
        public static void InsertGroups(string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = null;

                connection.Open();

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < groupNames.Length; j++)
                    {
                        string name = groupNames[j] + (i+1) + 1;
                        string query = "INSERT INTO groups (Name) VALUES(@Name)";
                        
                        command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Name", name);
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
        public static void InsertSubjects(string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = null;

                connection.Open();

                for (int i = 0; i < subjectNames.Length; i++)
                {
                    string query = "INSERT INTO subjects (Name) VALUES(@Name)";

                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", subjectNames[i]);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Insert exams to the table
        /// </summary>
        /// <param name="connectionString"> Connection string</param>
        public static void InsertExams(string connectionString)
        {
            int coursCount = 4;
            int studCount = groupNames.Length * firstNames.Length;
            int groupsCount = groupNames.Length * coursCount;
            int subjCount = subjectNames.Length;
            int[] daysBetween = new int[5] { 0, 155, 365, 520, 730};

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                short iter = 0;
                MySqlCommand command = null;
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

                            string query = "INSERT INTO sessionexams (GroupID, SubjectID, Type, Date)" +
                                        "VALUES(@GroupID, @SubjectID, @Type, @Date)";

                            iter++;
                            exIDgrID.Add(iter, (short)(i + 1));

                            command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@GroupID", i + 1);
                            command.Parameters.AddWithValue("@SubjectID", exIndx + 1);
                            command.Parameters.AddWithValue("@Type", examTypes[exIndx]);
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
        public static void InsertResults(string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = null;
                Random rand = new Random();
                connection.Open();

                int studID;
                int examID;
                int grade;

                for (int i = 0; i < exIDgrID.Count; i++)
                {

                    for (int j = 0; j < firstNames.Length; j++)
                    {
                        grade = rand.Next(1, 11);

                        string query = "INSERT INTO sessionresults (StudentID, ExamID, Grade)" +
                                            "VALUES(@StudentID, @ExamID, @Grade)";

                        command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@StudentID", 1);
                        command.Parameters.AddWithValue("@ExamID", i + 1);
                        command.Parameters.AddWithValue("@Grade", grade);
                        command.ExecuteNonQuery();
                    }
                    
                }
            }
        }
    }
}
