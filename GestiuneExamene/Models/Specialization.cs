using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestiuneExamene.Models
{
    public class Specialization
    {
        //public Specialization()
        //{
        //    Group = new HashSet<Group>();
        //}
        [Key]
        public int IDSpecializare { get; set; }

        public string DenumireSpecializare { get; set; }

        public string FormaInvatamant { get; set; }

        [ForeignKey("Faculty")]
        public int IdFacultate { get; set; }

        //one to one
        //[Required]
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<SubjectCoverage> SubjectCoverages { get; set; }
        public virtual ICollection<SubjectAllocation> SubjectAllocations { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> FacultiesList { get; set; }
    }
}