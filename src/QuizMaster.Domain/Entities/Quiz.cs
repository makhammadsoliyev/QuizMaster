using QuizMaster.Domain.Commons;

namespace QuizMaster.Domain.Entities;

public class Quiz : Auditable
{
    public string Name { get; set; }
    public int Count { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public int TimePerQuestion { get; set; }
    public DateTime StartTime { get; set; }
}
