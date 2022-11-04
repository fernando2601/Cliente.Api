using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteAppService
    {
        IEnumerable<Clientes> GetAll();

        Task<ClienteListaViewModel> GetById(Guid id);

        Task<ValidationResult> AddAsync(ClienteRegisterViewModel customerViewModel);

        Task<ValidationResult> UpdateAsync(UpdateClienteViewModel entity);

        Task<ValidationResult> Remove(Guid id);
    }
}