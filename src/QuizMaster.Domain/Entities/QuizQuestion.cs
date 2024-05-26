using QuizMaster.Domain.Commons;

namespace QuizMaster.Domain.Entities;

public class QuizQuestion : Auditable
{
    public long QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public long QuestionId { get; set; }
    public Question Question { get; set; }
}
