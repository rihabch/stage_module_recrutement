using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Recrute.Models
{
    [Table("CandidatureSpontanee")]
    
    public class CandidatureSpontanee
    {
        [Key] // Primary key
        public int idcandid { get; set; }

        [Display(Name = "Diplôme")]
        public string diploma { get; set; }

        [Display(Name = "Lieu de travail actuel")]
        public string placeCurrentJob { get; set; }

        [Display(Name = "Spécialité")]
        public string speciality { get; set; }
        
        [Display(Name = "Date de candidature")]
        public DateTime dateCandid { get; set; }

        [Display(Name = "Curriculum Vitae")]
        public string CV { get; set; }

        [Display(Name = "Lettre de motivation")]
        public string motivationLetter { get; set; }

        public int candidatID { get; set; }
        public virtual User candidat { get; set; }

        public CandidatureSpontanee()
        {
            dateCandid = DateTime.Now;
        }
    }  
}