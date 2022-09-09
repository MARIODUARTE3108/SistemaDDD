using MediatR;
using Pojeto01.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.Commands
{/// <summary>
/// Dados do comando de cadastro de contatos
/// </summary>
    public class ContatoCreateCommand : IRequest<ContatoDto>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
