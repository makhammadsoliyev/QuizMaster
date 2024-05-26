using QuizMaster.Domain.Commons;

namespace QuizMaster.Domain.Entities;

public class Question : Auditable
{
    public string Content { get; set; }
    public string MediaUrl { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
}
