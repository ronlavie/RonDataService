using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RateShowDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            RateShow show = entity as RateShow;
            show.Id = int.Parse(reader["id"].ToString());
            show.Stars = int.Parse(reader["Stars"].ToString());
            ShowDB showDB = new ShowDB();
            show.Show = showDB.SelectById(int.Parse(reader["Show"].ToString()));
            UserDB userDB= new UserDB();
            show.User = userDB.SelectById(int.Parse(reader["User"].ToString()));

            return show;

        }
        protected override void LoadParameters(BaseEntity entity)
        {
            RateShow Show = entity as RateShow;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Show", Show.Show.Id);
            command.Parameters.AddWithValue("@User", Show.User.Id);
            command.Parameters.AddWithValue("@Stars", Show.Stars);
            command.Parameters.AddWithValue("@ID", Show.Id);

        }
        protected override BaseEntity NewEntity()
        {
            return new RateShow();
        }
        public RateShow SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM TblRateShow WHERE Id=" + Id;
            RateShowList list= new RateShowList(ExecuteCommand());

            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }
        public RateShowList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblRateShow";
            RateShowList list = new RateShowList(ExecuteCommand());
            return list;
        }
        public RateShowList SelectByShow(Show show)
        {
            command.CommandText = $"SELECT * FROM TblRateShow WHERE show={show.Id}";
            RateShowList list = new RateShowList(ExecuteCommand());
            return list;
        }
        public RateShowList SelectByUser(User user)
        {
            command.CommandText = $"SELECT * FROM TblRateShow WHERE user={user.Id}";
            RateShowList list = new RateShowList(ExecuteCommand());
            return list;
        }
        public int Insert(RateShow Show)
        {
            command.CommandText = "INSERT INTO TblRateShow (Show, User, Stars) VALUES (@Show,@User, @Stars)";
            LoadParameters(Show);
            return ExecuteCRUD();
        }
        public int Delete(Show shID)
        {
            command.CommandText = "DELETE FROM TblRateShow WHERE ID =@ID";
            LoadParameters(shID);
            return ExecuteCRUD();
        }
        public int Update(RateShow shid)
        {
            command.CommandText = "UPDATE TblRateShow SET Show = @Show,User = @User, Stars = @Stars WHERE Id = @Id, ";
            LoadParameters(shid);
            return ExecuteCRUD();
        }
        public RateShow IsExist(RateShow RateShow)
        {
            command.CommandText = $"SELECT * FROM TblRateShow WHERE [User]={RateShow.User.Id} AND movie={RateShow.Show.Id}";
            RateShowList list = new RateShowList(ExecuteCommand());
            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }
    }
}

