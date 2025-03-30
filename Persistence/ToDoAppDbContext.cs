using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using System.Data.Entity;

namespace Persistence
{
    public class ToDoAppDbContext : IdentityDbContext<IdentityUser>
    {
        public Microsoft.EntityFrameworkCore.DbSet<ToDoTask> toDoTasks { get; set; }

        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
