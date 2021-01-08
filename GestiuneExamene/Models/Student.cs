using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Student
    {
        [Key]
        [Column(Order = 5)]
        public int StudentRegNumber { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public string IsStudentStatus { get;set; }  // valori = activ/inactiv

        [Key]
        [Column(Order = 6)]
        public string User { get; set; }

        public string Password { get; set; }

        //one to one
        public virtual Group Group { get; set; }

        //one to many
        public ICollection<MakeupExamRequest> MakeupExamRequests { get; set; }


    }
}