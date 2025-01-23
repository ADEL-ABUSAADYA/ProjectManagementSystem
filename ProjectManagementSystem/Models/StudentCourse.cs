namespace ProjectManagementSystem.Models;
public class StudentCourse : BaseModel
{
    public int StudentID { get; set; }
    public Student Student { get; set; } = default!;
    public int CourseID { get; set; }
    public Course Course { get; set; } = default!;
    public DateTime EnrollmentDate { get; set; }
    
}