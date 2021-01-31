using InvoiceManagement.Application.Entities.InvoiceItem.ViewModels;
using InvoiceManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Application.Entities.Invoice.ViewModels
{
    public class InvoiceVm
    {
        public InvoiceVm()
        {
            InvoiceItems = new List<InvoiceItemVM>();
        }
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Tax { get; set; }
        public TaxType TaxType { get; set; }
        public double AmountPaid { get; set; }
        public IList<InvoiceItemVM> InvoiceItems { get; set; }
        public DateTime Created { get; set; }
    }
}
