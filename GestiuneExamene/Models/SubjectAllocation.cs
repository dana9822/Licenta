using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class SubjectAllocation
    {
        //Clasa de Alocare Discipline (SubjectAllocation) ar trebui cumva completata/inserate date ,atunci cand se adauga disciplina noua=>sa o si alocam
        public string Semester { get; set; }

        public string EvaluationType { get; set; }

        public string Status { get; set; }

        //one to many
        [Key]
        [Column(Order = 0)]
        public int SpecializationID { get; set; }
        public Specialization Specialization { get; set; }

        //one to many
        [Key]
        [Column(Order = 2)]
        public int StudyingYear { get; set; }

        public StudyYear StudyYear { get; set; }

        //one to many
        [Key]
        [Column(Order = 13)]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}