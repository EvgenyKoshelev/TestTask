using System;
using System.Collections.Generic;
using TestTask.Models;

namespace TestTask.Repository.Interfaces
{
    public interface IStoreRepository : IDisposable
    {
        IEnumerable<Store> GetStore();
        Store GetStoreByID(int? storeId);
        void InsertStore(Store store);
        void DeleteStore(int storeID);
        void UpdateStore(Store store);
    }
}
