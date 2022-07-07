using service.Business.Interfaces;
using service.Data.Interfaces;
using service.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.Business.Services
{
    public class UserService : IUserService
    {
        IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
           this._UserRepository = UserRepository;
        }
        public IEnumerable<User> GetAll()
        {
            return _UserRepository.GetAll();
        }

        public User Save(User User)
        {
            _UserRepository.Save(User);
            return User;
        }

        public User Update(string id, User User)
        {
            return _UserRepository.Update(id, User);
        }

        public bool Delete(string id)
        {
            return _UserRepository.Delete(id);
        }

    }
}
