using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Recrute.Models;

namespace Recrute.Controllers
{
    [Table("JobOffer")]
    public class JobOffer
    {
        [Key] // Primary key
        public int offreRef { get; set; }
        [Display(Name = "Poste")]
        public string poste { get; set; }
        [Display(Name = "Lieu")]
        public string place { get; set; }
        [Display(Name = "Activité")]
        public string activity { get; set; }
        public DateTime dateOffre { get; set; }

        [Display(Name = "Niveau")]
        public string level { get; set; }
        [Display(Name = "Expérience")]
        public string experience { get; set; }
        [Display(Name = "Profil")]
        public string profile { get; set; }
        [Display(Name = "Missions")]
        public string missions { get; set; }
        [Display(Name = "Atouts")]
        public string atouts { get; set; }

        public int adminID { get; set; }
        public virtual User admin { get; set; }

        public JobOffer() { 

        dateOffre = DateTime.Now;
        
        }
    }
    }