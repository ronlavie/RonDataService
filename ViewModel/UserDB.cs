using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class UserDB:BaseDB 
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
           User user = entity as User;
            user.Id = int.Parse(reader["id"].ToString());
            user.Firstname = reader["name"].ToString();
            user.Birthday = DateTime.Parse(reader["date"].ToString());
            return user;

             
        }
        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        public User SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM User_Table WHERE Id=" + Id;
            UserList userList = new UserList(ExecuteCommand());

            if (userList.Count == 0)
            {
                return null;
            }

            return userList[0];
        }
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM User_Table";
            UserList userList = new UserList(ExecuteCommand());
            return userList;
        }
    }


}
