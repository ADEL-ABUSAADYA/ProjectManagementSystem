using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Data;
public class Context : DbContext
{
    // Users Management

    public DbSet<Group> Groups { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    
    public DbSet<InstructorCourse> InstructorsCourse { get; set;}
    public DbSet<StudentCourse> StudentsCourses { get; set; }
    public DbSet<StudentExam> StudentExams { get; set; }
    public DbSet<ExamQuestion> ExamQuestions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserFeature> UserFeatures { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = HotelReservationSystem; Integrated Security = True; Connect Timeout = 30; Encrypt=True;Trust Server Certificate=True;Application Intent = ReadWrite; Multi Subnet Failover=False")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
            .EnableSensitiveDataLogging();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Instructor>().ToTable("Instructor");
    }
}
//Data Source =.; Initial Catalog = HotelReservationSystem; Integrated Security = True; Connect Timeout = 30; Encrypt=True;Trust Server Certificate=True;Application Intent = ReadWrite; Multi Subnet Failover=False