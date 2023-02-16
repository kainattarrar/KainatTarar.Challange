using KainatTarar.Challange.Data.Contexts;
using KainatTarar.Challange.Data.Repositories;
using KainatTarar.Challange.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KainatTarar.Challange.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly DataContext _dataContext;
        public UnitOfWork()
        {
            _dataContext = new();
        }
        #region PrivateObjects
        private IGenericRepository<User> _user { get; set; }
        #endregion

        public IGenericRepository<User> Users => _user ?? new GenericRepository<User>(_dataContext);

        public void BeginTransaction()
        {
            if (_transaction == null)
                _transaction = _dataContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }
    }
}
