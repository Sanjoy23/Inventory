using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
			BaseEquipment baseEquipment = new BaseEquipment();
			List<BaseEquipment> listEquipment = baseEquipment.ListEquipment();
            ViewBag.listEquipment = listEquipment;
			return View();
        }
		public ActionResult AddEquipment()
		{
			return RedirectToAction("Index");
		}

		[HttpPost]
        public ActionResult AddEquipment(string NewEquipName,int NewQuantity, int NewStock )
        {
            BaseEquipment baseEquipment = new BaseEquipment();
            int result = baseEquipment.SaveEquipment(NewEquipName, NewQuantity, NewStock);
            if(result == 1)return RedirectToAction("Index");
            
            return View();
        }
    }
}