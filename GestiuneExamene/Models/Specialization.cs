using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Specialization
    {
        [Key]
        [Column(Order = 0)]
        public int SpecializationID { get; set; }

        public string SpecializationName { get; set; }

        public string SpecializationDegreeLevel { get; set; }

        public int FacultyId { get; set; }

        //one to one
        [ForeignKey ("FacultyI")]
        [Column(Order = 20)]
        //[Required]
        public virtual Faculty Faculty { get; set; }
              
        //one to one
        public virtual Group Group { get; set; }

        //one to many
        public ICollection<SubjectAllocation> SubjectAllocations { get; set; }

        //one to many
        public ICollection<Coverage> Coverages { get; set; }
    }
}