using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]   
    public class Show : BaseEntity
    {
        protected string showName;
        protected string showDescription;
        protected Category showCategory;
        [DataMember] public string ShowName { get { return showName; } set { showName = value; } }
        [DataMember] public string ShowDescription {  get { return showDescription; } set {  showDescription = value; } }
        [DataMember] public Category ShowCategory { get {  return showCategory; } set { showCategory = value; } }
    }
    [CollectionDataContract]
    public class ShowList : List<Show>
    {
        public ShowList() { } // default c'tor with empty list

        public ShowList(IEnumerable<Show> list) : base(list) { } // parse generic list to  list

        public ShowList(IEnumerable<BaseEntity> list) : base(list.Cast<Show>().ToList()) { } // from base class to user list
    }

}
