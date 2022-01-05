using System;
using Microsoft.AspNetCore.Mvc;

namespace TemplateService.Controllers
{
    [Route("template/[controller]")]
    [ApiController]
    public class ProjectTypeController : ControllerBase
    {
        public ProjectTypeController()
        {

        }

        [HttpPost]
        public ActionResult testCommunicationBetweenServices()
        {
            Console.WriteLine("Requete POST pour ProjectTypeController dans TemplateService");

            return Ok("Ok test Communication Between Services");
        }
    }
}