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
        public List<Invoice> GetByDate(DateTime date)
        {

            DInvoice data = new DInvoice();
            var invoices = data.Get();
            var result = invoices.Where(x => x.date == date).ToList();
            //lambda          

            return result;
        }
        public List<Invoice> Get()
        {


            DInvoice data = new DInvoice();
            var invoices = data.Get();

            return invoices;
        }
    }
}
