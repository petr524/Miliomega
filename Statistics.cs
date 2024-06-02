using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Statistics
    {
        private TaskManager taskManager;
        private GradeManager gradeManager;

        public Statistics(TaskManager taskManager, GradeManager gradeManager)
        {
            this.taskManager = taskManager;
            this.gradeManager = gradeManager;
        }

        public void DisplayTaskStatistics()
        {
            int totalTasks = taskManager.GetTotalTasks();
            int completedTasks = taskManager.GetCompletedTasks();
            int overdueTasks = taskManager.GetOverdueTasks();

            Console.WriteLine("Statistiky úkolů:");
            Console.WriteLine($"Celkem úkolů: {totalTasks}");
            Console.WriteLine($"Dokončených úkolů: {completedTasks}");
            Console.WriteLine($"Zpožděných úkolů: {overdueTasks}");
        }

        public void DisplayGradeStatistics()
        {
            var grades = gradeManager.GetAllGrades();
            if (grades.Count == 0)
            {
                Console.WriteLine("Žádné hodnocení není k dispozici.");
                return;
            }

            int totalGrades = grades.Count;
            double averageGrade = grades.Average();
            int highestGrade = grades.Max();
            int lowestGrade = grades.Min();

            Console.WriteLine("Statistiky hodnocení:");
            Console.WriteLine($"Celkem hodnocení: {totalGrades}");
            Console.WriteLine($"Průměrné hodnocení: {averageGrade:F2}");
            Console.WriteLine($"Nejvyšší hodnocení: {highestGrade}");
            Console.WriteLine($"Nejnižší hodnocení: {lowestGrade}");
        }
    }
}
