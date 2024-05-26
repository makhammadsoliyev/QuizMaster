using QuizMaster.Domain.Commons;

namespace QuizMaster.Domain.Entities;

public class QuestionAnswer : Auditable
{
    public long QuizApplicationId { get; set; }
    public QuizApplication QuizApplication { get; set; }
    public long QuestionOptionId { get; set; }
    public QuestionOption QuestionOption { get; set; }
}
