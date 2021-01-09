using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class StudyYear
    {
        [Key]
        [Column(Order = 2)]
        public int StudyingYear { get; set; }  //pastrez doar 6 inregistrari,fara noi inregistrari , anul de studiu 1-6 => 1,2,3,4,5,6


        //one to one
        public virtual Group Group { get; set; }

        //one to many
        public ICollection<SubjectAllocation> SubjectAllocations { get; set; }

        //one to many
        public ICollection<Coverage> Coverages { get; set; }
    }
}