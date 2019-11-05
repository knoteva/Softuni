using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {
            Prescriptions = new List<PatientMedicament>();
        }

        //MedicamentId
        //Name(up to 50 characters, unicode)

        [Key]
        public int MedicamentId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
