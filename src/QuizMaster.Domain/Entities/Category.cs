using QuizMaster.Domain.Commons;

namespace QuizMaster.Domain.Entities;

public class Category : Auditable
{
    public string Name { get; set; }
}
