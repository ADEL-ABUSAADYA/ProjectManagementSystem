using ProjectManagementSystem.Common.Data.Enums;

namespace ProjectManagementSystem.Models;

public class Exam : BaseModel
{
    public string Name { get; set; }
    public int MaxNumberOfQuestions { get; set; }
    public int MaxTime { get; set; }
    public DateTime Date { get; set; }
    public ExamType ExamType { get; set; }

    public int InstructorId { get; set; }
    public ICollection<ExamQuestion> ExamQuestions { get; set; }
    public ICollection<StudentExam> ExamAssignments { get; set; }
}