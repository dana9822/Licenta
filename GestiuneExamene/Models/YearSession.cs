using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class YearSession
    {
        [Key]
        [Column(Order = 8)]
        public DateTime BeginSessionDate { get; set; }

        public DateTime EndSessionDate { get; set; }

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
    }
}