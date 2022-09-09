﻿using Microsoft.EntityFrameworkCore.Storage;
using Projeto01.Domain.Interfaces;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;
      
        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        private IDbContextTransaction _dbContextTransaction;

        public IContatoRepository ContatoRepository => new ContatoRepository(_sqlServerContext);

        public void BeginTransaction()
        {
           _dbContextTransaction = _sqlServerContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContextTransaction.Commit();
        }

        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }

        public void RollbackTransaction()
        {
            _dbContextTransaction.Rollback();
        }
    }
}
