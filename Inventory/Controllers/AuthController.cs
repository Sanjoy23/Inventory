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
        public ActionResult Login(string txtUserName, string txtPassword)
        {
            BaseMember member = new BaseMember();
            DataTable dt = member.ValidateMemberAsDataTable(txtUserName, txtPassword);
            if (dt.Rows.Count > 0)
            {
                //ViewBag.UserName = txtUserName;
                Session["UserName"] = txtUserName;
                return Redirect(Url.Action("About", "Home"));
            }
            return View();
        }
        public ActionResult Logout()
        {
            if (Session["UserName"] != "")
            {
                Session["UserName"] = "";
            }
            return Redirect(Url.Action("Login", "Auth"));
		}

		public ActionResult Reset()
		{
			return View();
		}

	}
}