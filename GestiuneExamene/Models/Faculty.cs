using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestiuneExamene.Models
{
    public class Faculty
    {
        [Key]
        [Column("faculty_id")] // in mod default numele campului in tabela era FacultyId
        public int FacultyId { get; set; }

        [MinLength(3, ErrorMessage = "Lungimea denumirii institutiei mai mare de 3 caractere"),
        MaxLength(100, ErrorMessage = "Lungimea denumirii institutiei mai mica de 100 caractere")]
        [Required(ErrorMessage = "Denumirea facultatii este necesara.")]
        [Display(Name = "Denumire Facultate")]
        public string Name { get; set; }
        

        [Display(Name = "Adresa Facultate")]
        public string Adress { get; set; }
        
        //one to one
        public virtual Specialization Specialization { get; set; }

    }
}