using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ScrumPRO.Models;
using ScrumPRO.DTO;

namespace ScrumPRO
{
    public class AutoMapp : Profile
    {
        public AutoMapp()
        {
            CreateMap<Company, DTOCompany>();
            CreateMap<ApplicationUser, DTOAppUser>();
            CreateMap<Project, DTOProject>();
            CreateMap<Story, DTOStory>();
            CreateMap<StoryTask, DTOStoryTask>();
            CreateMap<Comment, DTOComment>();
            CreateMap<DailyReport, DTODailyReport>();
            CreateMap<Sprint, DTOSprint>();
        }
    }
}