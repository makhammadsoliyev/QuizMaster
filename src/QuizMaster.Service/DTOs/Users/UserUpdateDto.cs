namespace QuizMaster.Service.DTOs.Users;

public record UserUpdateDto(string FirstName,
                            string LastName,
                            string UserName,
                            string Phone);
