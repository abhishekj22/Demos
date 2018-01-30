using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstApp
{
    public class CustomerBinding : MvvmHelper.BindableBase
    {
        ShopEntities model = new ShopEntities();

        public IEnumerable<Customer> Customers => model.Customers;

        private Customer currentCustomer;

        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set
            {
                SetProperty(ref currentCustomer, value);
                this.CurrentCustomerInvoice = currentCustomer.InvoiceEntries;
            }
        }

        private IEnumerable<InvoiceEntry> currentCustomerInvoice;

        public IEnumerable<InvoiceEntry> CurrentCustomerInvoice
        {
            get { return currentCustomerInvoice; }
            set
            {
                SetProperty(ref currentCustomerInvoice, value);
            }
        }

        private bool CanExecuteSave() => model.ChangeTracker.HasChanges();

        private void ExecuteSave() => model.SaveChanges();

        public DelegateCommand Save => new DelegateCommand(ExecuteSave, CanExecuteSave);
    }
}
