using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private RentControllBDEntities dbEntity = new RentControllBDEntities();
		public ActionResult Index ( )
		{
			return View();
		}

		public ActionResult About ( )
		{
			IQueryable<OwnerBalance> allOwner = from
				flat in dbEntity.Flats
					group flat by flat.Owner into ownerBalanceGroup
					select new OwnerBalance()
					{
						Owner = ownerBalanceGroup.Key,
						OwnerFlatCount = ownerBalanceGroup.Count(),
						
					};		

			return View(allOwner.ToList());
		}

		protected override void Dispose ( bool disposing )
		{
			dbEntity.Dispose();
			base.Dispose ( disposing );
		}

		public ActionResult Contact ( )
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}