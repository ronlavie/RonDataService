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
            command.CommandText = $"SELECT * FROM TblRatemovie WHERE user={user.Id}";
            RateMovieList list = new RateMovieList(ExecuteCommand());
            return list;
        }
        public int Insert(RateMovie movie)
        {
            command.CommandText = "INSERT INTO TblRatemovie (movie, User, Stars) VALUES (@movie,@User, @Stars)";
            LoadParameters(movie);
            return ExecuteCRUD();
        }
        public int Delete(RateMovie shID)
        {
            command.CommandText = "DELETE FROM TblRatemovie WHERE ID =@ID";
            LoadParameters(shID);
            return ExecuteCRUD();
        }
        public int Update(RateMovie shid)
        {
            command.CommandText = "UPDATE TblRatemovie SET movie = @movie,User = @User, Stars = @Stars WHERE Id = @Id, ";
            LoadParameters(shid);
            return ExecuteCRUD();
        }

        public bool IsExist(RateMovie rateMovie)
        {
            command.CommandText = $"SELECT * FROM TblRatemovie WHERE user={rateMovie.User.Id} AND movie={rateMovie.Movie.Id}";
            RateMovieList list = new RateMovieList(ExecuteCommand());
            return list.Count==1;
        }
    }
}
