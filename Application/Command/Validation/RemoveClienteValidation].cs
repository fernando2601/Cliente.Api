using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Validation
{
    public class RemoveClienteValidation : AbstractValidator<RemoveClienteCommand>
    {
        public RemoveClienteValidation()
        {

            RuleFor(c => c.Id)
                  .NotEqual(Guid.Empty);


        }
    }
}