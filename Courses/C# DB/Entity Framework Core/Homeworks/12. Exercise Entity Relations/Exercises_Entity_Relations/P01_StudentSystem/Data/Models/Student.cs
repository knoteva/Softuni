using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        //StudentId
        //Name(up to 100 characters, unicode)
        //PhoneNumber(exactly 10 characters, not unicode, not required)
        //RegisteredOn
        //Birthday(not required)

        [Key]
        public int StudentId { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "CHAR(10)")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }


        public DateTime? Birthday { get; set; }


        public ICollection<Homework> HomeworkSubmissions { get; set; } = new HashSet<Homework>();

        public ICollection<StudentCourse> CourseEnrollments { get; set; } = new HashSet<StudentCourse>();

    }
}
