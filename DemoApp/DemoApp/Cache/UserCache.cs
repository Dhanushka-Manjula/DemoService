using DemoApp.Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Cache
{
    public class UserCache
    {
        private static UserCache userCache = null;
        List<User> userList = new List<User>
        {
            new User{ UserName="admin" , Password = "admin" , Email = "abc@gmail.com"},
        };

        private UserCache()
        {

        }

        public static UserCache getInstance()
        {
            if (userCache == null)
            {
                userCache = new UserCache();
            }
            return userCache;

        }

        public List<User> getAllUsers()
        {
            return userList;
        }

        public void addUser(User user)
        {
            userList.Add(user);
        }
        public User getByUserName(string name)
        {
            return userList.FirstOrDefault(x => x.UserName == name);
        }

    }
}
