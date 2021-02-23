using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Building
    {
        public Building()
        {
            Classrooms = new HashSet<Classroom>();
        }

        [Key]
        [Column(Order = 0)]
        public int IdCorp { get; set; }
        public string DenumireCorp { get; set; }
        public string Adresa { get; set; }

        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}