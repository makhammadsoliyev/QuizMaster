using QuizMaster.Domain.Commons;

namespace QuizMaster.Domain.Entities;

public class QuizApplication : Auditable
{
    public long QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
