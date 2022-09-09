using FluentValidation;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Validators
{/// <summary>
/// Classe de validação para a entidade Contato
/// </summary>
    public class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Id do contato é obrigatório.");
           
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome do contato é obrigatório.")
                .Length(6, 150).WithMessage("O nome do contato deve ter de 6 a 150 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email do cantato é obrigatório.")
                .EmailAddress().WithMessage("Endereço de email inválido.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Telefone do cantato é obrigatório.");


        }
    }
}
