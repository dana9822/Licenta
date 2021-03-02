using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Exam
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Classroom")]
        public int IdCorp { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Classroom")]
        public int NrSala { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Classroom")]
        public int Etaj { get; set; }
        [Key]
        [Column(Order = 4)]
        [ForeignKey("Group")]
        public int IdGrupa { get; set; }
        [Key]
        [Column(Order = 5)]
        [ForeignKey("Group")]
        public int IdSpecializare { get; set; }
        [Key]
        [Column(Order = 6)]
        [ForeignKey("Group")]
        public int AnStudiu { get; set; }
        [Key]
        [Column(Order = 7)]
        [ForeignKey("Group")]
        public int AnUniversitar { get; set; }
        [Key]
        [Column(Order = 8)]
        [ForeignKey("Session")]
        public int IdSesiune { get; set; }
        [Key]
        [Column(Order = 9)]
        [ForeignKey("Subject")]
        public int IdDisciplina { get; set; }
        public string ModEvaluare { get; set; }
        public DateTime Data { get; set; }
        public int Ora { get; set; }
        public string Durata { get; set; }
        public int ProfTitular { get; set; }
        public int ProfSupraveghetor { get; set; }

        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Session Session { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}