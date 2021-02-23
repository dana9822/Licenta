using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Session
    {
        //public Sesiune()
        //{
        //    AnSesiune = new HashSet<AnSesiune>();
        //    ProgramareExamen = new HashSet<ProgramareExamen>();
        //    ProgramareRestanta = new HashSet<ProgramareRestanta>();
        //    SolicitareRestanta = new HashSet<SolicitareRestanta>();
        //}

        [Key]
        public int IdSesiune { get; set; }
        public string DenumireSesiune { get; set; }

        public virtual ICollection<SessionYear> SessionYears { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<MakeupExam> MakeupExams { get; set; }
        public virtual ICollection<MakeupExamRequest> MakeupExamRequests { get; set; }
    }
}