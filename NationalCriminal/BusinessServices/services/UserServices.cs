using AutoMapper;
using BusinessServices.interfaces;
using DataModel.WorkEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataModel;
using BusinessEntities;

namespace BusinessServices.services
{
    /// <summary>
    /// Offers services for User specific CRUD operations
    /// </summary>
    public class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Fetches User details by id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public UserEntity GetUserById(int UserId)
        {
            var User = _unitOfWork.UserRepository.GetByID(UserId);
            if (User != null)
            {
                Mapper.CreateMap<User, UserEntity>();
                var UserModel = Mapper.Map<User, UserEntity>(User);
                return UserModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the Users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> GetAllUsers()
        {
            var Users = _unitOfWork.UserRepository.GetAll().ToList();
            if (Users.Any())
            {
                Mapper.CreateMap<User, UserEntity>();
                var UsersModel = Mapper.Map<List<User>, List<UserEntity>>(Users);
                return UsersModel;
            }
            return null;
        }

        /// <summary>
        /// Creates a User
        /// </summary>
        /// <param name="UserEntity"></param>
        /// <returns></returns>
        public long CreateUser(UserEntity UserEntity)
        {
            using (var scope = new TransactionScope())
            {
                var User = new User
                {
                    FName = UserEntity.FName,
                    LName = UserEntity.LName,
                    Email = UserEntity.Email,
                    Password = UserEntity.Password
                };
                _unitOfWork.UserRepository.Insert(User);
                _unitOfWork.Save();
                scope.Complete();
                return User.Id;
            }
        }

        /// <summary>
        /// Updates a User
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UserEntity"></param>
        /// <returns></returns>
        public bool UpdateUser(int UserId, UserEntity UserEntity)
        {
            var success = false;
            if (UserEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var User = _unitOfWork.UserRepository.GetByID(UserId);
                    if (User != null)
                    {
                        User.FName = UserEntity.FName;
                        User.LName = UserEntity.LName;
                        User.Email = UserEntity.Email;
                        User.Password = UserEntity.Password;
                        _unitOfWork.UserRepository.Update(User);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular User
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteUser(int UserId)
        {
            var success = false;
            if (UserId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var User = _unitOfWork.UserRepository.GetByID(UserId);
                    if (User != null)
                    {

                        _unitOfWork.UserRepository.Delete(User);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
