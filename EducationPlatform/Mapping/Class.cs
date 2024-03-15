using AutoMapper;
using EducationPlatform.DTOs;
using EducationPlatform.Entities;

namespace EducationPlatform.Mapping
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<User, UserDto>()
                 .ForMember(x => x.FirstName, opts => opts.MapFrom(s => s.Email))
                 .ReverseMap();

        }
    }
}