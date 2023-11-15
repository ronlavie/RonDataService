using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MovieDB: BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Movie movie  = entity as Movie;
            movie.Id = int.Parse(reader["id"].ToString());
            movie.MovieName = reader["id"].ToString();
            movie.MovieLength = int.Parse(reader["Length"].ToString());
            movie.About = reader["About"].ToString();

            
            return movie;


        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Movie movie = entity as Movie;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@MovieId",movie.Id );
            command.Parameters.AddWithValue("@About", movie.About);
            command.Parameters.AddWithValue("@MovieLength",movie.MovieLength);
            command.Parameters.AddWithValue("@UserName", movie.MovieType);
         
        }
        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        public User SelectById(int Id)
        {
            command.CommandText = "SELECT * FROM TblMovies WHERE Id=" + Id;
            MovieList movieList = new MovieList(ExecuteCommand());

            if (movieList.Count == 0)
            {
                return null;
            }

            return movieList[0];
        }
        public MovieList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblMovies";
           MovieList movieList = new MovieList(ExecuteCommand());
            return movieList;
        }
        public int Insert(Movie movie)
        {
            command.CommandText = "INSERT INTO TblMovies (MovieName) VALUES (@MovieName)";
            LoadParameters(movie);
            return ExecuteCRUD();
        }
    }
}
