using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POCOi.Domain.OrdersContext.Repositories;

namespace POCOi.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _repository;

        public OrdersController(IOrdersRepository repository)
        {
            _repository = repository;
        }

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CarregaOrdens()
        {
            return View("_ListOrders", _repository.Get());
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(string status)
        {
            return View(_repository.GetOrdersByStatus(status));
        }

        public JsonResult PopulateOrdersIdsDDL(string status)
        {
            var orders =  _repository.GetOrdersByStatus(status);
            List<SelectListItem> orderIdList = new List<SelectListItem>();

            for (int i = 0; i < orders.Count; i++)
            {
                orderIdList.Add(new SelectListItem { Text = '"' +  Convert.ToString(orders[i].Order_Id) + '"', Value = '"' + Convert.ToString(i) + '"' });

            }

            return Json(new SelectList(orderIdList, "Value", "Text"));

        }



        //Get:

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var _order = _repository.GetOrder(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}