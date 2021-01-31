using AutoMapper;
using InvoiceManagement.Application.Entities.Invoice.Commands;
using InvoiceManagement.Application.Entities.Invoice.ViewModels;
using InvoiceManagement.Application.Entities.InvoiceItem.ViewModels;
using InvoiceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Application.MappingProfiles
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceVm>().ReverseMap();
            CreateMap<InvoiceItem, InvoiceItemVM>().ReverseMap();

            CreateMap<CreateInvoiceCommand, Invoice>();


        }
    }
}
