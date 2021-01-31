using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Domain.Interfaces
{

    public interface IAuditableBaseEntity
    {
        Guid Id { get; set; }
        Guid CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Guid UpdatedBy { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
