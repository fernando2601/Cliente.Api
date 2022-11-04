using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class RemoveClienteCommand : ClienteCommand
    {
        public RemoveClienteCommand(Guid id)
        {
            Id = id;
        }


        public override bool IsValid()
        {
            ValidationResult = new RemoveClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}