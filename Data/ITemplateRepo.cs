using System.Collections.Generic;
using TemplateService.Models;

namespace TemplateService.Data
{
    public interface ITemplateRepo
    {
         bool SaveChanges();

        void CreateTemplate(Template template);

        IEnumerable<Template> GetAllTemplate();

        Template GetTemplateById(int id);

        void UpdateTemplateById(int id);

        void DeleteTemplateById(int id);
    }
}