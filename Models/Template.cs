using System.ComponentModel.DataAnnotations;

namespace TemplateService.Models
{
    public class Template
    {
        [Key]
        [Required]
        public int Id { get; set; }

        // public ProjectType

        // public TodoTemplate
    }
}