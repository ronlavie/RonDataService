﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
           
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["Password"].ToString();
            user.PermissionLevel = bool.Parse(reader["PermissionLevel"].ToString());
            user.Id = int.Parse(reader["Id"].ToString());
            return user;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@PermissionLevel", user.PermissionLevel);
            command.Parameters.AddWithValue("@ID", user.Id);
        }
        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        public User SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM TblUsers WHERE Id=" + Id;
            UserList userList = new UserList(ExecuteCommand());

            if (userList.Count == 0)
            {
                return null;
            }

            return userList[0];
        }
        public User Login(User user)
        {
            command.CommandText = $"SELECT * FROM TblUsers WHERE UserName='{user.UserName}' AND [Password]='{user.Password}'";
            UserList userList = new UserList(ExecuteCommand());

            if (userList.Count == 0)
            {
                return null;
            }
            return userList[0];
        }
        public User CheckUserName(string UserName)
        {
            command.CommandText = $"SELECT * FROM TblUsers WHERE UserName='{UserName}'";
            UserList userList = new UserList(ExecuteCommand());

            if (userList.Count == 0)
            {
                return null;
            }

            return userList[0];
        }
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblUsers";
            UserList userList = new UserList(ExecuteCommand());
            return userList;
        }
        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO TblUsers (FirstName,LastName,UserName,[Password],PermissionLevel) VALUES (@FirstName,@LastName,@UserName,@Password,@PermissionLevel)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Update(User user)
        {
            command.CommandText = "UPDATE TblUsers SET FirstName = @FirstName, LastName = @LastName,  PermissionLevel = @PermissionLevel, [Password] = @Password " +
                "WHERE ID = @ID";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int Delete(User PersonID)
        {
            command.CommandText = "DELETE FROM TblUsers WHERE ID =@ID";
            LoadParameters(PersonID);
            return ExecuteCRUD();
        }
    }
}
