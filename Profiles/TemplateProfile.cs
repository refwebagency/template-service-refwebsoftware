using AutoMapper;
using TemplateService.Dtos;
using TemplateService.Models;

namespace TemplateService.Profiles
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {
            CreateMap<Template, ReadTemplateDTO>();
            CreateMap<CreateTemplateDTO, Template>();
            CreateMap<UpdateTemplateDTO, Template>();
        }
    }
}