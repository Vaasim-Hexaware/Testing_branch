using service.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.Data.Interfaces
{
    public interface IUserRepository : IGetAll<User>, ISave<User>, IUpdate<User, string>, IDelete<string>
    {
    }
}
