using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class SubjectAllocation
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Specialization")]
        public int IdSpecializare { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("StudyYear")]
        public int AnStudiu { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("Subject")]
        public int IdDisciplina { get; set; }
        public string Semestru { get; set; }
        public string TipEvaluare { get; set; }
        public string Status { get; set; }

        public virtual StudyYear StudyYear { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}