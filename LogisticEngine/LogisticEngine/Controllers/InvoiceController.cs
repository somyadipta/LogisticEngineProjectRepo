using LogisticEngine.Model.DB;
using LogisticEngine.Model.UI;
using LogisticEngine.Repository;
using LogisticEngine.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticEngine.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _repo=new InvoiceRepository();
        private readonly IUserRepository userRepo = new UserRepository();
        // GET: Invoice
        public ActionResult Index(int invoice=0)
        {
            if (invoice > 0)
            {
                InvoiceAddEditModel model = _repo.GetInvoice(invoice);
                return View(model);
            }
            return RedirectToAction("Search");
        }
        public ActionResult AddEdit(int invoiceid=0)
        {
            userRepo.AddDefaultUser();
            InvoiceAddEditModel invoice = new InvoiceAddEditModel();
            invoice.InvoiceTo = new ClientBranchAddEditModel();
            //invoice.InvoiceTo.CompanyName = "Google";
            invoice.InvoiceItems = new List<InvoiceItemAddEditModel>();
            invoice.CGSTRate = 2.5;
            invoice.SGSTRate = 2.5;
            //if (invoiceid > 0)
            //    invoice = _repo.GetInvoice(invoiceid);

            return View(invoice);
        }
        [HttpPost]
        public ActionResult AddEdit(InvoiceAddEditModel invoice)
        {
            if (TryValidateModel(invoice))
            {
                invoice.UserId = userRepo.GetDefaultUser("").LogisticUserId;
                _repo.AddEditInvoice(invoice);
                
            }
            return Json(1);
        }

        public ActionResult Search()
        {
            return View();
        }
        public ActionResult GetInvoices()
        {
            var invoices=_repo.GetAllInvoices(userRepo.GetDefaultUser("").LogisticUserId, DateTime.Now,null);

            return Json(invoices, JsonRequestBehavior.AllowGet);
        }
    }
}