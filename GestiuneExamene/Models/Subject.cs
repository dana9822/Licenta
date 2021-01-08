using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Subject
    {
        [Key]
        [Column(Order = 13)]
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        //one to many
        public ICollection<SubjectAllocation> SubjectAllocations { get; set; }

        //one to many
        public ICollection<Coverage> Coverages { get; set; }

        //one to many
        public ICollection<MakeupExamRequest> MakeupExamRequests { get; set; }

        //one to many
        public ICollection<Exam> Exams { get; set; }
    }
}