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
        //one to many
        [Key]
        [Column(Order = 5)]
        public int StudentRegNumber { get; set; }
        public Student Student { get; set; }

        //one to many
        [Key]
        [Column(Order = 6)]
        public string User { get; set; }
        public Student StudentUser { get; set; }

        //one to many
        [Key]
        [Column(Order = 7)]
        public int SessionId { get; set; }
        public Session Session { get; set; }

        //one to many
        [Key]
        [Column(Order = 1)]
        public string AcademicalYear { get; set; }
        public AcademicYear AcademicYear { get; set; }

        //one to many
        [Key]
        [Column(Order = 13)]
        public int SubjectId  { get; set; }
        public Subject Subject { get; set; }
    }
}