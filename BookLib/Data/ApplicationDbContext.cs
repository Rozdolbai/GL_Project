using System;
using System.Collections.Generic;
using System.Text;
using BookLib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookLib.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
