using AutoMapper;
using BusinessLayer.Requests.Course;
using BusinessLayer.Requests.Enrollment;
using BusinessLayer.Requests.Lesson;
using BusinessLayer.Requests.LessonResource;
using BusinessLayer.Requests.Module;
using BusinessLayer.Responses.Course;
using BusinessLayer.Responses.Lesson;
using BusinessLayer.Responses.LessonResource;
using BusinessLayer.Responses.Module;
using DataAccessLayer.Entities;

namespace PresentationLayer.MyMapper
{
    public class MapperConfigurationProfile : Profile
    {
        public MapperConfigurationProfile()
        {
            //User

            //Enrollment
            CreateMap<CreateNewEnrollementRequest, Enrollment>();

            //Course
            CreateMap<CreateNewCourseRequest, Course>();
            CreateMap<Course, CourseResponse>();
            CreateMap<UpdateCourseRequest, Course>();
            CreateMap<Course, GetAllCourseForAdminResponse>();
            CreateMap<Course, StudentCourseDetailResponse>();

            //Lesson
            CreateMap<CreateNewLessonForModuleRequest, Lesson>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Content));
            CreateMap<UpdateLessonRequest, Lesson>();
            CreateMap<Lesson, LessonResponse>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Description));
            CreateMap<Lesson, LessonDetailResponse>();

            //LessonResource
            CreateMap<CreateLessonResourceRequest, LessonResource>();
            CreateMap<LessonResource, LessonResourceResponse>();

            //Module
            CreateMap<CreateNewModuleForCourseRequest, Module>();
            CreateMap<UpdateModuleRequest, Module>();
            CreateMap<Module, ModuleResponse>();

        }
    }
}
