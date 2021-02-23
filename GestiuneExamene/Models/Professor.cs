using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Professor
    {
        //public Profesor()
        //{
        //    Acoperire = new HashSet<Acoperire>();
        //    ProgramareRestanta = new HashSet<ProgramareRestanta>();
        //}

        [Key]
        public int MarcaProf { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Prenume { get; set; }
        public string GradDidactic { get; set; }

        public virtual ICollection<SubjectCoverage> SubjectCoverages { get; set; }
        public virtual ICollection<MakeupExam> MakeupExams { get; set; }
    }
}