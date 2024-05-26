using QuizMaster.Domain.Commons;
using QuizMaster.Domain.Enums;

namespace QuizMaster.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public Role Role { get; set; }
}
