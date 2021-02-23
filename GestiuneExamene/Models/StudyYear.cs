using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class StudyYear
    {
        //public Anstudiu()
        //{
        //    Acoperire = new HashSet<Acoperire>();
        //    AlocareDisciplina = new HashSet<AlocareDisciplina>();
        //    Grupa = new HashSet<Grupa>();
        //}

        [Key]
        public int StudyYearId { get; set; }
        public string AnStudiu { get; set; }

        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<SubjectCoverage> SubjectCoverages { get; set; }
        public virtual ICollection<SubjectAllocation> SubjectAllocations { get; set; }
    }
}