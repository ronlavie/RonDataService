using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class User : BaseEntity
    {
        protected string FirstName;
        public string Firstname
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        protected string LastName;
        public string Lastname
        {
            get { return LastName; }
            set { LastName = value; }
        }

        protected string Email;
        public string EMAIL
        {
            get { return Email; }
            set { Email = value; }
        }

        protected DateTime Birthdate;
        public DateTime Birthday
        {
            get { return Birthdate; }
            set { Birthdate = value; }
        }

        protected string Gender;
        public string GEnder
        {
            get { return Gender; }
            set { Gender = value; }
        }

        protected string PhoneNumber;
        public string Phonenumber
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }

        protected bool permissionLevel;
        public bool PermissionLevel
        {
            get { return permissionLevel; }
            set { permissionLevel = value; }
        }
        public string password
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }
    }

    public class UserList : List<User>
    {
        public UserList() { } // default c'tor with empty list

        public UserList(IEnumerable<User> list) : base(list) { } // parse generic list to user list

        public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { } // from base class to user list
    }
}