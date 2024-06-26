﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ShowDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Show show = entity as Show;
            
            show.ShowName = reader["ShowName"].ToString();
            show.ShowDescription = (reader["ShowDescription"].ToString());
            CategoryDB categoryDB = new CategoryDB();
            show.ShowCategory = categoryDB.SelectById(int.Parse(reader["ShowCategory"].ToString()));
            show.Id = int.Parse(reader["id"].ToString());
            return show;

        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Show Show = entity as Show;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ShowName", Show.ShowName);
            command.Parameters.AddWithValue("@ShowCategory", Show.ShowCategory.Id);
            command.Parameters.AddWithValue("@ShowDescription", Show.ShowDescription);
            command.Parameters.AddWithValue("@ID", Show.Id);

        }
        protected override BaseEntity NewEntity()
        {
            return new Show();
        }
        public Show SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM TblShows WHERE Id=" + Id;
            ShowList ShowList = new ShowList(ExecuteCommand());

            if (ShowList.Count == 0)
            {
                return null;
            }

            return ShowList[0];
        }
        public ShowList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblShows";
            ShowList ShowList = new ShowList(ExecuteCommand());
            return ShowList;
        }
        public int Insert(Show Show)
        {
            command.CommandText = "INSERT INTO TblShows (ShowName, ShowCategory, ShowDescription) VALUES (@ShowName,@ShowCategory, @ShowDescription)";
            LoadParameters(Show);
            return ExecuteCRUD();
        }
        public int Delete(Show shID)
        {
            command.CommandText = "DELETE FROM TblShows WHERE ID =@ID";
            LoadParameters(shID);
            return ExecuteCRUD();
        }
        public int Update(Show shid)
        {
            command.CommandText = "UPDATE TblShows SET showname = @ShowName,ShowCategory = @ShowCategory, ShowDescription = @ShowDescription WHERE Id = @Id, ";
            LoadParameters(shid);
            return ExecuteCRUD();
        }
    }
}
