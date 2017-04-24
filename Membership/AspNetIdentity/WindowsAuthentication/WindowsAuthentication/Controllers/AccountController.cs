using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WindowsAuthentication.Models;

namespace WindowsAuthentication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AccountLoginModel input)
        {
            Membership.ValidateUser(input.UserName, input.Password);
            
            return View();
        }
    }
}