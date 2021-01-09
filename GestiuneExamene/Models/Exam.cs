using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Exam
    {
        //one to many
        [Key]
        [Column(Order = 11)]
        public int ClassroomNumber { get; set; }
        [Key]
        [Column(Order = 10)]
        public int ClassroomFloor { get; set; }
        [Key]
        [Column(Order = 9)]
        public int BuildingId { get; set; }

        [ForeignKey("ClassroomNumber,ClassroomFloor,BuildingId")]
        public Classroom Classroom { get; set; }  //=> 3 PK  idCorp,nrSala,Etaj

        //one to many
        [Key]
        [Column(Order = 13)]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }        //=> 1PK idDisciplina

        //one to many
        [Key]
        [Column(Order = 7)]
        public int SessionId { get; set; }       //=> 1PK idSesiune

        [ForeignKey("SessionId")]
        public Session Session { get; set; }

        //one to many
        [Key]
        [Column(Order = 4)]
        public int GroupNumber { get; set; }

        [Key]
        [Column(Order = 0)]
        public int SpecializationId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int StudyingYear { get; set; }

        [Key]
        [Column(Order = 1)]
        public string AcademicalYear { get; set; }

        [ForeignKey("GroupNumber,SpecializationId,StudyingYear,AcademicalYear")]
        public Group Group { get; set; }    // ==>4 PK anUniv,anStudiu,idSpecializare,idGrupa

        //==> 9 PK si 9FK

        public string EvaluationMode { get; set; }

        public DateTime ExamDate { get; set; }

        public int ExamHour { get; set; }

        public int ExamTime { get; set; }
    }
}