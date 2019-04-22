using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Text;

namespace Repository.UnitOfWork
{
    public abstract class BaseUnitOfWork:IUnitOfWork
    {
        protected IDbConnection _connection;

        protected IDbTransaction _transaction;

        protected bool _disposed;        

        public BaseUnitOfWork(IConfiguration configuration)
        {
        }

        ~BaseUnitOfWork()
        {
            _Dispose(false);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                _ResetRepositories();
            }
        }

        protected void _Dispose(bool disposing) {

            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if(_connection!=null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }

                    _disposed = true;
                }

            }
        }

        public void Dispose()
        {
            _Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void _ResetRepositories();

    }
}
