﻿using Jobpost.API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jobpost.API.Database
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Jobposting> Jobposts { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<User> User { get; set; }

    }

}
