using ProjectTwo.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTwo.Repository
{
    public interface IUserRepository
    {
        List<User> Users { get; }
    }

    public class GetUserRepository : IUserRepository
    {
        public List<User> Users
        {
            get
            {
                var userList = DatabaseAccessor
                    .Instance
                    .User
                    .Select(u => new User
                    {
                        Id = u.Id,
                        Email = u.Email,
                        Password = u.Password,
                        DateCreated = u.DateCreated,
                    })
                    .ToList();

                return userList;
            }
        }
    }
}