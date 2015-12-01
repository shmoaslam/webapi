using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.interfaces
{
    /// <summary>
    /// User Service Contract
    /// </summary>
    public interface IUserServices
    {
        UserEntity GetUserById(int UserId);
        IEnumerable<UserEntity> GetAllUsers();
        long CreateUser(UserEntity UserEntity);
        bool UpdateUser(int UserId, UserEntity UserEntity);
        bool DeleteUser(int UserId);
    }
}
