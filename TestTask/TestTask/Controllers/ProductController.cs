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
	public class ProductController : Controller
	{
		private TestTaskContext db = new TestTaskContext();

		private IProductRepository _productRepository;

		public ProductController()
		{
			_productRepository = new ProductRepository(new TestTaskContext());
		}

		public ProductController(IProductRepository storeRepository)
		{
			_productRepository = storeRepository;
		}


		// GET: Product
		public ActionResult Index()
		{
			return View(db.Products.ToList());
		}

		// GET: Product/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Product product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}

			//Наполнение данными через конструктор (так как по заданию не было написано, делать ли заполнение данными из интерфейса)
			//var redApple = new Product
			//{
			//    Name = "Apple",
			//    Description = "Red apple"
			//};

			return View(product);
		}

		// GET: Product/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Product/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,Description,Store")]
			Product product)
		{
			if (ModelState.IsValid)
			{
				db.Products.Add(product);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(product);
		}

		// GET: Product/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Product product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}

			return View(product);
		}

		// POST: Product/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name,Description")]
			Product product)
		{
			if (ModelState.IsValid)
			{
				db.Entry(product).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(product);
		}

		// GET: Product/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			Product product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}

			return View(product);
		}

		// POST: Product/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Product product = db.Products.Find(id);
			db.Products.Remove(product);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}

			base.Dispose(disposing);
		}

		public ActionResult StoreProducts(int id)
		{
			var products = from product in db.Products
				where product.Stores.Any(x => x.Id == id)
				select product;


			//Наполнение данными через конструктор (так как по заданию не было написано, делать ли заполнение данными из интерфейса)
			//var redApple = new Product
			//         {
			//             Name = "Apple",
			//             Description = "Red apple"
			//         };

			//         var greenApple = new Product
			//         {
			//             Name = "Apple",
			//             Description = "Green apple"
			//         };

			//         var products = new List<Product>
			//         {
			//             redApple,
			//             greenApple
			//         }.AsQueryable();

			var mod = new Mod
			{
				StoreId = id,
				Products = products
			};

			return View(mod);
		}
	}
}
