namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Student : IStudent
    {
        private IUniversity university;
        private List<int> coveredExams;
        private int id;
        private string firstName;
        private string lastName;

        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            coveredExams = new List<int>();
        }

        public int Id
        {
            get => id;
            private set => id = value;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams 
            => coveredExams.AsReadOnly();

        public IUniversity University
            => university;

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.university = university;
        }
    }
}
