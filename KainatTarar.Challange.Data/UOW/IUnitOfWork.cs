using KainatTarar.Challange.Data.Repositories;
using KainatTarar.Challange.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KainatTarar.Challange.Data.UOW
{
    public interface IUnitOfWork
    {   
        IGenericRepository<User> Users { get; }
        int SaveChanges();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
