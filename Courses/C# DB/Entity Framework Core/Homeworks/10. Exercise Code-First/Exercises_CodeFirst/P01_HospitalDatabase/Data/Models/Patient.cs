using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    using static DataValidations.Patient;
    public class Patient
    {
        
        public Patient()
        {
            //Visitations = new List<Visitation>();
            Diagnoses = new List<Diagnose>();
            Prescriptions = new List<PatientMedicament>();
        }

        //PatientId
        //FirstName(up to 50 characters, unicode)
        //LastName(up to 50 characters, unicode)
        //Address(up to 250 characters, unicode)
        //Email(up to 80 characters, not unicode)
        //HasInsurance

        [Key]
        public int PatientId { get; set; }
  
        [MaxLength(NameMaxLength)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(NameMaxLength)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(AddresseMaxLength)]
        [Required]
        public string Address { get; set; }
        
        [Column(TypeName = "varchar(30)")]
        [MaxLength(AddresseEmailLength)]
        [Required]
        public string Email { get; set; }

        [DefaultValue(false)]
        public bool HasInsurance { get; set; }

        public ICollection<Visitation> Visitations { get; set; } = new List<Visitation>();

        public ICollection<Diagnose> Diagnoses { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }

    }
}
