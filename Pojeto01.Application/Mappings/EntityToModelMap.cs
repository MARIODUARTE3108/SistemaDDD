using AutoMapper;
using Pojeto01.Application.Models;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Cache.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojeto01.Application.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Contato, ContatoDto>();
            CreateMap<Contato, ContatosModel>();
        }
    }
}
