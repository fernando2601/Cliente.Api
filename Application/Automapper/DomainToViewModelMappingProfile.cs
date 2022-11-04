using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Automapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Clientes, ClienteRegisterViewModel>();
            CreateMap<Clientes, ClienteListaViewModel>().ConstructUsing(c => new ClienteListaViewModel(c.Id,
             c.Nome, c.CpfCnpj, c.DataNascimento, c.Telefone, c.Email, c.InscricaoEstadual, c.TipoPessoa, new Endereco()
             {
                 Bairro = c.Bairro,
                 Cep = c.Cep,
                 Cidade = c.Cidade,
                 Estado = c.Estado,
                 Logradouro = c.Logradouro,
                 Numero = c.Numero
             }
          )); ;

        }

    }
}