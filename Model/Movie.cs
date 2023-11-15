using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movie : BaseEntity
    {
        protected string movieName;
        protected int movieId;
        protected string movieType;
        protected int movieLength;
        protected string about;
        public string MovieName
        {
            get { return MovieName; }
            set { MovieName = value; }
        }
        public string MovieId
        {
            get { return MovieId; }
            set { MovieId = value; }
        }
        public string MovieType
        {
            get { return MovieType; }
            set { MovieType = value; }
        }
        public int MovieLength
        {
            get { return MovieLength; }
            set { MovieLength = value; }
        }
        public string About
        {
            get { return About; }
            set {About = value; }
        }
    }
    public class MovieList : List<User>
    {
        public MovieList() { } // default c'tor with empty list

        public MovieList(IEnumerable<User> list) : base(list) { } // parse generic list to user list

        public MovieList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { } // from base class to user list
    }

}
