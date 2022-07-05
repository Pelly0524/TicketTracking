using Microsoft.AspNetCore.Mvc;
using TicketTracking.DB;
using TicketTracking.Models;

#pragma warning disable CS8600 // 正在將 Null 常值或可能的 Null 值轉換為不可為 Null 的型別。
#pragma warning disable CS8604 // 可能有 Null 參考引數。

namespace TicketTracking.Controllers
{
    public class EditController : Controller
    {
        public IActionResult EditView(Bug_Edit bug_Edit)
        {
            return View("Views/EditView.cshtml", bug_Edit);
        }

        public IActionResult EditBug(Bug_Edit bug_Edit)
        {
            string userid = HttpContext.Session.GetString("id");
            DataBase.BugEdit(bug_Edit.id, bug_Edit.name, bug_Edit.statement, userid);
            return new RedirectResult(url: "/Manager/ManagerView", permanent: true, preserveMethod: true);
        }
    }
}
