using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Clientes : Entity, IAggregateRoot
    {
        public Clientes(Guid id, string nome, string cpfCnpj, string tipoPessoa, string inscricaoEstadual, DateTime dataNascimento, string telefone, string email,
            string logradouro, int numero, string cep, string bairro, string cidade, string estado)
        {
            Id = id;
            Nome = nome;
            CpfCnpj = cpfCnpj;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            Logradouro = logradouro;
            TipoPessoa = tipoPessoa;
            InscricaoEstadual = inscricaoEstadual;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;

        }
        public Clientes()
        {

        }

        public string Nome { get; set; }

        [Required]
        public Guid Id { get; set; }
        public string CpfCnpj { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string TipoPessoa { get; set; }
        public string InscricaoEstadual { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }
}