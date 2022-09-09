using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.Notifications
{
    /// <summary>
    /// Enum para definior os tipos de ações do CQRS
    /// </summary>
    public enum ActionNotification
    {
        Created = 1,
        Updated = 2,
        Deleted = 3,
    }
}
