using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestTask.DAL;
using TestTask.Models;
using TestTask.Repository;
using TestTask.Repository.Interfaces;

namespace TestTask.Controllers
{
	public class StoreController : Controller
	{
		private TestTaskContext db = new TestTaskContext();
		private IStoreRepository _storeRepository;

		public StoreController()
		{
			_storeRepository = new StoreRepository(new TestTaskContext());
		}

		public StoreController(IStoreRepository storeRepository)
		{
			_storeRepository = storeRepository;
		}

		// GET: Store
		public ActionResult Index()
		{
			return View(db.Stores.ToList());
		}

		// GET: Store/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Store store = _storeRepository.GetStoreByID(id);
			if (store == null)
			{
				return HttpNotFound();
			}

			return View(store);
		}

		// GET: Store/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Store/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,Address")] Store store)
		{
			if (ModelState.IsValid)
			{
				_storeRepository.InsertStore(store);
				return RedirectToAction("Index");
			}

			return View(store);
		}

		// GET: Store/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Store store = _storeRepository.GetStoreByID(id);
			if (store == null)
			{
				return HttpNotFound();
			}
			
			ViewBag.Products = db.Products.ToList();
			return View(store);
		}

		// POST: Store/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Address")] Store store, int[] selectedProducts)
		{
			if (ModelState.IsValid)
			{
				var storeFind = db.Stores.Find(store.Id);
				if (storeFind != null)
				{
					storeFind.Products.Clear();
					if (selectedProducts != null)
					{
						foreach (var prod in db.Products.Where(p => selectedProducts.Contains(p.Id)))
						{
							storeFind.Products.Add(prod);
						}
					}

					db.SaveChanges();
					db.Entry(storeFind).State = EntityState.Modified;
				}

				_storeRepository.UpdateStore(store);

				return RedirectToAction("Index");
			}

			return View(store);
		}

		// GET: Store/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Store store = _storeRepository.GetStoreByID(id);
			if (store == null)
			{
				return HttpNotFound();
			}

			return View(store);
		}

		// POST: Store/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			_storeRepository.DeleteStore(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_storeRepository.Dispose();
			}

			base.Dispose(disposing);
		}
	}
}
