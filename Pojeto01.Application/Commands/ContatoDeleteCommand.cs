using MediatR;
using Pojeto01.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.Commands
{
    public class ContatoDeleteCommand : IRequest<ContatoDto>
    {
        public Guid Id { get; set; }
    }
}
