using ProjectManagementSystem.Common.Data.Enums;

namespace ProjectManagementSystem.Models
{
    public class Question : BaseModel
    {
        public string Body { get; set; }
        public int Mark { get; set; }
        public QuestionLevel Level { get; set; }

        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
