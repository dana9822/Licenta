using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class SessionYear
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Session")]
        public int IdSesiune { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("AcademicYear")]
        public int AnUniversitar { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataFinal { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Session Session { get; set; }
    }
}