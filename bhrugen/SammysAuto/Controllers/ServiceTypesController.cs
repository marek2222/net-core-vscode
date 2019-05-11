using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SammysAuto.Areas.Identity.Data;
using SammysAuto.Models;

namespace SammysAuto.Controllers
{
	public class ServiceTypesController : Controller
	{
		public readonly ApplicationDbContext _db;
		public ServiceTypesController (ApplicationDbContext db)
		{
			_db = db;
		}

		// GET : ServiceTypes
		public IActionResult Index ()
		{
			return View (_db.ServiceTypes.ToList ());
		}

		// GET : ServiceTypes/Create
		public async Task<IActionResult> Create (ServiceType serviceType)
		{
			if (ModelState.IsValid)
			{
				_db.Add (serviceType);
				await _db.SaveChangesAsync ();
				return RedirectToAction (nameof (Index));
			}
			return View (serviceType);

		}

		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				_db.Dispose ();
			}
		}
	}
}