using AutoMapper;
using FluentValidation;
using MediatR;
using Pojeto01.Application.Commands;
using Pojeto01.Application.Models;
using Pojeto01.Application.Notifications;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.RequestHandlers
{/// <summary>
/// componente do MediatR para processamento dos COMMANDS (CREATE, UPDATE e DELETE)
/// </summary>
    public class ContatoRequestHandler : IDisposable,
        IRequestHandler<ContatoCreateCommand, ContatoDto>,
        IRequestHandler<ContatoUpdateCommand, ContatoDto>,
        IRequestHandler<ContatoDeleteCommand, ContatoDto>
    {
        #region Injeção de dependência

        private readonly IContatoDomainService _contatoDomainService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContatoRequestHandler(IContatoDomainService contatoDomainService, IMediator mediator, IMapper mapper)
        {
            _contatoDomainService = contatoDomainService;
            _mediator = mediator;
            _mapper = mapper;
        }

        #endregion
        public async Task<ContatoDto> Handle(ContatoCreateCommand request, CancellationToken cancellationToken)
        {
            // Capturar os dados do contato
            var contato = _mapper.Map<Contato>(request);

            // Executando a validação da entidade
            if (!contato.Validate.IsValid)
                throw new ValidationException(contato.Validate.Errors);

            await _contatoDomainService.CreateAsync(contato);

            //Gerando uma notificação (NOTIFICATION HANDLER)
            var notification = new ContatoNotification
            {
                Action = ActionNotification.Created,
                Contato = contato
            };

            await _mediator.Publish(notification);

            return _mapper.Map<ContatoDto>(contato);
        }

        public async Task<ContatoDto> Handle(ContatoUpdateCommand request, CancellationToken cancellationToken)
        {
            // Capturar os dados do contato
            var contato = _mapper.Map<Contato>(request);

            // Executando a validação da entidade
            if (!contato.Validate.IsValid)
                throw new ValidationException(contato.Validate.Errors);

            await _contatoDomainService.UpdateAsync(contato);

            var notification = new ContatoNotification
            {
                Action = ActionNotification.Updated,
                Contato = contato
            };

            await _mediator.Publish(notification);

            return _mapper.Map<ContatoDto>(contato);
        }

        public async Task<ContatoDto> Handle(ContatoDeleteCommand request, CancellationToken cancellationToken)
        {
            // Capturar os dados do contato
            var contato = await _contatoDomainService.GetByIdAsync(request.Id);
            await _contatoDomainService.DeleteAsync(contato);

            var notification = new ContatoNotification
            {
                Action = ActionNotification.Deleted,
                Contato = contato
            };

            await _mediator.Publish(notification);

            return _mapper.Map<ContatoDto>(contato);
        }
        public void Dispose()
        {
            _contatoDomainService.Dispose();
        }
    }
}
