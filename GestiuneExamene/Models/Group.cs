using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Group
    {
        [Key]
        [Column(Order = 4)]
        public int GroupNumber { get; set; }  // pastrez doar numerele de grupa in groupNumber => 1,2,3 etc (Grupa 1,Grupa 2)
                                              //EF genereaza el insusi un id separat prin care identifica daca nu are aici, 
                                              //sau completeaza el cu auto increment PK-urile de int?
                                              //Am nevoie la unele tabele sa pun eu date ,iar PK-urile sunt de tip int
        [Key]
        [Column(Order = 0)]
        public virtual Specialization Specialization { get; set; }

        [Key]
        [Column(Order = 2)]
        public virtual StudyYear StudyYear { get; set; }
        
        [Key]
        [Column(Order = 1)]
        public virtual AcademicYear AcademicYear { get; set; }

        public int NumberOfStudents { get; set; }

        //one to one

        public virtual Student Student { get; set; }

        //one to many
        public ICollection<Exam> Exams { get; set; }

    }
}