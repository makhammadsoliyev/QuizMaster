using QuizMaster.Domain.Commons;

namespace QuizMaster.Domain.Entities;

public class QuizResult : Auditable
{
    public long QuizApplicationId { set; get; }
    public QuizApplication QuizApplication { set; get; }
    public int CorrectAnswers { get; set; }
}