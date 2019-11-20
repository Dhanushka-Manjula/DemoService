using DemoApp.Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Cache
{
    public class EmplyeeCache
    {
        private static EmplyeeCache emplyeeCache = null;
        List<Employee> userList = new List<Employee>
        {
            new Employee{ UserName="Jhone" , IsActive = true , Id = "1" , Notes = "Dummy User1"},
            new Employee{ UserName="Dennis" , IsActive = true , Id = "2" , Notes = "Dummy User2"},
            new Employee{ UserName="Leam" , IsActive = false , Id = "3" , Notes = "Dummy User3"},
            new Employee{ UserName="Meary" , IsActive = true , Id = "4" , Notes = "Dummy User4"},
            new Employee{ UserName="Cristian" , IsActive = true , Id = "5" , Notes = "Dummy User5"},
        };

        private EmplyeeCache()
        {

        }

        public static EmplyeeCache getInstance()
        {
            if (emplyeeCache == null)
            {
                emplyeeCache = new EmplyeeCache();
            }
            return emplyeeCache;

        }

        public List<Employee> getAllUsers()
        {
            return userList;
        }

        public void addUser(Employee employee)
        {
            userList.Add(employee);
        }

        public Employee getByUserId(string id)
        {
            return userList.FirstOrDefault(x => x.Id == id);
        }

    }
}
