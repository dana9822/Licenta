using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class SubjectCoverage
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Specialization")]
        public int IdSpecializare { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Subject")]
        public int IdDisciplina { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Professor")]
        public int MarcaProf { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("StudyYear")]
        public int AnStudiu { get; set; }
        [Key]
        [Column(Order = 4)]
        [ForeignKey("AcademicYear")]
        public int AnUniversitar { get; set; }

        public virtual StudyYear StudyYear { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual Professor Professor { get; set; }
    }
}