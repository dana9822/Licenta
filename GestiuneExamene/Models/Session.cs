using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Session
    {
        [Key]
        [Column(Order = 7)]
        public int SessionId { get; set; }

        public string SessionName { get; set; }


        //one to many
        public ICollection<YearSession> YearSessions { get; set; }

        //one to many
        public ICollection<MakeupExamRequest> MakeupExamRequests { get; set; }

        //one to many
        public ICollection<Exam> Exams { get; set; }
    }
}