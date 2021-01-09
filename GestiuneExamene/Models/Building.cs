using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Building
    {
        [Key]
        [Column(Order = 9)]
        public int BuildingId { get; set; }

        public string BuildingName { get; set; }

        public string BuildingAdress { get; set; }

        //one to one
        public virtual Classroom Classroom { get; set; }
    }
}