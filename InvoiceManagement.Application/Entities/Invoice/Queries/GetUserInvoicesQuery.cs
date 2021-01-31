using InvoiceManagement.Application.Entities.Invoice.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Application.Entities.Invoice.Queries
{
    public class GetUserInvoicesQuery: IRequest<IList<InvoiceVm>>
    {
        public Guid User { get; set; }
    }
}
