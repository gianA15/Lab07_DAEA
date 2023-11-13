using Demo09.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business;
using Entity;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Reflection;

namespace Demo09.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: InvoiceController
        public ActionResult Index()
        {


            BInvoice bInvoice = new BInvoice();
            List<Invoice> invoicesEntity = bInvoice.GetInvoiceActives();

            List<InvoiceModel> invoices = invoicesEntity.Select(x => new InvoiceModel
            {
                Id = x.invoice_id,
                Total = x.total,
                Igv = x.total / 100 * 18,

            }).ToList();


            return View(invoices);
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceModel model)
        {
            try
            {
                BInvoice bInvoice = new BInvoice();

                Invoice invoice = new Invoice
                {
                    customer_id = model.Customer_id,
                    total = model.Total,
                    date = DateTime.Now,
                    active = true
                };

                bInvoice.insert(invoice);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            BInvoice bInvoice = new BInvoice();
            Invoice invoice = bInvoice.GetInvoiceActives().Where(x => x.invoice_id == id).FirstOrDefault();

            InvoiceModel model = new InvoiceModel
            {
                Customer_id = invoice.customer_id,
                Total = invoice.total,

            };

            //el modelo por id
            return View(model);
        }

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                BInvoice bInvoice = new BInvoice();
                bInvoice.DeleteRecord(id);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
