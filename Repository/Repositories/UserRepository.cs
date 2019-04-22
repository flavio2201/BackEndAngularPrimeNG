using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository.Repositories
{
    public class UserRepository:BaseRepository
    {
        public UserRepository(IDbTransaction transaction): base(transaction) {

        }
    }
}
