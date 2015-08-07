using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Recrute.Models
{
    [Table("Users")] // Table nam
    public class User
    {
        public User()
        {
            DateOfInscri = DateTime.Now;
            
        }
        [Key] // Primary key
        public int userID { get; set; }
        public string userName { get; set; }
        public string userFirstName { get; set; }
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        public string password { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string nationality { get; set; }
        public string placeOfBirth { get; set; }
        public string famSituation { get; set; }
        public int? phoneNum { get; set; }
        public int? gsmNum { get; set; }
        public string adress { get; set; }
        public string village { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string codePoste { get; set; }
        public byte?[] Photo { get; set; }
        public DateTime DateOfInscri { get; set; }

        //[ForeignKey("TypeUsers")]
        public int typeID { get; set; }

        public virtual TypeUsers type { get; set; }
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

    public class RecruteContext : DbContext
    {
        public RecruteContext()
            : base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TypeUsers> Types { get; set; }

    }
}