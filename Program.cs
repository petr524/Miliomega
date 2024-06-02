using MySql.Data.MySqlClient;
namespace pvrocnikovka
{
    public class Program
    {
        static void Register(UserManager userManager)
        {
            Console.Write("Zadejte nové uživatelské jméno: ");
            string username = Console.ReadLine();
            Console.Write("Zadejte nové heslo: ");
            string password = Console.ReadLine();
            if (userManager.Register(username, password))
            {
                Console.WriteLine("Registrace byla úspěšná.");
            }
            else
            {
                Console.WriteLine("Uživatelské jméno již existuje nebo došlo k chybě.");
            }
        }
        static void Main(string[] args)
        {
            string server = "localhost";
            string database = "pv";
            string user = "root";
            string password = "root";

            DatabaseConnect dbConnect = new DatabaseConnect(server, database, user, password);

            // Test the connection
            dbConnect.TestConnection();

            // Execute a query
            string query = "SELECT * FROM user";
            dbConnect.ExecuteQuery(query);
            UserManager userManager = new UserManager(dbConnect);
            Register(userManager);

            TaskManager taskManager = new TaskManager();
            ClassManager classManager = new ClassManager();
            GradeManager gradeManager = new GradeManager();
            ClassroomManager classroomManager = new ClassroomManager();
            MessageManager messageManager = new MessageManager();
            SubjectManager subjectManager = new SubjectManager();
            ScheduleManager scheduleManager = new ScheduleManager();
            ProfileManager profileManager = new ProfileManager();
            NotificationManager notificationManager = new NotificationManager();
            Statistics statistics = new Statistics(taskManager, gradeManager);
            AttendanceManager attendanceManager = new AttendanceManager();
            HomeworkManager homeworkManager = new HomeworkManager();


            // Načtení dat ze souboru
            taskManager.LoadTasksFromFile("tasks.txt");
            gradeManager.LoadGradesFromFile("grades.txt");
            classroomManager.LoadClassroomsFromFile("classrooms.txt");
            messageManager.LoadMessagesFromFile("messages.txt");
            subjectManager.LoadSubjectsFromFile("subjects.txt");
            scheduleManager.LoadSchedulesFromFile("schedules.txt");
            profileManager.LoadProfilesFromFile("profiles.txt");
            notificationManager.LoadNotificationsFromFile("notifications.txt");
            attendanceManager.LoadAttendanceFromFile("attendance.txt");
            homeworkManager.LoadHomeworksFromFile("homeworks.txt");

            User loggedInUser = Login(userManager);

            if (loggedInUser is Teacher)
            {
                Teacher teacher = (Teacher)loggedInUser;
                Console.WriteLine($"Přihlášen učitel: {teacher.FirstName} {teacher.LastName}");
                Console.WriteLine("Vyberte akci:");
                Console.WriteLine("1. Přidat nový úkol");
                Console.WriteLine("2. Zobrazit úkoly");
                Console.WriteLine("3. Označit úkol jako dokončený");
                Console.WriteLine("4. Uložit úkoly do souboru");
                Console.WriteLine("5. Přidat novou učebnu");
                Console.WriteLine("6. Zobrazit učebny");
                Console.WriteLine("7. Uložit učebny do souboru");
                Console.WriteLine("8. Odeslat zprávu");
                Console.WriteLine("9. Označit zprávu jako přečtenou");
                Console.WriteLine("10. Přidat nový předmět");
                Console.WriteLine("11. Zobrazit předměty");
                Console.WriteLine("12. Uložit předměty do souboru");
                Console.WriteLine("13. Zobrazit statistiky úkolů");
                Console.WriteLine("14. Zobrazit statistiky hodnocení");
                Console.WriteLine("15. Přidat rozvrh hodin");
                Console.WriteLine("16. Zobrazit rozvrhy");
                Console.WriteLine("17. Uložit rozvrhy do souboru");
                Console.WriteLine("18. Upravit profil");
                Console.WriteLine("19. Zobrazit profil");
                Console.WriteLine("20. Zobrazit notifikace");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("Zadejte název nového úkolu: ");
                    string title = Console.ReadLine();
                    Console.Write("Zadejte popis úkolu: ");
                    string description = Console.ReadLine();
                    Console.Write("Zadejte termín odevzdání (yyyy-mm-dd): ");
                    DateTime dueDate = DateTime.Parse(Console.ReadLine());
                    teacher.CreateTask(taskManager, title, description, dueDate);
                    notificationManager.AddNotification(teacher.Username, $"Nový úkol: {title}");
                }
                else if (choice == 2)
                {
                    taskManager.DisplayTasks();
                }
                else if (choice == 3)
                {
                    Console.Write("Zadejte název úkolu k označení jako dokončený: ");
                    string title = Console.ReadLine();
                    taskManager.MarkTaskAsCompleted(title);
                }
                else if (choice == 4)
                {
                    taskManager.SaveTasksToFile("tasks.txt");
                    Console.WriteLine("Úkoly byly uloženy do souboru.");
                }
                else if (choice == 5)
                {
                    Console.Write("Zadejte název nové učebny: ");
                    string name = Console.ReadLine();
                    Console.Write("Zadejte umístění učebny: ");
                    string location = Console.ReadLine();
                    classroomManager.AddClassroom(name, location);
                }
                else if (choice == 6)
                {
                    classroomManager.DisplayClassrooms();
                }
                else if (choice == 7)
                {
                    classroomManager.SaveClassroomsToFile("classrooms.txt");
                    Console.WriteLine("Učebny byly uloženy do souboru.");
                }
                else if (choice == 8)
                {
                    Console.Write("Zadejte příjemce: ");
                    string recipient = Console.ReadLine();
                    Console.Write("Zadejte zprávu: ");
                    string content = Console.ReadLine();
                    messageManager.SendMessage(teacher.Username, recipient, content);
                }
                else if (choice == 9)
                {
                    Console.Write("Zadejte číslo zprávy k označení jako přečtenou: ");
                    int messageIndex = int.Parse(Console.ReadLine());
                    messageManager.MarkMessageAsRead(teacher.Username, messageIndex);
                }
                else if (choice == 10)
                {
                    Console.Write("Zadejte název nového předmětu: ");
                    string subjectName = Console.ReadLine();
                    Console.Write("Zadejte kód předmětu: ");
                    string subjectCode = Console.ReadLine();
                    subjectManager.AddSubject(subjectName, subjectCode);
                }
                else if (choice == 11)
                {
                    subjectManager.DisplaySubjects();
                }
                else if (choice == 12)
                {
                    subjectManager.SaveSubjectsToFile("subjects.txt");
                    Console.WriteLine("Předměty byly uloženy do souboru.");
                }
                else if (choice == 13)
                {
                    statistics.DisplayTaskStatistics();
                }
                else if (choice == 14)
                {
                    statistics.DisplayGradeStatistics();
                }
                else if (choice == 15)
                {
                    Console.Write("Zadejte název třídy: ");
                    string className = Console.ReadLine();
                    Console.Write("Zadejte název předmětu: ");
                    string subject = Console.ReadLine();
                    Console.Write("Zadejte začátek hodiny (yyyy-mm-dd hh:mm): ");
                    DateTime startTime = DateTime.Parse(Console.ReadLine());
                    Console.Write("Zadejte konec hodiny (yyyy-mm-dd hh:mm): ");
                    DateTime endTime = DateTime.Parse(Console.ReadLine());
                    scheduleManager.AddSchedule(className, subject, startTime, endTime);
                }
                else if (choice == 16)
                {
                    scheduleManager.DisplaySchedules();
                }
                else if (choice == 17)
                {
                    scheduleManager.SaveSchedulesToFile("schedules.txt");
                    Console.WriteLine("Rozvrhy byly uloženy do souboru.");
                }
                else if (choice == 18)
                {
                    Console.Write("Zadejte nové jméno: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Zadejte nové příjmení: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Zadejte nový email: ");
                    string email = Console.ReadLine();
                    Console.Write("Zadejte nové telefonní číslo: ");
                    string phoneNumber = Console.ReadLine();
                    profileManager.UpdateProfile(teacher.Username, firstName, lastName, email, phoneNumber);
                }
                else if (choice == 19)
                {
                    profileManager.DisplayProfile(teacher.Username);
                }
                else if (choice == 20)
                {
                    notificationManager.DisplayNotifications(teacher.Username);
                }
            }
            else if (loggedInUser is Student)
            {
                Student student = (Student)loggedInUser;
                Console.WriteLine($"Přihlášen student: {student.FirstName} {student.LastName}");
                Console.WriteLine("Vyberte akci:");
                Console.WriteLine("1. Zobrazit úkoly");
                Console.WriteLine("2. Zobrazit hodnocení");
                Console.WriteLine("3. Zobrazit zprávy");
                Console.WriteLine("4. Označit zprávu jako přečtenou");
                Console.WriteLine("5. Zobrazit rozvrhy");
                Console.WriteLine("6. Upravit profil");
                Console.WriteLine("7. Zobrazit profil");
                Console.WriteLine("8. Zobrazit notifikace");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    taskManager.DisplayTasks();
                }
                else if (choice == 2)
                {
                    Console.Write("Zadejte název úkolu pro zobrazení hodnocení: ");
                    string title = Console.ReadLine();
                    int grade = gradeManager.GetGrade(title);
                    if (grade != -1)
                    {
                        Console.WriteLine($"Hodnocení úkolu \"{title}\": {grade}");
                    }
                    else
                    {
                        Console.WriteLine("Hodnocení úkolu nebylo nalezeno.");
                    }
                }
                else if (choice == 3)
                {
                    messageManager.DisplayMessages(student.Username);
                }
                else if (choice == 4)
                {
                    Console.Write("Zadejte číslo zprávy k označení jako přečtenou: ");
                    int messageIndex = int.Parse(Console.ReadLine());
                    messageManager.MarkMessageAsRead(student.Username, messageIndex);
                }
                else if (choice == 5)
                {
                    scheduleManager.DisplaySchedules();
                }
                else if (choice == 6)
                {
                    Console.Write("Zadejte nové jméno: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Zadejte nové příjmení: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Zadejte nový email: ");
                    string email = Console.ReadLine();
                    Console.Write("Zadejte nové telefonní číslo: ");
                    string phoneNumber = Console.ReadLine();
                    profileManager.UpdateProfile(student.Username, firstName, lastName, email, phoneNumber);
                }
                else if (choice == 7)
                {
                    profileManager.DisplayProfile(student.Username);
                }
                else if (choice == 8)
                {
                    notificationManager.DisplayNotifications(student.Username);
                }
            }

            // Uložení dat do souboru před ukončením
            taskManager.SaveTasksToFile("tasks.txt");
            gradeManager.SaveGradesToFile("grades.txt");
            classroomManager.SaveClassroomsToFile("classrooms.txt");
            messageManager.SaveMessagesToFile("messages.txt");
            subjectManager.SaveSubjectsToFile("subjects.txt");
            scheduleManager.SaveSchedulesToFile("schedules.txt");
            profileManager.SaveProfilesToFile("profiles.txt");
            notificationManager.SaveNotificationsToFile("notifications.txt");
            attendanceManager.SaveAttendanceToFile("attendance.txt");
            homeworkManager.SaveHomeworksToFile("homeworks.txt");
        }

        static User Login(UserManager userManager)
        {
            Console.Write("Zadejte uživatelské jméno: ");
            string username = Console.ReadLine();
            Console.Write("Zadejte heslo: ");
            string password = Console.ReadLine();
            User user = userManager.AuthenticateUser(username, password);
            if (user != null)
            {
                return user;
            }
            else
            {
                Console.WriteLine("Neplatné uživatelské jméno nebo heslo.");
                return Login(userManager);
            }
        }
    }


}
