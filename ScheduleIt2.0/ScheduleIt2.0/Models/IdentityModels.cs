using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ScheduleIt2._0.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Fname", Fname));  //claims to call first and last names added
            userIdentity.AddClaim(new Claim("Lname", Lname));

            return userIdentity;
        }


        /// <summary>
        /// First name property
        /// </summary>
        [Display(Name = "First Name"), Required]
        public string Fname { get; set; }
        /// <summary>
        /// Last name property
        /// </summary>
        public string Lname { get; set; }
        /// <summary>
        /// Date of birth property
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// address property
        /// </summary>
        public string Address { get; set; }
        /// <sumary>
        /// bool full time property
        /// </sumary>
        public bool FullTime { get; set; }
        /// <summary>
        /// employee start date property
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// employee end date property
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// hourly rate property
        /// </summary>
        public decimal HourlyRate { get; set; }
        /// <summary>
        /// employee work status property 
        /// </summary>
        public string Status { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<EventModel> EventModels { get; set; }
        public DbSet<WorkTimeEventModel> WorkTimeEventModels { get; set; }
        public DbSet<TimeOffEvent> TimeOffEvents { get; set; }
        public DbSet<MessageSystem> MessageSystems { get; set; }

        public DbSet<EmailModel> EmailModels { get; set; }

       // public System.Data.Entity.DbSet<ScheduleIt2._0.Models.TimeOffEvent> TimeOffEvents { get; set; }
    }
}