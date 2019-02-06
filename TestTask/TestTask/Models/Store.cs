using System.Collections.Generic;

namespace TestTask.Models
{
	/// <summary>
	/// Class for Store
	/// </summary>
    public class Store
    {
		/// <summary>
		/// Id
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name
		/// </summary>
        public string Name { get; set; }

		/// <summary>
		/// Adress
		/// </summary>
        public string Address { get; set; }

		/// <summary>
		/// Collection Products
		/// </summary>
        public virtual ICollection<Product> Products { get; set; }

		///// <summary>
		///// 
		///// </summary>
	 //   public Store()
	 //   {
		//    Products = new List<Product>();
	 //   }
	}
}