namespace UniversityCompetition.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;

    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universityes;
        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universityes = new UniversityRepository();
        }
        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName($"{firstName} {lastName}") != null)
            {
                return $"{firstName} {lastName} is already added in the repository.";
            }

            int curentId = students.Models.Count() + 1;

            IStudent strudent = new Student(curentId, firstName, lastName);
            students.AddModel(strudent);

            return $"Student {firstName} {lastName} is added to the {students.GetType().Name}!";
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != "TechnicalSubject" &&
                 subjectType != "EconomicalSubject" &&
                 subjectType != "HumanitySubject")
            {
                return $"Subject type {subjectType} is not available in the application!";
            }

            if (this.subjects.Models.Any(x => x.Name == subjectName))
            {
                return $"{subjectName} is already added in the repository.";
            }

            int id = subjects.Models.Count() + 1;
            ISubject subject = null;

            if (subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(id, subjectName);
            }
            else if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(id, subjectName);
            }
            else
            {
                subject = new HumanitySubject(id, subjectName);
            }

            subjects.AddModel(subject);
            return $"{subjectType} {subjectName} is created and added to the {subjects.GetType().Name}!";
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universityes.FindByName(universityName) != null)
            {
                return $"{universityName} is already added in the repository.";
            }

            List<int> require = new();

            foreach (var re in requiredSubjects)
            {
                ISubject newsub = subjects.FindByName(re);

                if (newsub != null)
                {
                    require.Add(newsub.Id);
                }
            }
            int curentId = universityes.Models.Count() + 1;

            IUniversity university = new University(curentId, universityName, category, capacity, require);
            universityes.AddModel(university);
            return $"{universityName} university is created and added to the {universityes.GetType().Name}!";
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string firstName = studentName.Split().First().Trim();
            string lastName = studentName.Split().Last().Trim();

            if (students.FindByName(studentName) == null)
            {
                return $"{firstName} {lastName} is not registered in the application!";
            }

            if (universityes.FindByName(universityName) == null)
            {
                return $"{universityName} is not registered in the application!";
            }

            University university = universityes.FindByName(universityName) as University;
            Student student = students.FindByName(studentName) as Student;

            foreach (var item in university.RequiredSubjects)
            {
                if (student.CoveredExams.Contains(item) == false)
                {
                    return $"{studentName} has not covered all the required exams for {universityName} university!";
                }
            }

            if (student.University != null && student.University.Name == university.Name)
            {
                return $"{student.FirstName} {student.LastName} has already joined {universityName}.";
            }

            student.JoinUniversity(university);
            return $"{student.FirstName} {student.LastName} joined {universityName} university!";
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId) == null)
            {
                return "Invalid student ID!";
            }

            if (subjects.FindById(subjectId) == null)
            {
                return "Invalid subject ID!";
            }

            Student student = students.FindById(studentId) as Student;
            ISubject subject = subjects.FindById(subjectId);

            if (student.CoveredExams.Any(x => x == subjectId))
            {
                return $"{student.FirstName} {student.LastName} has already covered exam of {subject.Name}.";
            }

            student.CoverExam(subject);
            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universityes.FindById(universityId);

            StringBuilder sb = new();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");

            int countOfStudentsAdmitet = 0;

            foreach (var student in students.Models)
            {
                if (student.University == university)
                {
                    countOfStudentsAdmitet++;
                }
            }
            sb.AppendLine($"Students admitted: {countOfStudentsAdmitet}");
            sb.Append($"University vacancy: {university.Capacity - countOfStudentsAdmitet}");

            return sb.ToString().Trim();
        }
    }
}
