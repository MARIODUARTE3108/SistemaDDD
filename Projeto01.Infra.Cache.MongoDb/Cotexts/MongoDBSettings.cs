using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Cache.MongoDb.Cotexts
{
    public class MongoDBSettings
    {
        public string? Host { get; set; }
        public string? Name { get; set; }
        public bool IsSSL { get; set; }
    }
}
