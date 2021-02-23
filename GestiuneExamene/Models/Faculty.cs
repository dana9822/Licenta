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
        public int IdFacultate { get; set; }

        [MinLength(3, ErrorMessage = "Lungimea denumirii institutiei mai mare de 3 caractere"),
        MaxLength(100, ErrorMessage = "Lungimea denumirii institutiei mai mica de 100 caractere")]
        [Required(ErrorMessage = "Denumirea facultatii este necesara.")]
        [Display(Name = "Denumire Facultate")]
        public string DenumireFacultate { get; set; }


        [Display(Name = "Adresa Facultate")]
        public string AdresaFacultate { get; set; }

        //EF Core code imported from EF core import MySql db
        public virtual ICollection<Specialization> Specializations { get; set; }

    }
}