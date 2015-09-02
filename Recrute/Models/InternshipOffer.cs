using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Recrute.Models
{
    [Table("InternshipOffer")]
    public class InternshipOffer
    {

        [Key] // Primary key
        public int offreRef { get; set; }
        [Display(Name = "Poste")]
        public string poste { get; set; }
        [Display(Name = "Lieu")]
        public string place { get; set; }
        [Display(Name = "Activité")]
        public string activity { get; set; }
        [Display(Name = "Nombre des stagiaires")]
        public int? nbreInterns { get; set; }

        [Display(Name = "Date Publication de l'offre")]
        public DateTime dateOffre { get; set; }

        [Display(Name = "Date de début")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime dateStart { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date de Fin")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime dateEnd { get; set; }
        
        [Display(Name = "Desciption")]
        public string description { get; set; }
        [Display(Name = "Connaissances Techniques")]
        public string techKnow { get; set; }
        [Display(Name = "Connaissances Pratiques")]
        public string praticKnow { get; set; }

        public int adminID { get; set; }
        public virtual User admin { get; set; }

        public InternshipOffer() {

            dateOffre = DateTime.Now;

        }
    }
}