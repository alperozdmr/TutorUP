using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorUP.EntityLayer.Entity;

namespace TutorUP.DataAccessLayer.Concrete
{
    public class TutorUpDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AMHHP22\\MSSQLSERVER01;Initial Catalog=TutorUpDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }

        public DbSet<BookALesson> BookALessons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ForumComment> ForumComments { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; } 
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // AppUser → Lesson: Silme kısıtlı (Restrict)
            builder.Entity<Lesson>()
                .HasOne(l => l.AppUser)
                .WithMany(u => u.Lesson)
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Lesson → BookALesson: Kaskadlı silme
            builder.Entity<BookALesson>()
                .HasOne(b => b.Lesson)
                .WithMany(l => l.BookALesson)
                .HasForeignKey(b => b.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser → BookALesson: Silme kısıtlı (Restrict)
            builder.Entity<BookALesson>()
                .HasOne(b => b.AppUser)
                .WithMany(u => u.BookALessons)
                .HasForeignKey(b => b.UserID)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
