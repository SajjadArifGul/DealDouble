using DealDouble.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Data
{
    public class DealDoubleDBInitializer : CreateDatabaseIfNotExists<DealDoubleContext>
    {
        protected override void Seed(DealDoubleContext context)
        {
            SeedRoles(context);
            SeedUsers(context);

            SeedConfigurations(context);
        }

        public void SeedRoles(DealDoubleContext context)
        {
            List<IdentityRole> rolesInDealDouble = new List<IdentityRole>();

            rolesInDealDouble.Add(new IdentityRole() { Name = "Administrator" });
            rolesInDealDouble.Add(new IdentityRole() { Name = "Moderator" });
            rolesInDealDouble.Add(new IdentityRole() { Name = "User" });

            var rolesStore = new RoleStore<IdentityRole>(context);
            var rolesManager = new RoleManager<IdentityRole>(rolesStore);

            foreach (IdentityRole role in rolesInDealDouble)
            {
                if (!rolesManager.RoleExists(role.Name))
                {
                    var result = rolesManager.Create(role);

                    if (result.Succeeded) continue;
                }
            }
        }

        public void SeedUsers(DealDoubleContext context)
        {
            var usersStore = new UserStore<DealDoubleUser>(context);
            var usersManager = new UserManager<DealDoubleUser>(usersStore);

            DealDoubleUser admin = new DealDoubleUser();
            admin.Email = "admin@email.com";
            admin.UserName = "admin";
            var password = "admin123";

            if (usersManager.FindByEmail(admin.Email) == null)
            {
                var result = usersManager.Create(admin, password);

                if (result.Succeeded)
                {
                    //add necessary roles to admin
                    usersManager.AddToRole(admin.Id, "Administrator");
                    usersManager.AddToRole(admin.Id, "Moderator");
                    usersManager.AddToRole(admin.Id, "User");
                }
            }
        }


        public void SeedConfigurations(DealDoubleContext context)
        {
            Configuration slider1Config = new Configuration()
            {
                Key = "Slider1",
                Value = "site/slider/slider1.png",
                ConfigurationType = (int)ConfigurationType.HomeSliders,
                ModifiedOn = DateTime.Now
            };

            Configuration slider2Config = new Configuration()
            {
                Key = "Slider2",
                Value = "site/slider/slider2.png",
                ConfigurationType = (int)ConfigurationType.HomeSliders,
                ModifiedOn = DateTime.Now
            };

            Configuration slider3Config = new Configuration()
            {
                Key = "Slider3",
                Value = "site/slider/slider3.png",
                ConfigurationType = (int)ConfigurationType.HomeSliders,
                ModifiedOn = DateTime.Now
            };

            Configuration slider4Config = new Configuration()
            {
                Key = "Slider4",
                Value = "site/slider/slider4.png",
                ConfigurationType = (int)ConfigurationType.HomeSliders,
                ModifiedOn = DateTime.Now
            };
            
            Configuration dashboardRecordsSizePerPageConfig = new Configuration()
            {
                Key = "DashboardRecordsSizePerPage",
                Value = "10",
                ConfigurationType = (int)ConfigurationType.Other,
                ModifiedOn = DateTime.Now
            };
            
            Configuration frontendRecordsSizePerPageConfig = new Configuration()
            {
                Key = "FrontendRecordsSizePerPage",
                Value = "6",
                ConfigurationType = (int)ConfigurationType.Other,
                ModifiedOn = DateTime.Now
            };
            
            Configuration featuredRecordsSizePerPageConfig = new Configuration()
            {
                Key = "FeaturedRecordsSizePerPage",
                Value = "3",
                ConfigurationType = (int)ConfigurationType.Other,
                ModifiedOn = DateTime.Now
            };

            context.Configurations.AddRange(new List<Configuration> { slider1Config, slider2Config, slider3Config, slider4Config, dashboardRecordsSizePerPageConfig, frontendRecordsSizePerPageConfig, featuredRecordsSizePerPageConfig });

            context.SaveChanges();
        }
    }
}
