using AutoMapper;
using QuizMaster.Domain.Entities;
using QuizMaster.Service.DTOs.Users;

namespace QuizMaster.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();
    }
}
