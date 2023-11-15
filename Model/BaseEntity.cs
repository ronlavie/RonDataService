using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseEntity
    {
        protected int id;
        protected string firstname;
        protected string lastname;
        protected string password;
        protected bool isAdmin;
        public int Id
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Firstname
        {
            get { return Firstname; }
            set { Firstname = value; }
        }
        public string Lastname
        {
            get { return Lastname; }
            set { Lastname = value; }
        }
        public string Password
        {
            get { return Password; }
            set { Password = value; }
        }
        public bool IsAdmin
        {
            get { return IsAdmin; }
            set { IsAdmin = value; }
        }
    }
}
