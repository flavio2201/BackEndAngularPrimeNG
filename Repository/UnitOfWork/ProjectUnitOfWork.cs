using Microsoft.Extensions.Configuration;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.UnitOfWork
{
    public class ProjectUnitOfWork : BaseUnitOfWork
    {
        #region attributes
        private UserRepository _userRepository;
        #endregion

        #region Repositories
        public UserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_transaction));
        #endregion

        public ProjectUnitOfWork(IConfiguration configuration) : base(configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString("project"));
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        protected override void _ResetRepositories()
        {
            _userRepository = null;
        }
    }
}
