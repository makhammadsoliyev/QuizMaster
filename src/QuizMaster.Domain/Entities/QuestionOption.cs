using QuizMaster.Domain.Commons;

namespace QuizMaster.Domain.Entities;

public class QuestionOption : Auditable
{
    public string Content { get; set; }
    public long QuestionId { get; set; }
    public Question Question { get; set; }
    public bool IsCorrect { get; set; }
}
