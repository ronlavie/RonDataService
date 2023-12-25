using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    [DataContract]   

    public class User : BaseEntity
    {
        protected string firstName;
        protected string lastName;
        protected string userName;
        protected string password;
        protected bool permissionLevel;

        [DataMember]
        public string Firstname
        {
            get { return firstName; }
            set { firstName = value; }
        }
        
        [DataMember]
        public string Lastname
        {
            get { return lastName; }
            set { lastName = value; }
        }
        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public bool PermissionLevel
        {
            get { return permissionLevel; }
            set { permissionLevel = value; }
        }
    }
    [CollectionDataContract]
    public class UserList : List<User>
    {
        public UserList() { } // default c'tor with empty list

        public UserList(IEnumerable<User> list) : base(list) { } // parse generic list to user list

        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { } // from base class to user list
    }

}