using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ScheduleIt2._0.Models;

[assembly: OwinStartupAttribute(typeof(ScheduleIt2._0.Startup))]
namespace ScheduleIt2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
                    //IHostingEnvironment env,
                    //ApplicationDbContext context,
                    //UserManager<ApplicationUser> userManager)
        {
            ConfigureAuth(app);
            DummyUsers();
            //DummyUsers.Initialize(context, userManager).Wait(); //seed users
        }

        //services.AddIdentity<ApplicationUser>
        //    (options => AppDomainManagerInitializationOptions.Stores.MaxLengthForKeys = 128)
        //    .AddEntityFrameworkStores<ApplicationDbContext>()
        //    .AddDefaultUI()
        //    .AddDefaultTokenProviders();

        private void DummyUsers()
        {
            //async Task Initialize(ApplicationDbContext context,
                                  //UserManager<ApplicationUser> userManager)
            {
                //context.Database.EnsureCreated();

                ApplicationDbContext context = new ApplicationDbContext();

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                string password = "Password1!";

                if (userManager.FindByName("1@dummy.com") == null)
                {
                    var dummy = new ApplicationUser
                    {
                        UserName = "1@dummy.com",
                        Email = "1@dummy.com",
                        Fname = "Celery",
                        Lname = "Camelson",
                        Id = "1",
                        BirthDate = DateTime.Now,
                        Address = "Denim Barn",
                        FullTime = false,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        HourlyRate = 500,
                        Status = null
                    };

                    var result = userManager.Create(dummy, password);
                    
                }

                if (userManager.FindByName("2@dummy.com") == null)
                {
                    var dummy = new ApplicationUser
                    {
                        UserName = "2@dummy.com",
                        Email = "2@dummy.com",
                        Fname = "Ribbit",
                        Lname = "Leonards",
                        Id = "2",
                        BirthDate = DateTime.Now,
                        Address = "Cheesecake Factory",
                        FullTime = true,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        HourlyRate = 600,
                        Status = null
                    };

                    var result = userManager.Create(dummy, password);
                    
                }

                if (userManager.FindByName("3@dummy.com") == null)
                {
                    var dummy = new ApplicationUser
                    {
                        UserName = "3@dummy.com",
                        Email = "3@dummy.com",
                        Fname = "Sleve",
                        Lname = "McDichael",
                        Id = "3",
                        BirthDate = DateTime.Now,
                        Address = "Olive Garden",
                        FullTime = false,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        HourlyRate = 300,
                        Status = null
                    };

                    var result = userManager.Create(dummy, password);
                    
                }

                if (userManager.FindByName("4@dummy.com") == null)
                {
                    var dummy = new ApplicationUser
                    {
                        UserName = "4@dummy.com",
                        Email = "4@dummy.com",
                        Fname = "Sprenk",
                        Lname = "Chumney",
                        Id = "4",
                        BirthDate = DateTime.Now,
                        Address = "Papa Jonathans'",
                        FullTime = false,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        HourlyRate = 800,
                        Status = null
                    };

                    var result = userManager.Create(dummy, password);
                    
                }

                if (userManager.FindByName("5@dummy.com") == null)
                {
                    var dummy = new ApplicationUser
                    {
                        UserName = "5@dummy.com",
                        Email = "5@dummy.com",
                        Fname = "Jammy",
                        Lname = "Lumbo",
                        Id = "5",
                        BirthDate = DateTime.Now,
                        Address = "Chuck E Cheese",
                        FullTime = true,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        HourlyRate = 600,
                        Status = null
                    };

                    var result = userManager.Create(dummy, password);
                    
                }
            }
        }
    }
}
