using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lagersystem.Models;
using Lagersystem.DataAccessLayer;

namespace Lagersystem.Repositories
{
    public class StoreItemRepository
    {
        StoreContext context;

        public StoreItemRepository()
        {
            context = new StoreContext();
        }

        public StockItem CreateItem()
        {
            StockItem item = new StockItem();
            return item;
        }

        public void AddItem(StockItem item)
        {
            context.Items.Add(item);
            context.SaveChanges();
            return;
        }

        public void EditItem(StockItem item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return;
        }

        public IEnumerable<StockItem> GetAllItems()
        {
            return context.Items;
        }

        public StockItem GetItemById(int id)
        {
            return context.Items.FirstOrDefault(i => i.ItemID == id);
        }

        public void DeleteItemById(int id)
        {
            StockItem query = context.Items.First(i => i.ItemID == id);

            if (query != null)
            {
                context.Items.Remove(query);
                context.SaveChanges();
            }

            return;
        }

        public IEnumerable<StockItem> Search(string term)
        {
            IEnumerable<StockItem> result = context.Items.Where(i => i.Name.Contains(term)).Select(i => i);
            return result;
        }
    }
}