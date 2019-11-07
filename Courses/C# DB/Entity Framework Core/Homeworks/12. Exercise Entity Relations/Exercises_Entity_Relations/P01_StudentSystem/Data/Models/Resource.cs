using P01_StudentSystem.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        //ResourceId
        //Name(up to 50 characters, unicode)
        //Url(not unicode)
        //ResourceType(enum – can be Video, Presentation, Document or Other)
        //CourseId

        [Key]
        public int ResourceId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}
