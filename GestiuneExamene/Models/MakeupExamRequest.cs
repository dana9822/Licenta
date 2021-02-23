using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class MakeupExamRequest
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Student")]
        public int IdGrupa { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Student")]
        public int IdSpec { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Student")]
        public int AnStudiu { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("Student")]
        public int AnUnivStudent { get; set; }
        [Key]
        [Column(Order = 4)]
        [ForeignKey("Student")]
        public int Matricola { get; set; }
        [Key]
        [Column(Order = 5)]
        [ForeignKey("Session")]
        public int IdSesiune { get; set; }
        [Key]
        [Column(Order = 6)]
        [ForeignKey("Subject")]
        public int IdDisc { get; set; }
        [Key]
        [Column(Order = 7)]
        [ForeignKey("AcademicYear")]
        public int AnUnivCurent { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Session Session { get; set; }
        public virtual Student Student { get; set; }
    }
}