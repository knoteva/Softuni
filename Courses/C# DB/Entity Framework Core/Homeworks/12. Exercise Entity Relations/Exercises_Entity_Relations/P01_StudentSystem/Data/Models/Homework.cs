using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data.Models.Enum;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        //HomeworkId
        //Content(string, linking to a file, not unicode)
        //ContentType(enum – can be Application, Pdf or Zip)
        //SubmissionTime
        //StudentId
        //CourseId

        [Key]
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }
       
        [ForeignKey("Student")]
        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}
