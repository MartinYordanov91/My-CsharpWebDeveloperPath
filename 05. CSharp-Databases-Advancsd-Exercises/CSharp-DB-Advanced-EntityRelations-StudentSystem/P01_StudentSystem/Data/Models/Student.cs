﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace P01_StudentSystem.Data.Models;

public class Student
{
    public Student()
    {
        this.StudentsCourses = new HashSet<StudentCourse>();
        this.Homeworks = new HashSet<Homework>();
    }

    public int StudentId { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    [MaxLength(10)]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }
}
