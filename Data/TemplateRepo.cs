using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TemplateService.Models;

namespace TemplateService.Data
{
    public class TemplateRepo : ITemplateRepo
    {
        private readonly AppDbContext _context;

        public TemplateRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateTemplate(Template template)
        {
            if (template == null)
            {
                throw new ArgumentNullException(nameof(template));
            }

            _context.Add(template);
            _context.SaveChanges();
        }

        public void DeleteTemplateById(int id)
        {
            var template = _context.Template.FirstOrDefault(Template => Template.Id == id);

            if (template != null)
            {
                _context.Template.Remove(template);
            }
        }

        public IEnumerable<Template> GetAllTemplate()
        {
            return _context.Template.ToList();
        }

        public Template GetTemplateById(int id)
        {
            return _context.Template.FirstOrDefault(Template => Template.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTemplateById(int id)
        {
            var template = _context.Template.FirstOrDefault(Template => Template.Id == id);

            _context.Entry(template).State = EntityState.Modified;
        }
    }
}