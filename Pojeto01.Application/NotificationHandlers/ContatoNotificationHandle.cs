using AutoMapper;
using MediatR;
using Pojeto01.Application.Notifications;
using Projeto01.Infra.Cache.MongoDb.Interfaces;
using Projeto01.Infra.Cache.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.NotificationHandlers
{/// <summary>
/// classe para capturar notificações da entidade contato(CREATED, UPDETED e DELETED)
/// </summary>
    public class ContatoNotificationHandle : INotificationHandler<ContatoNotification>
    {
        private readonly IContatoPersistence _contatoPersistence;
        private readonly IMapper _mapper;

        public ContatoNotificationHandle(IContatoPersistence contatoPersistence, IMapper mapper)
        {
            _contatoPersistence = contatoPersistence;
            _mapper = mapper;
        }

        public Task Handle(ContatoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var model = _mapper.Map<ContatosModel>(notification.Contato);
                switch (notification.Action)
                {
                    case ActionNotification.Created:
                        _contatoPersistence.Create(model);
                        break;
                    case ActionNotification.Updated:
                        _contatoPersistence.Update(model);
                        break;
                    case ActionNotification.Deleted:
                        _contatoPersistence.Delete(model);
                        break;
                }
            });
        }
    }
}
