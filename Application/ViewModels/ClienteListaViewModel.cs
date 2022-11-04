using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ClienteListaViewModel
    {
        public ClienteListaViewModel(Guid id, string nome, string cpfCnpj, DateTime dataNascimento, string telefone, string email, string inscricaoEstadual, string tipoPessoa, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            CpfCnpj = cpfCnpj;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            InscricaoEstadual = inscricaoEstadual;
            TipoPessoa = tipoPessoa;
            Endereco = endereco;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string InscricaoEstadual { get; set; }
        public string TipoPessoa { get; set; }

        public Endereco Endereco { get; set; }
    }
}
