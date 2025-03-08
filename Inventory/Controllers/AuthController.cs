using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult Login(string txtUserName, string txtPassword)
        //{
        //    if(txtUserName != null)
        //    {
        //        ViewBag.UserName = txtUserName;
        //    }
        //    return View();
        //}
        public ActionResult Login(string txtUserName, string txtPassword)
        {
            BasicMember member = new BasicMember();
            DataTable dt = member.ValidateMemberAsDataTable(txtUserName, txtPassword);
            if (dt.Rows.Count > 0)
            {
                ViewBag.UserName = txtUserName;
                return Redirect(Url.Action("About", "Home"));
            }
            return View();
        }

    }
}