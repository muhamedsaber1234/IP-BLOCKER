using DataAcsess.Context;
using DataAcsess.models;

namespace InterView.Repository
{
    public class InvoiceDetailsRepository
    {
        public InterViewDBContext Context { get; set; }
        public InvoiceDetailsRepository(InterViewDBContext _Context)
        {
            Context = _Context;
        }

        public IEnumerable<InvoiceDetails> GetAll()
        {
            return Context.Invoices.ToList();
        }
        public InvoiceDetails GetByID(int id)
        {
            return Context.Invoices.Find(id);
        }
        public void Add(InvoiceDetails invoiceDetails)
        { 
          Context.Invoices.Add(invoiceDetails);
        }
        public void Update(InvoiceDetails invoiceDetails) 
        {
            Context.Invoices.Update(invoiceDetails);
        }
        public void Delete(int id) 
        {
            var invoice = Context.Invoices.Find(id);
            Context.Invoices.Remove(invoice);
        }
    }
}
