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
        [Display(Name = "Name")]
        public string userName { get; set; }
        [Display(Name = "FirstName")]
        public string userFirstName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "The password is required")]
        public string password { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Nationality")]
        public string nationality { get; set; }
        [Display(Name = "Place Of Birth")]
        public string placeOfBirth { get; set; }
        [Display(Name = "Family Situation")]
        public string famSituation { get; set; }
        //[RegularExpression("^{8}$", ErrorMessage = "The phone number is composed of 8 numbers")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "The phone number should be a number")]
        [Display(Name = "Phone Number")]
        public int? phoneNum { get; set; }
        //[RegularExpression("^{8}$", ErrorMessage = "The mobile phone number is composed of 8 numbers")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "The mobile phone number should be a number")]
        [Display(Name = "Mobile Phone Number")]
        public int? gsmNum { get; set; }
        [Display(Name = "Adress")]
        public string adress { get; set; }
        [Display(Name = "Village")]
        public string village { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Country")]
        public string country { get; set; }
        [Display(Name = "Postal Code")]
        public string codePoste { get; set; }
        public byte?[] Photo { get; set; }
        public DateTime DateOfInscri { get; set; }

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