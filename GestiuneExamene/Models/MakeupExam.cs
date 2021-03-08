using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class MakeupExam
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
        [Column(Order = 3)]
        [ForeignKey("Professor")]
        public int MarcaProf { get; set; }
        [Key]
        [Column(Order = 4)]
        [ForeignKey("Subject")]
        public int IdDisciplina { get; set; }
        [Key]
        [Column(Order = 5)]
        [ForeignKey("Session")]
        public int IdSesiune { get; set; }
        [Key]
        [Column(Order = 6)]
        [ForeignKey("AcademicYear")]
        public int AnUniversitar { get; set; }
        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMakeupExam { get; set; }
        [DataType(DataType.Date)]
        [Index(IsUnique = true)]
        public DateTime Data { get; set; }
        public int Ora { get; set; }
        public string ModEvaluare { get; set; }
        public int? Durata { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Session Session { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}