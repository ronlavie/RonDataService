using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RateShow : BaseEntity
    {
        protected Show show;
        protected User user;
        protected int stars;

        [DataMember] public Show Show { get { return show; } set { show = value; } }
        [DataMember] public User User { get { return user; } set { user = value; } }
        [DataMember] public int Stars { get { return stars; } set { stars = value; } }
    }
    [CollectionDataContract]
    public class RateShowList : List<RateShow>
    {
        public RateShowList() { } // default c'tor with empty list

        public RateShowList(IEnumerable<RateShow> list) : base(list) { } // parse generic list to  list

        public RateShowList(IEnumerable<BaseEntity> list) : base(list.Cast<RateShow>().ToList()) { } // from base class to user list
    }
}
