using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timothy_Hsu_MVC.Models;

namespace Timothy_Hsu_MVC.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
        }
        public DbSet<ScrumStatus> ScrumStatuses { get; set; }
        public DbSet<ScrumTask> ScrumTasks { get; set; }
        public DbSet<ScrumUser> ScrumUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScrumStatus>().HasData(
                new ScrumStatus() { Id = 1, Name = "Not Checked Out"},
                new ScrumStatus() { Id = 2, Name = "Checked Out"},
                new ScrumStatus() { Id = 3, Name = "Done"}
                );
            modelBuilder.Entity<ScrumUser>().HasData(
                new ScrumUser() { Id = 1, Name="Bill" },
                new ScrumUser() { Id = 2, Name = "Tim" },
                new ScrumUser() { Id = 3, Name = "Alex" }
                );
            modelBuilder.Entity<ScrumTask>().HasData(
                new ScrumTask() { Id = 1, Title = "Fix bug #1235", Description="Fix bug that causes crash" ,ScrumStatusId=1},
                new ScrumTask() { Id = 2, Title = "Fix bug #5425", Description="Fix bug that causes wrong View to be shown", ScrumStatusId = 1 },
                new ScrumTask() { Id = 3, Title = "Implement new feature", Description="Write new code for new feature", ScrumStatusId = 2, ScrumUserId=1 },
                new ScrumTask() { Id = 4, Title = "Clean toilets", Description="The toilets must be cleaned", ScrumStatusId = 1 },
                new ScrumTask() { Id = 5, Title = "Buy a new laptop", Description="Buy a new laptop for our new employee", ScrumStatusId = 3, ScrumUserId=3 }
                );
        }
    }
}
