using System.Linq;

namespace TestTask.Models
{
	/// <summary>
	/// Class for StoredProduct
	/// </summary>
    public class Mod
    {
		/// <summary>
		/// Products
		/// </summary>
        public IQueryable<Product> Products { get; set; }

		/// <summary>
		/// StoreId
		/// </summary>
        public int StoreId { get; set; }
    }
}