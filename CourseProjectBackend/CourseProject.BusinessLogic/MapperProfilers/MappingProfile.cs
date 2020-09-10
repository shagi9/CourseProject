using AutoMapper;
using CourseProject.BusinessLogic.Dto.AuthDto;
using CourseProject.BusinessLogic.Dto.CourseDto;
using CourseProject.BusinessLogic.Vm;
using CourseProject.DataAccess.Entities;

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

            CreateMap<CourseToUser, CourseToUserViewModel>()
                .ForMember(course => course.Id, opt => opt.MapFrom(course => course.Course.Id))
                .ForMember(course => course.Name, opt => opt.MapFrom(course => course.Course.Name))
                .ForMember(course => course.StartDate, opt => opt.MapFrom(course => course.StartDate.ToString("d")))
                .ForMember(course => course.EndDate, opt => opt.MapFrom(course => course.EndDate.ToString("d")));

            CreateMap<AddCourseDto, Course>()
                .ForMember(course => course.Name, opt => opt.MapFrom(course => course.Name))
                .ForMember(course => course.Description, opt => opt.MapFrom(course => course.Description))
                .ForMember(course => course.ImgUrl, opt => opt.MapFrom(course => course.File));

            
            CreateMap<SubscribeToCourseDto, CourseToUser>()
                .ForMember(course => course.EndDate, opt => opt.MapFrom(course => course.StartDate.AddDays(14)));
            
            CreateMap<User, UserWithFullInfoViewModel>()
                .ForMember(user => user.RegistrationDate, opt => opt.MapFrom(user => user.RegistrationDate.ToString("d")))
                .ForMember(user => user.DateOfBirth, opt => opt.MapFrom(user => user.DateOfBirth.ToString("d")))
                .ForMember(user => user.UserName, opt => opt.MapFrom(user => user.UserName))
                .ForMember(user => user.FullName, opt => opt.MapFrom(user => $"{user.FirstName} {user.LastName}"));
        }
    }
}
