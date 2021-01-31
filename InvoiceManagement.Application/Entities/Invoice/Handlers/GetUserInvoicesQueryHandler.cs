using AutoMapper;
using InvoiceManagement.Application.Entities.Invoice.Queries;
using InvoiceManagement.Application.Entities.Invoice.ViewModels;
using InvoiceManagement.Application.Entities.InvoiceItem.ViewModels;
using InvoiceManagement.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceManagement.Application.Entities.Invoice.Handlers
{
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, IList<InvoiceVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserInvoicesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<InvoiceVm>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceVm>();
            var userInvoices = await _context.Invoices.Where(i => i.CreatedBy == request.User).Include(i => i.InvoiceItems).ToListAsync();

            if (userInvoices != null)
            {
                result = _mapper.Map<List<InvoiceVm>>(userInvoices);

                //result = userInvoices.Select(i => new InvoiceVm
                //{
                //    AmountPaid = i.AmountPaid,
                //    Created = i.CreatedDate,
                //    Date = i.Date,
                //    Discount = i.Discount,
                //    DiscountType = i.DiscountType,
                //    DueDate = i.DueDate,
                //    From = i.From,
                //    Id = i.Id,
                //    InvoiceNumber = i.InvoiceNumber,
                //    Logo = i.Logo,
                //    PaymentTerms = i.PaymentTerms,
                //    Tax = i.Tax,
                //    TaxType = i.TaxType,
                //    To = i.To,
                //    InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemVM
                //    {
                //        Item = item.Item,
                //        Quantity = item.Quantity,
                //        Rate = item.Rate
                //    }).ToList(),
                //}).ToList();
            }
            return result;
        }
    }
}
