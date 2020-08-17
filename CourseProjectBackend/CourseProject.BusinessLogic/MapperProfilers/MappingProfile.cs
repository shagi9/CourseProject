using AutoMapper;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CourseProject.BusinessLogic.MapperProfilers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(u => u.UserName));

            CreateMap<User, GetAutorizedUserDto>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(u => u.UserName));
        }
    }
}
