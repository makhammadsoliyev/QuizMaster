using QuizMaster.Service.DTOs.Users;

namespace QuizMaster.Service.Services.Users;

public interface IUserService
{
    Task<UserResultDto> CreateAsync(UserCreateDto createDto);
    Task<UserResultDto> ModifyAsync(long id, UserUpdateDto updateDto);
    Task<bool> RemoveAsync(long id);
    Task<UserResultDto> RetrieveAsync(long id);
    Task<IEnumerable<UserResultDto>> RetrieveAllAsync();
}
