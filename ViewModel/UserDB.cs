using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB:BaseDB 
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
           User user = entity as User;
            user.Id = int.Parse(reader["id"].ToString());
            user.Firstname = reader["FirstName"].ToString();
            user.Lastname = reader["LastName"].ToString();
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["Password"].ToString();
            user.PermissionLevel = bool.Parse(reader["isadmin"].ToString());
            return user;             
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@FirstName", user.Firstname);
            command.Parameters.AddWithValue("@LastName", user.Lastname) ;
            command.Parameters.AddWithValue("@UserName", user.UserName) ;
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@isAdmin", user.PermissionLevel);
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
        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO TblUser (UserName) VALUES (@UserName)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int UpdateFirstName(User Firstname)
        {
            command.CommandText = "UPDATE TblUser SET FirstName = @FirstName WHERE ID = @FirstName";
            LoadParameters(Firstname);
            return ExecuteCRUD();
        }
        public int UpdateLastName(User LastName)
        {
            command.CommandText = "UPDATE TblUser SET LastName = @LastName WHERE ID = @LastName";
            LoadParameters(LastName);
            return ExecuteCRUD();
        }
        public int UpdatePassword(User Password)
        {
            command.CommandText = "UPDATE TblUser SET Password = @Password WHERE ID = @Password";
            LoadParameters(Password);
            return ExecuteCRUD();
        }
        public int UpdateAdmin(User IsAdmin)
        {
            command.CommandText = "UPDATE TblUser SET IsAdmin = @IsAdmin WHERE ID = @IsAdmin";
            LoadParameters(IsAdmin);
            return ExecuteCRUD();
        }
        public int Delete(User PersonID)
        {
            command.CommandText = "DELETE FROM TblUser WHERE ID =@ID";
            LoadParameters(PersonID);
            return ExecuteCRUD();
        }
   
        }

}
