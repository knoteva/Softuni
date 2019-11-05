using System.ComponentModel.DataAnnotations;

namespace MiniOrm.App.Data.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}