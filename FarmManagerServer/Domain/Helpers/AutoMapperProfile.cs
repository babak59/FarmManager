using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegistrationDto, User>();
        }
    }
}
