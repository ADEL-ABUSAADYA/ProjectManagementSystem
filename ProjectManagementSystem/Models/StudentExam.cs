namespace ProjectManagementSystem.Models;
public class StudentExam : BaseModel
{
    public bool IsCompleted { get; set; }
    public int Score { get; set; }
    public string Message { get; set; }

    // Foreign Keys
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int ExamId { get; set; }
    public Exam Exam { get; set; }
}