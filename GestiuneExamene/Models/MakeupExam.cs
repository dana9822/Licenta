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
        //one to many
        [Key,Column(Order = 11)]
        public int ClassroomNumber { get; set; }
        public Classroom Classroom { get; set; }  //=> 3 PK  idCorp,nrSala,Etaj

        //one to many
        [Key, Column(Order = 12)]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } 

        //one to many
        [Key]
        [Column(Order = 13)]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        //one to many
        [Key]
        [Column(Order = 7)]
        public int SessionId { get; set; }
        public Session Session { get; set; }

        //one to many
        [Key]
        [Column(Order = 1)]
        public string AcademicalYear { get; set; }
        public AcademicYear AcademicYear { get; set;}

        [Key]
        [Column(Order = 14)]
        public DateTime MakeupExamDate { get; set; }

        [Key]
        [Column(Order = 15)]
        public int MakeupExamHour { get; set; }

        public int MakeupExamTime { get; set; }  //durata restantei 1 ora,2 ore etc

        public string MakeupExamEvaluationMode { get; set; }

    }
}