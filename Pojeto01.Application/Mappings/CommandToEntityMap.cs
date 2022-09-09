using AutoMapper;
using Pojeto01.Application.Commands;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.Mappings
{
    public class CommandToEntityMap : Profile
    {
        public CommandToEntityMap()
        {
            CreateMap<ContatoCreateCommand, Contato>()
            .AfterMap((command, entity) =>
            {
                entity.Id = Guid.NewGuid();
                entity.CreateAt = DateTime.Now;
                entity.UpdateAt = DateTime.Now;
            });

            CreateMap<ContatoUpdateCommand, Contato>()
                .AfterMap((command, entity) =>
                {
                    entity.UpdateAt = DateTime.Now;
                });
        }
    }
}
