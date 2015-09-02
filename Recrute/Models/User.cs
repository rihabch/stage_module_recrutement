using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Recrute.Models
{
    [Table("User")] // Table name
    public class User
    {
        public User()
        {
            DateOfInscri = DateTime.Now;
            
        }
        [Key] // Primary key
        public int userID { get; set; }
        [Display(Name = "Nom")]
        public string userName { get; set; }
        [Display(Name = "Prénom")]
        public string userFirstName { get; set; }
        [Display(Name = "Adresse Email")]
        [Required(ErrorMessage = "L'email est un champ obligatoire")]
        [EmailAddress(ErrorMessage = "Adresse email invalide")]
        public string email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le mot de passe est un champ obligatoire")]
        public string password { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Nationalité")]
        public string nationality { get; set; }
        [Display(Name = "Lieu de naissance")]
        public string placeOfBirth { get; set; }
        [Display(Name = "Situation Familiale")]
        public string famSituation { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Numéro Téléphone Fixe doit etre un nombrer")]
        [Display(Name = "Numéro Téléphone Fixe")]
        public string phoneNum { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Numéro Téléphone Mobile doit etre un nombre")]
        [Display(Name = "Numéro Téléphone Mobile  ")]
        public string gsmNum { get; set; }
        [Display(Name = "Adresse")]
        public string adress { get; set; }
        [Display(Name = "Ville")]
        public string city { get; set; }
        [Display(Name = "Pays")]
        public string country { get; set; }
        [Display(Name = "Code Postal")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Code Postal doit etre un nombre")]
        public string codePoste { get; set; }
        [Display(Name = "Photo")]
        public byte?[] Photo { get; set; }
        [Display(Name = "Date de l'inscription")]
        public DateTime DateOfInscri { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }

        public ICollection<InternshipOffer> Internships { get; set; }
        public ICollection<JobOffer> Jobs { get; set; }
        public ICollection<CandidatureSpontanee> Candidatures { get; set; }

    }
}