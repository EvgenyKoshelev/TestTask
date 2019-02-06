using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestTask.DAL;
using TestTask.Models;
using TestTask.Repository.Interfaces;

namespace TestTask.Repository
{
    public class ProductRepository : IProductRepository
    {
        private TestTaskContext context;

        public ProductRepository(TestTaskContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Product> GetProduct()
        {
            return context.Products.ToList();
        }

        public Product GetProductByID(int? productId)
        {
            return context.Products.Find(productId);
        }

        public void InsertProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            Product product = context.Products.Find(productId);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}