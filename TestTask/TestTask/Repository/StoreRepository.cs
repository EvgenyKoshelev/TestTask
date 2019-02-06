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
    public class StoreRepository : IStoreRepository
    {
        private TestTaskContext context;

        public StoreRepository(TestTaskContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IEnumerable<Store> GetStore()
        {
            return context.Stores.ToList();
        }

        public Store GetStoreByID(int? storeId)
        {
            return context.Stores.Find(storeId);
        }

        public void InsertStore(Store store)
        {
            context.Stores.Add(store);
            context.SaveChanges();
        }

        public void DeleteStore(int storeID)
        {
            Store store = context.Stores.Find(storeID);
            context.Stores.Remove(store);
            context.SaveChanges();
        }

        public void UpdateStore(Store store)
        {
            context.Entry(store).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}