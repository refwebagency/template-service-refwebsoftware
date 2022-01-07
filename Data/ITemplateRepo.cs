using System.Collections.Generic;
using TemplateService.Models;

namespace TemplateService.Data
{
    public interface ITemplateRepo
    {
        bool SaveChanges();

        void CreateTemplate(Template template);

        void CreateProjectTypeToTemplate(ProjectType projectType);

        IEnumerable<Template> GetAllTemplate();

        IEnumerable<ProjectType> GetAllProjectTypes();

        Template GetTemplateById(int id);

        void UpdateTemplateById(int id);

        void DeleteTemplateById(int id);
    }
}