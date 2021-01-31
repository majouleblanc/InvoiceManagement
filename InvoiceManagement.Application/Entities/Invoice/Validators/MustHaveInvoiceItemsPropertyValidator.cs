using FluentValidation.Validators;
using InvoiceManagement.Application.Entities.InvoiceItem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Application.Entities.Invoice.Validators
{
    public class MustHaveInvoiceItemsPropertyValidator : PropertyValidator
    {

        protected override string GetDefaultMessageTemplate()
        {
            return "Property {PropertyName} should not be empty list.";
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IList<InvoiceItemVM>;
            return list != null && list.Any();
        }
    }
}
