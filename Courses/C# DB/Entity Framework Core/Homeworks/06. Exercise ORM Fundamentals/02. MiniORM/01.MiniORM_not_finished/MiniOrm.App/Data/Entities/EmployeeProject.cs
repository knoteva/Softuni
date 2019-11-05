using System.ComponentModel.DataAnnotations;

namespace MiniOrm.App.Data.Entities
{
    public class EmployeeProject
    {
        [Key]
        public int ProjectId { get; set; }

        [Key]
        public int EmployeeId { get; set; }
    }
}