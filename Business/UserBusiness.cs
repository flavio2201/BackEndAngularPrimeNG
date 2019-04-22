using Business.Exceptions;
using Entity;
using Microsoft.Extensions.Configuration;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class UserBusiness:BusinessBase<ProjectUnitOfWork>
    {

        public UserBusiness(IConfiguration Configuration) : base(Configuration)
        {
        }

        public List<User> GetAll()
        {
            return UnitOfWork.UserRepository.GetAll<User>().OrderBy(x => x.Name).ToList();
        }

        public void Save(User newUser)
        {
            
            if (newUser.Id == decimal.Zero)
            {                
                Insert(newUser);
                return;
            }
            else
            {                
                Update(newUser);
            }
        }

        public string Insert(User entity)
        {
            try
            {                
                                
                UnitOfWork.UserRepository.Insert<User>(entity);
                base.Commit();
                return "OK";
            }            
            catch (Exception e)
            {
                throw new BusinessException($"Error {e.Message}");
            }
        }

        public void Update(User entity)
        {
            try
            {
                var user = UnitOfWork.UserRepository.Get<User>(entity.Id);
                user.Name = entity.Name;
                user.Email= entity.Email;

                UnitOfWork.UserRepository.Update<User>(entity);                
                base.Commit();
            }            
            catch (Exception e)
            {
                throw new BusinessException($"Error {e.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                User entity = UnitOfWork.UserRepository.Get<User>(id);
                UnitOfWork.UserRepository.Delete<User>(entity);
                base.Commit();
            }                        
            catch (Exception e)
            {
                throw new BusinessException($"Error {e.Message}");
            }
        }


    }
}
