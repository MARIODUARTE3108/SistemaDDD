using MediatR;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.Notifications
{/// <summary>
/// Classe oara armazenar as notificações relacionadas a contato
/// </summary>
    public class ContatoNotification : INotification
    {
        public ActionNotification Action { get; set; }
        public Contato? Contato { get; set; }
    }
}
