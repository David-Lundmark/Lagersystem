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
            return context.Items.First(i => i.ItemID == id);
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
            IEnumerable<StockItem> result = context.Items.Where(i => i.Name.Contains(term));
            return result;
        }

        public IEnumerable<StockItem> Sort(IEnumerable<StockItem> items, string sortBy = "name", bool sortDesc = false)
        {
            switch (sortBy.ToLowerInvariant())
            {
                case "name":
                    if (sortDesc)
                    {
                        items = items.OrderByDescending(i => i.Name);
                    }
                    else
                    {
                        items = items.OrderBy(i => i.Name);
                    }
                    break;

                case "price":
                    if (sortDesc)
                    {
                        items = items.OrderByDescending(i => i.Price);
                    }
                    else
                    {
                        items = items.OrderBy(i => i.Price);
                    }
                    break;

                case "shelf":
                    if (sortDesc)
                    {
                        items = items.OrderByDescending(i => i.Shelf);
                    }
                    else
                    {
                        items = items.OrderBy(i => i.Shelf);
                    }
                    break;

                case "description":
                    if (sortDesc)
                    {
                        items = items.OrderByDescending(i => i.Description);
                    }
                    else
                    {
                        items = items.OrderBy(i => i.Description);
                    }
                    break;

                default:
                    throw new NotImplementedException();
            }

            return items;
        }
    }
}