using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class RateMovie:BaseEntity
    {
        protected Movie movie;
        protected User user;
        protected int stars;

        [DataMember] public Movie Movie { get { return movie; } set { movie = value; } }
        [DataMember] public User User { get { return user; } set { user = value; } }
        [DataMember] public int Stars { get { return stars; } set { stars = value; } }
    }
    [CollectionDataContract]
    public class RateMovieList : List<RateMovie>
    {
        public RateMovieList() { } // default c'tor with empty list

        public RateMovieList(IEnumerable<RateMovie> list) : base(list) { } // parse generic list to  list

        public RateMovieList(IEnumerable<BaseEntity> list) : base(list.Cast<RateMovie>().ToList()) { } // from base class to user list
    }
}
