using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class AcademicYear
    {
        [Key]
        [Column(Order = 1)]
        public string AcademicalYear { get; set; }  // inregistrare de forma 2019-2020 , 2020-2021 => stringul generat in fiecare an nou universitar pentru
                                                    //a fi inserat automat in aplicatie cand incepe un nou anUniv
        //one to one => o grupa x poate sa fie intr-un an universitar intr-un singur an (in acelasi timp).
        public virtual Group Group { get; set; }

        //one to many
        public ICollection<Coverage> Coverages { get; set; }

        //one to many
        public ICollection<YearSession> YearSessions { get; set; }

        //one to many
        public ICollection<MakeupExamRequest> MakeupExamRequests { get; set; }
    }
}