using Microsoft.AspNetCore.Mvc;
using TicketTracking.Models;
using TicketTracking.DB;

namespace TicketTracking.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginView() {

            LoginModel loginModel = new LoginModel();
            return View("Views/LoginView.cshtml", loginModel);
        }

        [HttpPost]
        public IActionResult LoginView(LoginModel loginModel)
        {
            User user = DataBase.Login(loginModel.account, loginModel.password); // 嘗試登入

            //驗證密碼
            if (user.LoginStatus) // Success
            {
                HttpContext.Session.SetString("id", user.Id);
                HttpContext.Session.SetString("account", user.Account);
                HttpContext.Session.SetString("level", user.Level);

                return new RedirectResult(url: "/Manager/ManagerView", permanent: true, preserveMethod: true);
            }
            else // Fail
            {
                ViewBag.Msg = "登入失敗...";
                return View("Views/LoginView.cshtml", loginModel);
            }
        }

    }
}