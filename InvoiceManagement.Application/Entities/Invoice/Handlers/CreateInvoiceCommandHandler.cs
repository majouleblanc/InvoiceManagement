using InvoiceManagement.Application.Entities.Invoice.Commands;
using InvoiceManagement.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InvoiceManagement.Domain.Entities;
using AutoMapper;

namespace InvoiceManagement.Application.Entities.Invoice.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Invoice>(request);
            //var entity = new Domain.Entities.Invoice
            //{
            //    AmountPaid = request.AmountPaid,
            //    Date = request.Date,
            //    Discount = request.Discount,
            //    DiscountType = request.DiscountType,
            //    DueDate = request.DueDate,
            //    From = request.From,
            //    InvoiceNumber = request.InvoiceNumber,
            //    Logo = request.Logo,
            //    PaymentTerms = request.PaymentTerms,
            //    Tax = request.Tax,
            //    TaxType = request.TaxType,
            //    To = request.To,
            //    InvoiceItems = request.InvoiceItems.Select(i => new Domain.Entities.InvoiceItem 
            //    {
            //        Item = i.Item,
            //        Quantity = i.Quantity,
            //        Rate = i.Rate
            //    }).ToList()

            //};
            _context.Invoices.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
