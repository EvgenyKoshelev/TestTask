using System.Collections.Generic;

namespace TestTask.Models
{
	/// <summary>
	/// Class for Product
	/// </summary>
    public class Product
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
		/// Description
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Collection Stores
		/// </summary>
		public virtual ICollection<Store> Stores { get; set; }

		///// <summary>
		///// 
		///// </summary>
	 //   public Product()
	 //   {
		//    Stores = new List<Store>();
	 //   }
	}
}