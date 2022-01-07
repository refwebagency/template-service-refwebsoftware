using System;
using Microsoft.AspNetCore.Mvc;
using TemplateService.Models;
using TemplateService.Data;
using TemplateService.Dtos;
using AutoMapper;
using System.Collections.Generic;
using System.Text.Json;

namespace TemplateService.Controllers
{
    [Route("template/[controller]")]
    [ApiController]
    public class ProjectTypeController : ControllerBase
    {
        private readonly ITemplateRepo _repository;

        private readonly IMapper _mapper;
        
        public ProjectTypeController(ITemplateRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadProjectTypeDto>> GetAllProjectTypes()
        {
            var projectTypes = _repository.GetAllProjectTypes();
            return Ok(_mapper.Map<IEnumerable<ReadProjectTypeDto>>(projectTypes));
        }

        [HttpPost]
        public ActionResult testCommunicationBetweenServices(ProjectType projectType)
        {
            var projectTypeModel = _mapper.Map<ProjectType>(projectType);

            _repository.CreateProjectTypeToTemplate(projectTypeModel);
            _repository.SaveChanges();


            Console.WriteLine(projectType);
            Console.WriteLine(projectTypeModel);
            Console.WriteLine("Requete POST pour ProjectTypeController dans TemplateService");

            return Ok("Ok test Communication Between Services");


        }
    }
}