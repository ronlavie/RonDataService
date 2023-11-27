using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Category();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Category category = entity as Category;
            category.Id = int.Parse(reader["id"].ToString());
            category.CategoryName = reader["CategoryName"].ToString();
            return category;
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Category category = entity as Category;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", category.Id);
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);

        }
        public Category SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM TblCategory WHERE Id=" + Id;
            CategoryList list = new CategoryList(ExecuteCommand());
            if (list.Count == 0)
                return null;

            return list[0];
        }
        public CategoryList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblCategory";
            CategoryList list = new CategoryList(ExecuteCommand());
            return list;
        }
        public int Insert(Category category)
        {
            command.CommandText = "INSERT INTO TblCategory (CategoryName) VALUES (@CategoryName)";
            LoadParameters(category);
            return ExecuteCRUD();
        }
        public int Delete(Category category)
        {
            command.CommandText = "DELETE FROM TblCategory WHERE ID =@ID";
            LoadParameters(category);
            return ExecuteCRUD();
        }
        public int Update(Category category)
        {
            command.CommandText = "UPDATE TblCategory SET CategoryName = @CategoryName WHERE Id = @Id";
            LoadParameters(category);
            return ExecuteCRUD();
        }
    }
}