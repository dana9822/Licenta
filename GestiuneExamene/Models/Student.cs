using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestiuneExamene.Models
{
    public class Student
    {
        //public Student()
        //{
        //    SolicitareRestanta = new HashSet<SolicitareRestanta>();
        //}

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Group")]
        public int IdGrupa { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Group")]
        public int IdSpec { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Group")]
        public int AnStudiu { get; set; }
        [Key]
        [Column(Order = 3)]
        [ForeignKey("Group")]
        public int AnUniv { get; set; }
        [Key]
        [Column(Order = 4)]
        public int Matricola { get; set; }
        public string Username { get; set; }
        public string Parola { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string StatusStudent { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<MakeupExamRequest> MakeupExamRequests { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> GroupsList { get; set; }
    }
}