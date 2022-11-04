using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Events
{
    public class ClienteRegisterEvent : Event
    {
        public ClienteRegisterEvent(Guid id, string nome, string cpfCnpj, DateTime dataNascimento, string telefone, string email,
        string logradouro, int numero, string cep, string bairro, string cidade, string estado)
        {
            AggregateId = id;
            Nome = nome;
            CpfCnpj = cpfCnpj;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Endereco = new Endereco()
            {
                Bairro = bairro,
                Cep = cep,
                Cidade = cidade,
                Estado = estado,
                Logradouro = logradouro,
                Numero = numero
            };
        }
        public ClienteRegisterEvent()
        {

        }

        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }


    }
}
