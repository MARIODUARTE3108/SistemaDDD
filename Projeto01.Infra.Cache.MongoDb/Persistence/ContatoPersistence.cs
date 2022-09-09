using MongoDB.Driver;
using Projeto01.Infra.Cache.MongoDb.Cotexts;
using Projeto01.Infra.Cache.MongoDb.Interfaces;
using Projeto01.Infra.Cache.MongoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Cache.MongoDb.Persistence
{
    public class ContatoPersistence : IContatoPersistence
    {
        private readonly MongoDBContext _mongoDBContext;

        public ContatoPersistence(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public void Create(ContatosModel model)
        {
            _mongoDBContext.Contatos.InsertOne(model);
        }

        public void Delete(ContatosModel model)
        {
            var filter = Builders<ContatosModel>.Filter.Eq(x => x.Id, model.Id);
            _mongoDBContext.Contatos.DeleteOne(filter);
        }

        public List<ContatosModel> GetAll(int page, int limit)
        {
            var filter = Builders<ContatosModel>.Filter.Where(x=>true);
            return _mongoDBContext.Contatos.Find(filter).Skip(page).Limit(limit).ToList();
        }

        public ContatosModel GetById(Guid idContato)
        {
            var filter = Builders<ContatosModel>.Filter.Eq(x => x.Id, idContato);
            return _mongoDBContext.Contatos.Find(filter).FirstOrDefault();
        }

        public void Update(ContatosModel model)
        {
            var filter = Builders<ContatosModel>.Filter.Eq(x=>x.Id, model.Id);  
            _mongoDBContext.Contatos.ReplaceOne(filter, model);
        }
    }
}
