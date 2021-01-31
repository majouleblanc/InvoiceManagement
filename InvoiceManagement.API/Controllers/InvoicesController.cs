using AutoMapper;
using FluentValidation;
using InvoiceManagement.Application.Entities.Invoice.Commands;
using InvoiceManagement.Application.Entities.Invoice.Queries;
using InvoiceManagement.Application.Entities.Invoice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceManagement.API.Controllers
{
    public class InvoicesController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateInvoiceCommand command)
        {
            try
            {
                return await Mediator.Send(command);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Errors.Select(e=> e.ErrorMessage));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<InvoiceVm>>> GetUserInvoices(Guid id)
        {
            string userId = "00000000-0000-0000-0000-000000000000";
                var result = await Mediator.Send(new GetUserInvoicesQuery { User = Guid.Parse(userId)});
            return Ok(result);
        }
    }
}
