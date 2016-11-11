using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lagersystem.Repositories;
using Lagersystem.Models;
using Lagersystem.DataAccessLayer;

namespace Lagersystem.Controllers
{
    public class StockController : Controller
    {
        public StoreItemRepository repository;

        public StockController()
        {
            repository = new StoreItemRepository();
        }

        public void UpdateSortParms(string sortBy, bool sortDesc)
        {
            if (ViewBag.NameSortParm == sortBy)
            {
                sortDesc = !sortDesc;
            }
            else
            {
                ViewBag.NameSortParm = sortBy;
            }

            ViewBag.OrderSortParm = !sortDesc;
        }

        public ActionResult Index(string sortBy = "name", bool sortDesc = false)
        {
            UpdateSortParms(sortBy, sortDesc);

            var items = repository.Sort(repository.GetAllItems(), sortBy, sortDesc);

            return View(items);
        }

        [HttpGet]
        public ActionResult Create()
        {
            StockItem item = repository.CreateItem();
            return View(item);
        }

        [HttpPost]
        public ActionResult Create(StockItem item)
        {
            if (ModelState.IsValid)
            {
                repository.AddItem(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Edit(int id = -1)
        {
            StockItem item = repository.GetItemById(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(StockItem item)
        {
            if (ModelState.IsValid)
            {
                repository.EditItem(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Delete(int id = -1)
        {
            StockItem item = repository.GetItemById(id);
            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id = -1)
        {
            if (ModelState.IsValid)
            {
                repository.DeleteItemById(id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Search(string term, string sortBy = "name", bool sortDesc = false)
        {
            try
            {
                if (String.IsNullOrEmpty(term))
                {
                    //return RedirectToAction("Index");
                    Uri req = Request.UrlReferrer;

                    if (req != null)
                    {
                        return Redirect(req.ToString());
                    }
                    else
                    {
                        term = null;
                    }
                }

                UpdateSortParms(sortBy, sortDesc);
                var items = repository.Sort(repository.Search(term), sortBy, sortDesc);
                return View(items);
            }
            catch
            {
                Response.StatusCode = 500;
                return View();
            }
        }

        public ActionResult Details(int id = -1)
        {
            StockItem item = repository.GetItemById(id);
            return View(item);
        }
    }
}