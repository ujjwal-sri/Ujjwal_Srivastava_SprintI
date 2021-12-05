using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ujjwal_Srivastava_Sprint_I.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty taskss, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ujjwal_Srivastava_Sprint_I.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        List<Tasks> tasksList = new List<Tasks> {
            new Tasks{ID=1,ProjectID=1,Status=2,AssiignedToUserID=1,Detail="This is a test task",CreatedOn=new DateTime(2021, 2, 12, 0, 0, 00) },
            new Tasks{ID=2,ProjectID=1,Status=3,AssiignedToUserID=2,Detail="This is a test task",CreatedOn=new DateTime(2021, 2, 12, 0, 0, 00) },
            new Tasks{ID=3,ProjectID=2,Status=4,AssiignedToUserID=2,Detail="This is a test task",CreatedOn=new DateTime(2021, 2, 12, 0, 0, 00) }
        };


        [HttpPost]
        [Route("/tasks/create")]
        public ActionResult Createtasks(Tasks tasks)
        {
            if (tasksList.FirstOrDefault(x => x.ID == tasks.ID) == null)
            {
                tasksList.Add(tasks);
            }
            else
            {
                return BadRequest("ID must be unique");
            }
            return Ok();
        }

        [HttpGet]
        [Route("/tasks/get")]
        public ActionResult<List<Tasks>> GetAlltasks()
        {
            return Ok(tasksList);
        }

        [HttpGet]
        [Route("tasks/get/{id}")]
        public ActionResult<Tasks> GettasksFromId(int id)
        {
            var tasks = tasksList.FirstOrDefault(x => x.ID == id);
            if (tasks == null)
            {
                return BadRequest("tasks doesn't exist");
            }
            return Ok(tasks);
        }

        [HttpPut]
        [Route("tasks/update")]
        public ActionResult Updatetasks(Tasks tasks)
        {
            var tasks1 = tasksList.FirstOrDefault(x => x.ID == tasks.ID);
            if (tasks1 == null)
            {
                return BadRequest("ID not present");
            }
            tasks1.ID = tasks.ID;
            tasks1.ProjectID = tasks.ProjectID;
            tasks1.Status = tasks.Status;
            tasks1.AssiignedToUserID = tasks.AssiignedToUserID;
            tasks1.Detail = tasks.Detail;
            tasks1.CreatedOn = tasks.CreatedOn;
            return Ok("tasks updated successfully");
        }
    }
}
