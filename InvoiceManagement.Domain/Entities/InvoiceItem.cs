using InvoiceManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Domain.Entities
{
    public class InvoiceItem : IAuditableBaseEntity
    {
        public Guid Id { get ; set ; }
        public Guid InvoiceId { get; set; }
        public string Item { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public Invoice Invoice { get; set; }
        public Guid CreatedBy { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public Guid UpdatedBy { get ; set ; }
        public DateTime? UpdateDate { get ; set ; }
    }
}
