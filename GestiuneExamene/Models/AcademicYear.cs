using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class AcademicYear
    {
        //public AcademicYear()
        //{
        //    Group = new HashSet<Group>();
        //}
        [Key]
        public int AcademicYearId { get; set; }
        public string AnUniversitar { get; set; }

        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<SubjectCoverage> SubjectCoverages { get; set; }
        public virtual ICollection<SessionYear> SessionYears { get; set; }
        public virtual ICollection<MakeupExam> MakeupExams { get; set; }
        public virtual ICollection<MakeupExamRequest> MakeupExamRequests { get; set; }
    }
}