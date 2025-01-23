namespace ProjectManagementSystem.Models;

public class Answer : BaseModel
{
    public string Body { get; set;}
    public bool IsCorrect { get; set; }
    public int QuestionID { get; set; }
    public Question Question { get; set; }
}
