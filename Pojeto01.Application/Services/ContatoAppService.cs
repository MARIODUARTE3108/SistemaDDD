using MediatR;
using Pojeto01.Application.Commands;
using Pojeto01.Application.Interfaces;
using Pojeto01.Application.Models;
using Projeto01.Domain.Interfaces;
using Projeto01.Infra.Cache.MongoDb.Interfaces;
using Projeto01.Infra.Cache.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.Services
{
    public class ContatoAppService : IContatoAppService
    {
        private readonly IMediator _mediator;
        private readonly IContatoPersistence _contatoPersistence;

        public ContatoAppService(IMediator mediator, IContatoPersistence contatoPersistence)
        {
            _mediator = mediator;
            _contatoPersistence = contatoPersistence;
        }

        public async Task<ContatoDto> Create(ContatoCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ContatoDto> Delete(ContatoDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public List<ContatosModel> GetAll(int page, int limit)
        {
            return _contatoPersistence.GetAll(page,limit);
        }

        public ContatosModel GetById(Guid id)
        {
            return _contatoPersistence.GetById(id);
        }

        public async Task<ContatoDto> Update(ContatoUpdateCommand command)
        {
            return await _mediator.Send(command);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
