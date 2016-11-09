namespace Lagersystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Lagersystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Lagersystem.DataAccessLayer.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Lagersystem.DataAccessLayer.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Items.AddOrUpdate(
                i => i.ItemID,
                new StockItem { Name = "Goblet", Price = 299.99m, Shelf = "44a", Description = "Drown your sorrows!" },
                new StockItem { Name = "Giblet", Price = 9.99m, Shelf = "18", Description = "Discount meat." },
                new StockItem { Name = "Piglet", Price = 499.99m, Shelf = "5a", Description = "It's a real pig!" },
                new StockItem { Name = "Giga Pig", Price = 999999.99m, Shelf = "5b", Description = "It's a REAL pig!!" },
                new StockItem { Name = "Potion", Price = 99.99m, Shelf = "22", Description = "Restores 100 HP." },
                new StockItem { Name = "Hi-Potion", Price = 499.99m, Shelf = "5", Description = "Restores 500 HP." },
                new StockItem { Name = "Ioun Stone", Price = 999.99m, Shelf = "35c", Description = "Start your own planetary system!" }
                );
        }
    }
}
