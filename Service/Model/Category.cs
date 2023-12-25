using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Category : BaseEntity
    {
        protected string categoryName;
        [DataMember] public string CategoryName { get { return categoryName; } set { categoryName = value; } }
    }
    [CollectionDataContract]
    public class CategoryList : List<Category>
    {
        public CategoryList() { } // default c'tor with empty list

        public CategoryList(IEnumerable<Category> list) : base(list) { } // parse generic list to  list

        public CategoryList(IEnumerable<BaseEntity> list) : base(list.Cast<Category>().ToList()) { } // from base class to user list
    }
}
