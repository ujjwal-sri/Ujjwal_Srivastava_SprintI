using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ujjwal_Srivastava_Sprint_I.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ujjwal_Srivastava_Sprint_I.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        List<Project> projectList = new List<Project>
        {
            new Project{ID=1, Name="TestProject1", Detail="This is a test project", CreatedOn=new DateTime(2021, 2, 12, 0, 0, 00) },
            new Project{ID=2, Name="TestProject2", Detail="This is a test project", CreatedOn=new DateTime(2021, 2, 12, 0, 0, 00) },
            new Project{ID=3, Name="TestProject2", Detail="This is a test project", CreatedOn=new DateTime(2021, 2, 12, 0, 0, 00) },
            new Project{ID=4, Name="TestProject2", Detail="This is a test project", CreatedOn=new DateTime(2021, 2, 12, 0, 0, 00) }
        };


        [HttpPost]
        [Route("/project/create")]
        public ActionResult CreateProject(Project project)
        {
            if (projectList.FirstOrDefault(x => x.ID == project.ID) == null)
            {
                projectList.Add(project);
            }
            else
            {
                return BadRequest("ID must be unique");
            }
            return Ok();
        }

        [HttpGet]
        [Route("/project/get")]
        public ActionResult<List<Project>> GetAllProject()
        {
            return Ok(projectList);
        }

        [HttpGet]
        [Route("project/get/{id}")]
        public ActionResult<Project> GetProjectFromId(int id)
        {
            var project = projectList.FirstOrDefault(x => x.ID == id);
            if (project == null)
            {
                return BadRequest("Project doesn't exist");
            }
            return Ok(project);
        }

        [HttpPut]
        [Route("project/update")]
        public ActionResult UpdateProject(Project project)
        {
            var proj = projectList.FirstOrDefault(x => x.ID == project.ID);
            if (proj == null)
            {
                return BadRequest("ID not present");
            }
            proj.Name = project.Name;
            proj.Detail = project.Detail;
            proj.CreatedOn = project.CreatedOn;
            return Ok("Project updated successfully");
        }
    }
}
