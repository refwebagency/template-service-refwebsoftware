using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TemplateService.Data;
using TemplateService.Dtos;
using TemplateService.Models;

namespace TemplateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateRepo _repository;
        private readonly IMapper _mapper;

        public TemplateController(ITemplateRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadTemplateDTO>> GetAllTemplate()
        {
            var templateItems = _repository.GetAllTemplate();

            return Ok(_mapper.Map<IEnumerable<ReadTemplateDTO>>(templateItems));
        }

        [HttpGet("{id}", Name = "GetTemplateById")]
        public ActionResult<ReadTemplateDTO> GetTemplateById(int id)
        {
            var templateItem = _repository.GetTemplateById(id);

            if (templateItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReadTemplateDTO>(templateItem));
        }

        [HttpPost]
        public ActionResult<CreateTemplateDTO> CreateTemplate(CreateTemplateDTO templateDTO)
        {
            var templateModel = _mapper.Map<Template>(templateDTO);

            _repository.CreateTemplate(templateModel);
            _repository.SaveChanges();

            var readTemplate = _mapper.Map<ReadTemplateDTO>(templateModel);

            return CreatedAtRoute(nameof(GetTemplateById), new {id = readTemplate.Id }, readTemplate);
        }

        [HttpPut("{id}", Name = "UpdateTemplateById")]
        public ActionResult<UpdateTemplateDTO> UpdateTemplateById(int id, UpdateTemplateDTO templateDTO)
        {
            var templateItem = _repository.GetTemplateById(id);

            _mapper.Map(templateDTO, templateItem);

            if (templateItem == null)
            {
                return NotFound();
            }

            _repository.UpdateTemplateById(id);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetTemplateById), new {id = templateDTO.Id }, templateDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTemplateById(int id)
        {
            var templateItem = _repository.GetTemplateById(id);

            if (templateItem == null)
            {
                return NotFound();
            }

            _repository.DeleteTemplateById(templateItem.Id);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}