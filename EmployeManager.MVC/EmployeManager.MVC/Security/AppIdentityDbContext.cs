﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeManager.MVC.Security
{
     public class AppIdentityDbContext: IdentityDbContext<AppIdentityUser,AppIdentityRole,string> 
     {
        public AppIdentityDbContext (DbContextOptions<AppIdentityDbContext> options) : base(options)
        { }

    }
}

