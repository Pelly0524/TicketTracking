using Microsoft.AspNetCore.Mvc;
using TicketTracking.DB;
using TicketTracking.Models;

#pragma warning disable CS8600 // 正在將 Null 常值或可能的 Null 值轉換為不可為 Null 的型別。
#pragma warning disable CS8604 // 可能有 Null 參考引數。

namespace TicketTracking.Controllers
{
    public class CreateController : Controller
    {
        public IActionResult CreateView()
        {
            Bug_Create bug = new Bug_Create();
            return View("Views/CreateView.cshtml", bug);
        }

        [HttpPost]
        public IActionResult CreateBug(Bug_Create bug) 
        {
            string userid = HttpContext.Session.GetString("id");
            DataBase.BugCreate(bug.name, bug.statement, userid);
            return new RedirectResult(url: "/Manager/ManagerView", permanent: true, preserveMethod: true);
        }
    }
}
