using AutoMapper;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Dto.CourseDto;
using CourseProject.BusinessLogic.Vm;
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
                .ForMember(user => user.UserName, opt => opt.MapFrom(user => user.UserName));

            CreateMap<User, GetAutorizedUserDto>()
                .ForMember(user => user.UserName, opt => opt.MapFrom(user => user.UserName));

            CreateMap<Course, CourseViewModel>();

            CreateMap<CourseToUser, SubscribeToCourseViewModel>();

            CreateMap<SubscribeToCourseDto, CourseToUser>()
                .ForMember(course => course.EndDate, opt => opt.MapFrom(course => course.StartDate.AddDays(14)));
        }
    }
}
