using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class BInvoice
    {
        public List<Invoice> GetInvoiceActives()
        {
            DInvoice data = new DInvoice();
            var invoices = data.Get();
            var result = invoices.Where(x => x.active == true).ToList();
            return result;
        }

        public List<Invoice> GetByDate(DateTime date)
        {
            DInvoice data = new DInvoice();
            var invoices = GetInvoiceActives();
            var result = invoices.Where(x => x.date.Date == date.Date).ToList();
            return result;
        }

        public bool insert(Invoice invoice)
        {
            DInvoice insertar = new DInvoice();
            insertar.insert(invoice);
            return true;
        }

        public bool DeleteRecord(int invoiceID)
        {
            DInvoice delete = new DInvoice();

            return delete.eliminar(invoiceID);

        }
    }
}
