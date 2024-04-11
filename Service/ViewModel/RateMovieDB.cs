using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RateMovieDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            RateMovie movie = entity as RateMovie;
            movie.Id = int.Parse(reader["id"].ToString());
            movie.Stars = int.Parse(reader["Stars"].ToString());
            MovieDB movieDB = new MovieDB();
            movie.Movie = movieDB.SelectById(int.Parse(reader["Movie"].ToString()));
            UserDB userDB = new UserDB();
            movie.User = userDB.SelectById(int.Parse(reader["User"].ToString()));

            return movie;

        }
        protected override void LoadParameters(BaseEntity entity)
        {
            RateMovie movie = entity as RateMovie;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Movie", movie.Movie.Id);
            command.Parameters.AddWithValue("@User", movie.User.Id);
            command.Parameters.AddWithValue("@Stars", movie.Stars);
            command.Parameters.AddWithValue("@TimeStamp", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            command.Parameters.AddWithValue("@ID", movie.Id);

        }
        protected override BaseEntity NewEntity()
        {
            return new RateMovie();
        }
        public RateMovie SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM TblRatemovie WHERE Id=" + Id;
            RateMovieList list = new RateMovieList(ExecuteCommand());

            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }
        public RateMovieList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblRatemovie";
            RateMovieList list = new RateMovieList(ExecuteCommand());
            return list;
        }
        public RateMovieList SelectByMovie(Movie movie)
        {
            command.CommandText = $"SELECT * FROM TblRatemovie WHERE movie={movie.Id}";
            RateMovieList list = new RateMovieList(ExecuteCommand());
            return list;
        }
        public RateMovieList SelectByUser(User user)
        {
            command.CommandText = $"SELECT * FROM TblRatemovie WHERE [User]={user.Id}";
            RateMovieList list = new RateMovieList(ExecuteCommand());
            return list;
        }
        public int Insert(RateMovie rateMovie)
        {
            command.CommandText = "INSERT INTO TblRatemovie (Movie, [User], Stars,[TimeStamp]) VALUES (@movie,@User, @Stars, @TimeStamp)";
            LoadParameters(rateMovie);
            return ExecuteCRUD();
        }

        public int Delete(RateMovie rateMovie)
        {
            command.CommandText = $"DELETE FROM TblRatemovie WHERE ID ={rateMovie.Id}";
            return ExecuteCRUD();
        }
        public int Update(RateMovie rateMovie)
        {
            command.CommandText = "UPDATE TblRatemovie SET movie = @movie,[User] = @User, Stars = @Stars, [TimeStamp]=@TimeStamp WHERE Id = @Id ";
            LoadParameters(rateMovie);
            return ExecuteCRUD();
        }

        public RateMovie IsExist(RateMovie rateMovie)
        {
            command.CommandText = $"SELECT * FROM TblRatemovie WHERE [User]={rateMovie.User.Id} AND movie={rateMovie.Movie.Id}";
            RateMovieList list = new RateMovieList(ExecuteCommand());
            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }
    }
}
