using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Repository.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProduct();
        Product GetProductByID(int? productId);
        void InsertProduct(Product product);
        void DeleteProduct(int productID);
        void UpdateProduct(Product product);
    }
}
