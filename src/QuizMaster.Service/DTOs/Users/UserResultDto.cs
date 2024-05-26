using QuizMaster.Domain.Enums;

namespace QuizMaster.Service.DTOs.Users;

public record UserResultDto(long Id,
                            string FirstName,
                            string LastName,
                            string UserName,
                            string Phone,
                            Role Role);
