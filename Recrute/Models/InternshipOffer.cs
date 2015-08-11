using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Recrute.Models
{
    [Table("InternshipOffers")]
    public class InternshipOffer
    {

        [Key] // Primary key
        public int offreRef { get; set; }
        [Display(Name = "Poste")]
        public string poste { get; set; }
        [Display(Name = "Place")]
        public string place { get; set; }
        [Display(Name = "Activity")]
        public string activity { get; set; }
        [Display(Name = "Number of Interns")]
        public int? nbreInterns { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime dateStart { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime dateEnd { get; set; }
        [Display(Name = "Desciption")]
        public string description { get; set; }
        [Display(Name = "Technical Knowlage")]
        public string techKnow { get; set; }
        [Display(Name = "Practical Knowlage")]
        public string praticKnow { get; set; }

        public int adminID { get; set; }
        public virtual User admin { get; set; }

        public InternshipOffer() { }
    }
}