using System;
using System.Collections.Generic;
using System.Data.Entity;
using TestTask.Models;

namespace TestTask.DAL
{
	public class TestTaskInitializer : DropCreateDatabaseIfModelChanges<TestTaskContext>
	{
		protected override void Seed(TestTaskContext context)
		{
			////Наполнение данными через конструктор (так как по заданию не было написано, делать ли заполнение данными из интерфейса)
			//#region Create stores

			//var greenStore = new Store
			//{
			//    Name = "Green",
			//    Address = "Green street 1",
			//    OpeningHours = new List<StoreTimes>
			//    {
			//        new StoreTimes(DayOfWeek.Monday, "09:00", "19:00"),
			//        new StoreTimes(DayOfWeek.Tuesday, "09:00", "19:00"),
			//        new StoreTimes(DayOfWeek.Wednesday, "09:00", "19:00"),
			//        new StoreTimes(DayOfWeek.Thursday, "09:00", "19:00"),
			//        new StoreTimes(DayOfWeek.Friday, "09:00", "19:00"),
			//        new StoreTimes(DayOfWeek.Saturday, "10:00", "17:00")
			//    }
			//};

			//var bigzStore = new Store
			//{
			//    Name = "Bigz",
			//    Address = "Bigz street 1",
			//    OpeningHours = new List<StoreTimes>
			//    {
			//        new StoreTimes(DayOfWeek.Monday, "10:00", "20:00"),
			//        new StoreTimes(DayOfWeek.Tuesday, "10:00", "20:00"),
			//        new StoreTimes(DayOfWeek.Wednesday, "10:00", "20:00"),
			//        new StoreTimes(DayOfWeek.Thursday, "10:00", "20:00"),
			//        new StoreTimes(DayOfWeek.Friday, "10:00", "20:00"),
			//        new StoreTimes(DayOfWeek.Saturday, "10:00", "20:00"),
			//        new StoreTimes(DayOfWeek.Sunday, "10:00", "19:00")
			//    }
			//};

			//var stores = new List<Store> { greenStore, bigzStore};

			//#endregion

			//#region Create products

			//var redApple = new Product
			//{
			//    Name = "Apple",
			//    Description = "Red apple"
			//};

			//var greenApple = new Product
			//{
			//    Name = "Apple",
			//    Description = "Green apple"
			//};

			//var banana = new Product
			//{
			//    Name = "Banana",
			//    Description = "Bananas from Ecuador"
			//};

			//var products = new List<Product> {redApple, greenApple, banana};

			//#endregion

			//#region Create relationships

			//greenStore.Products = new List<Product> { greenApple, banana };
			//bigzStore.Products = new List<Product>{redApple,banana};

			//#endregion

			//#region InitializeDB

			//stores.ForEach(x => context.Stores.Add(x));
			//products.ForEach(x => context.Products.Add(x));

			//try
			//{
			//    context.SaveChanges();
			//}
			//catch (Exception e)
			//{

			//}

			//#endregion
		}
	}
}