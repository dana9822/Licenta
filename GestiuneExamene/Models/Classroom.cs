using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Classroom
    {
        [Key]
        [Column(Order = 11)]
        public int ClassroomNumber { get; set; }

        [Key]
        [Column(Order = 10)]
        public int ClassroomFloor { get; set; }
        [Key]
        [Column(Order = 9)]
        public int BuildingId { get; set; }

        //one to one        
        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }

        //one to many
        public ICollection<Exam> Exams { get; set; }

        public int NumberOfSeats { get; set; }

        public string ClassroomType { get; set; }

    }
}