using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AnimalShelter.Data
{
    public enum UserType { customer, company, vet }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public UserType UserType { get; set; }

        public string FullName { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public virtual List<Vaccine> Vaccines { get; set; }

        public virtual List<Animal> Animals { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<UserRating> Ratings { get; set; } = new List<UserRating>();

        public double TotalAverageRating
        {
            get
            {
                double TotalAverageRating = 0;
                foreach (var rating in Ratings)
                {
                    TotalAverageRating += rating.AverageRating;
                }
                return (Ratings.Count > 0) ? TotalAverageRating / Ratings.Count : 0;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here            
            return userIdentity;
        }
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

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserRating> Ratings { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}