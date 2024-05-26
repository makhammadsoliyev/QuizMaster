namespace QuizMaster.Service.DTOs.Users;

public record UserCreateDto(string FirstName,
                            string LastName,
                            string UserName,
                            string Phone);
