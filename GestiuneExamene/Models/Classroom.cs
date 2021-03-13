using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestiuneExamene.Models
{
    public class Classroom
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Building")]
        public int IdCorp { get; set; }
        [Key]
        [Column(Order = 1)]
        public int NrSala { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Etaj { get; set; }

        public int NrLocuri { get; set; }
        public string TipSala { get; set; }

        public virtual Building Building { get; set; }
        public virtual ICollection<MakeupExam> MakeupExams { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> BuildingsList { get; set; }
    }
}