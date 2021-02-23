using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Subject
    {
        //public Disciplina()
        //{
        //    Acoperire = new HashSet<Acoperire>();
        //    AlocareDisciplina = new HashSet<AlocareDisciplina>();
        //    ProgramareExamen = new HashSet<ProgramareExamen>();
        //    ProgramareRestanta = new HashSet<ProgramareRestanta>();
        //    SolicitareRestanta = new HashSet<SolicitareRestanta>();
        //}

        [Key]
        public int IdDisciplina { get; set; }
        public string DenumireDisciplina { get; set; }

        public virtual ICollection<SubjectCoverage> SubjectCoverages { get; set; }
        public virtual ICollection<SubjectAllocation> SubjectAllocations { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<MakeupExam> MakeupExams { get; set; }
        public virtual ICollection<MakeupExamRequest> MakeupExamRequests { get; set; }
    }
}