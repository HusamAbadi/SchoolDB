using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolDBProg
{
    internal class SchoolDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; }=null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SchoolDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Dictionary<string, object>>(
                "StudentCourses",
                sc => sc.HasOne<Course>()
                .WithMany()
                .HasForeignKey("CourseId"),
                sc => sc.HasOne<Student>()
                .WithMany()
                .HasForeignKey("StudentId"),
                sc => sc.HasData(
                    new { StudentId=1, CourseId=1},
                    new { StudentId=1, CourseId=2},
                    new { StudentId=2, CourseId=1}));
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "Mathematics" },
                new Course { CourseId = 2, CourseName = "Databases" });
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "John" },
                new Student { StudentId = 2, Name = "Susan" });
        }
    }
}
