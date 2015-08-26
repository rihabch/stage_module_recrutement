using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Recrute.Controllers;

namespace Recrute.Models
{
    public class RecruteContext : DbContext
    {
        public RecruteContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<InternshipOffer> Internships { get; set; }
        public DbSet<JobOffer> Jobs { get; set; }

    }
}