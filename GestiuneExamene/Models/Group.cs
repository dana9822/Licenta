using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestiuneExamene.Models
{
    public class Group
    {
        //public Grupa()
        //{
        //    ProgramareExamen = new HashSet<ProgramareExamen>();
        //    Student = new HashSet<Student>();
        //}
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGrupa { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Specialization")]
        public int IdSpecializare { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("StudyYear")]
        public int AnStudiuId { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("AcademicYear")]
        public int AnUniversitarId { get; set; }
        public int nrGrupa { get; set; }
        public int? NrStudenti { get; set; }


        public virtual StudyYear StudyYear { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> SpecializationsList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> AcademicYearsList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> StudyYearsList { get; set; }
    }
}