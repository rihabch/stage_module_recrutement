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
        //[RegularExpression("^{8}$", ErrorMessage = "The phone number is composed of 8 numbers")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "The phone number should be a number")]
        [Display(Name = "Numéro Téléphone Fixe")]
        public int? phoneNum { get; set; }
        //[RegularExpression("^{8}$", ErrorMessage = "The mobile phone number is composed of 8 numbers")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "The mobile phone number should be a number")]
        [Display(Name = "Numéro Téléphone Mobile  ")]
        public int? gsmNum { get; set; }
        [Display(Name = "Adresse")]
        public string adress { get; set; }
        [Display(Name = "Ville")]
        public string city { get; set; }
        [Display(Name = "Pays")]
        public string country { get; set; }
        [Display(Name = "Code Postal")]
        public string codePoste { get; set; }
        public byte?[] Photo { get; set; }
        public DateTime DateOfInscri { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }

        //[ForeignKey("TypeUsers")]
        public int typeID { get; set; }
        public virtual TypeUsers type { get; set; }

        public ICollection<InternshipOffer> Internships { get; set; }
    }

    [Table("TypeUsers")] // Table name
    public class TypeUsers
    {
        public TypeUsers()
        {

        }
        [Key]
        public int typeID { get; set; }
        public string typeLabel { get; set; }

        public ICollection<User> Users { get; set; }
    }
}