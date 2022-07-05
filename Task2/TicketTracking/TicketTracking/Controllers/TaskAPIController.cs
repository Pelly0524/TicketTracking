using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketTracking.DB;

namespace TicketTracking.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskAPIController : Controller
    {
        [Route("welcome")]
        [HttpGet]
        public IActionResult Welcome()
        {
            return Json("This is the Welcome Action : Hello, !!");
        }

        [Route("bugs")]
        [HttpGet]
        public IActionResult BugList()
        {
            string sql = @$" SELECT * FROM `bugs`";
            DataTable dt = DataBase.SQLExecute(sql);

            return Json(dt);
        }
    }
}
