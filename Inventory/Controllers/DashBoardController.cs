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
        public ActionResult AddEquipment(string NewEquipName,int NewQuantity, int NewStock, decimal NewUnitPrice, DateTime NewEntryDate, DateTime NewReceiveDate )
        {
            BaseEquipment baseEquipment = new BaseEquipment();
            int result = baseEquipment.SaveEquipment(NewEquipName, NewQuantity, NewStock,NewUnitPrice, NewEntryDate, NewReceiveDate);
            if(result == 1)return RedirectToAction("Index");
            
            return View();
        }

        [HttpPost]
        public ActionResult DeleteEquipment(int Id)
        {
            BaseEquipment baseEquipment = new BaseEquipment();
            bool result = baseEquipment.DeleteEquipment(Id);
			//if(result) return RedirectToAction("Index");
			return RedirectToAction("Index");
        }
    }
}