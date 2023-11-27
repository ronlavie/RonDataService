using Model;
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
            show.Id = int.Parse(reader["id"].ToString());
            show.ShowName = reader["Name"].ToString();
            show.ShowDescription = (reader["Description"].ToString());
            show.ShowType = int.Parse(reader["Type"].ToString());

            return show;

        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Show Show = entity as Show;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ShowId", Show.Id);
            command.Parameters.AddWithValue("@Desctripion", Show.ShowDescription);
            command.Parameters.AddWithValue("@ShowName", Show.ShowName);
            command.Parameters.AddWithValue("@Type", Show.ShowType);

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
            command.CommandText = "INSERT INTO TblShows (ShowName) VALUES (@ShowName)";
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
            command.CommandText = "UPDATE TblShows SET ShowType = @Type, showname = @ShowName, showID = @ShowId,  ShowDescription = @Description";
            LoadParameters(shid);
            return ExecuteCRUD();
        }
    }
}
