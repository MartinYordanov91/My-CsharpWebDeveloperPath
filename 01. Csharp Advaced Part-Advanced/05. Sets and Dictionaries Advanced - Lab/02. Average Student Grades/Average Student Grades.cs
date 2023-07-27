namespace _02._Average_Student_Grades
{
    using System;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsGrades = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new();
            for (int curentGrade = 0; curentGrade < studentsGrades; curentGrade++)
            {
                string[] studentAndGrade = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string studentName = studentAndGrade[0];
                decimal studentGrade = decimal.Parse(studentAndGrade[1]);

                if(students.ContainsKey(studentName) == false)
                {
                    students.Add(studentName, new List<decimal>());
                }

                students[studentName].Add(studentGrade);
            }

            foreach (var student in students)
            {
                StringBuilder sb = new();
                foreach (var item in student.Value)
                {
                    sb.Append($"{item:f2} ");
                }

                Console.WriteLine($"{student.Key} -> {sb}(avg: {(student.Value.Sum()/student.Value.Count):f2})");
            }
        }
    }
}