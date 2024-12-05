    using Exam.Entities;
    using Microsoft.EntityFrameworkCore;

namespace Exam.Context
{

    public class AppDbContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Examination> Examinations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Examinations)
                .WithOne(e => e.Lesson)
                .HasForeignKey(e => e.LessonId); 

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Examinations)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);
        }


    }

}
