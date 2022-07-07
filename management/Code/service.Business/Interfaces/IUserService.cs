using service.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.Business.Interfaces
{
    public interface IUserService
    {      
        IEnumerable<User> GetAll();
        User Save(User classification);
        User Update(string id, User classification);
        bool Delete(string id);

    }
}
