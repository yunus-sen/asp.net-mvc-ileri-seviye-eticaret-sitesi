using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Abc.MvcWebUI.Identity
{
    public class IdentityInitializer: CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            RoleManager<ApplicationRole> roleManager;
            roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            UserManager<ApplicationUser> userManager;
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
               
                roleManager.Create(new ApplicationRole()
                {
                    Description = "yönetici rolü",
                    Name = "admin"
                });
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                
                roleManager.Create(new ApplicationRole()
                {
                    Description = "kullanıcı rolü",
                    Name = "user"
                });
            }

            if (!context.Users.Any(i => i.Name == "Yunussen"))
            {
               
                var user = new ApplicationUser()
                {
                    Name = "yunussen",
                    SurName = "sen",
                    Email = "yunussen2727@gmail.com",
                    UserName = "yunussen",
                    
                };
                userManager.Create(user, "1234567@aA");
                userManager.AddToRole(user.Id, "admin");
                userManager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.Name == "ahmetsen"))
            {
              
                var user = new ApplicationUser()
                {
                    Name = "ahmetsen",
                    SurName = "sen",
                    Email = "ahmetsen2727@gmail.com",
                    UserName = "ahmetsen",

                };
                userManager.Create(user, "1234567@aA");
                userManager.AddToRole(user.Id, "user");
            }
            base.Seed(context); 
        }
    }
}