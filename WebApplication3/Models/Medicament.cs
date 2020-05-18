using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Medicament
    {
        [Key] public int IdMedicament { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Type { get; set; }
        public int Dose { get; set; }
        public String Details { get; set; }


        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
