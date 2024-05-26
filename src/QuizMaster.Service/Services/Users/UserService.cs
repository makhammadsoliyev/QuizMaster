using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizMaster.DataAccess.Repositories;
using QuizMaster.Domain.Entities;
using QuizMaster.Service.DTOs.Users;

namespace QuizMaster.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IRepository<User> repository;
    public UserService(IMapper mapper, IRepository<User> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<UserResultDto> CreateAsync(UserCreateDto createDto)
    {
        var mappedUser = mapper.Map<User>(createDto);
        var createdUser = await repository.InsertAsync(mappedUser);
        return mapper.Map<UserResultDto>(createdUser);
    }

    public async Task<UserResultDto> ModifyAsync(long id, UserUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<UserResultDto> RetrieveAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync()
    {
        var result = await repository.SelectAll().ToListAsync();
        return mapper.Map<IEnumerable<UserResultDto>>(result);
    }
}
