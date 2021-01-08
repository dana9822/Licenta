using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Professor
    {
        [Key]
        [Column(Order = 12)]
        public int ProfessorId { get; set; }

        public string ProfessorFirstName { get; set; }

        public string ProfessorLastName { get; set; }

        public string ProfessorUniversityDegree { get; set; }

        //one to many
        public ICollection<Coverage> Coverages { get; set; }
    }
}