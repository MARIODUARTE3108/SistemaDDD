using Pojeto01.Application.Commands;
using Pojeto01.Application.Models;
using Projeto01.Infra.Cache.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.Interfaces
{
    public interface IContatoAppService : IDisposable
    {
        Task<ContatoDto> Create(ContatoCreateCommand command);
        Task<ContatoDto> Update(ContatoUpdateCommand command);
        Task<ContatoDto> Delete(ContatoDeleteCommand command);

        List<ContatosModel> GetAll(int page, int limit);
        ContatosModel GetById(Guid id);
    }
}
