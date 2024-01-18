using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Movie : BaseEntity
    {
        protected string movieName;
        protected int movieLength;
        protected string about;
        protected Category movieCategory;
        [DataMember]
        public string MovieName
        {
            get { return movieName; }
            set { movieName = value; }
        }
        
        [DataMember]
        public Category MovieCategory
        {
            get { return movieCategory; }
            set { movieCategory = value; }
        }
        [DataMember]
        public int MovieLength
        {
            get { return movieLength; }
            set { movieLength = value; }
        }
        [DataMember]
        public string About
        {
            get { return about; }
            set { about = value; }
        }
    }
    [CollectionDataContract]
    public class MovieList : List<Movie>
    {
        public MovieList() { } // default c'tor with empty list

        public MovieList(IEnumerable<Movie> list) : base(list) { } // parse generic list to user list

        public MovieList(IEnumerable<BaseEntity> list) : base(list.Cast<Movie>().ToList()) { } // from base class to user list
    }

}
