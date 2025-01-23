namespace ProjectManagementSystem.Models;

public class Group : BaseModel
{
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public int InstructorID { get; set; }
    public Instructor Instructor { get; set; }
    public int CourseID { get; set; }
    public Course Course { get; set; }

}