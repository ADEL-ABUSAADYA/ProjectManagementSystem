using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementSystem.Models
{
    [Table("Instructor")]
    public class Instructor : BaseModel
    {
        public Instructor() 
        {
            InstructorCourses = new List<InstructorCourse>();
        }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Adress { get; set; }

        public ICollection<InstructorCourse> InstructorCourses { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Group> Groups { get; set; }

    }
}
