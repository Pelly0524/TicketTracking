using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketTracking.DB;
using TicketTracking.Models;

#pragma warning disable CS8600 // 正在將 Null 常值或可能的 Null 值轉換為不可為 Null 的型別。
#pragma warning disable CS8604 // 可能有 Null 參考引數。

namespace TicketTracking.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult ManagerView()
        {
            List<Bug> Bugs = DataBase.BugList();
            ViewBag.List = Bugs;

            return View("Views/ManagerView.cshtml");
        }

        [HttpGet]
        public IActionResult Bug_Resolve(string Id)
        {
            string userid = HttpContext.Session.GetString("id");
            DataBase.BugResolve(Id, userid);
            return ManagerView();
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Bug_Edit(string id)
        {
            string[] str = id.Split(',');
            TempData["Edit_id"] = str[0];
            TempData["Edit_name"] = str[1];
            TempData["Edit_statement"] = str[2];
            Bug_Edit bug_Edit = new Bug_Edit(str[0], str[1], str[2]);

            return new RedirectToActionResult("EditView", "Edit", bug_Edit);
        }

        [HttpGet]
        public IActionResult Bug_Delete(string Id)
        {
            string userid = HttpContext.Session.GetString("id");
            DataBase.BugDelete(Id, userid);

            return ManagerView();
        }
    }
}
