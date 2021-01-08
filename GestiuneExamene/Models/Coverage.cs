using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Coverage
    {
        //la fel ca la clasa de acoperire materii, cand acoperim o materie => completam pe langa asta si ce profesor preda si in ce an Universitar
        //one to many
        [Key]
        [Column(Order = 0)]
        public int SpecializationID { get; set; }
        public Specialization Specialization { get; set; }

        //one to many
        [Key]
        [Column(Order = 13)]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        //one to many
        [Key]
        [Column(Order = 12)]
        public int ProfessorId { get; set; }
        public Professor Professor{ get; set; }

        //one to many
        [Key]
        [Column(Order = 2)]
        public int StudyingYear { get; set; }
        public StudyYear StudyYear { get; set; }

        //one to many
        [Key]
        [Column(Order = 1)]
        public string AcademicalYear { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}