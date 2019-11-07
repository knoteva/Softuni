using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        //CourseId
        //Name(up to 80 characters, unicode)
        //Description(unicode, not required)
        //StartDate
        //EndDate
        //Price


        [Key]
        public int CourseId { get; set; }

        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
      
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();

        public ICollection<Homework> HomeworkSubmissions { get; set; } = new HashSet<Homework>();

        public ICollection<StudentCourse> StudentsEnrolled { get; set; } = new HashSet<StudentCourse>();

    }
}
