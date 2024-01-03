using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ViewModel;

namespace ServiceModel
{

    public class ServiceMovieAndShow : IServiceMovieAndShow
    {
        public ShowList GetAllShows()
        {
            ShowDB db = new ShowDB();
            ShowList list = db.SelectAll();
            return list;
        }
        public MovieList GetAllMovies()
        {
            MovieDB db = new MovieDB();
            MovieList list = db.SelectAll();
            return list;
        }
public UserList GetAllUsers()
{
    UserDB db = new UserDB();
    UserList list = db.SelectAll();
    return list;
}
        public int InsertUser(User user)
        {
            UserDB userdb = new UserDB();
            return userdb.Insert(user); 

        }
        public int InsertMovies(Movie movie)
        {
            MovieDB movieDB = new MovieDB();
            return movieDB.Insert(movie);

        }
        public int InsertShows(Show show)
        {
            ShowDB ShowDB = new ShowDB();
            return ShowDB.Insert(show);

        }
        public int DeleteShows(Show show)
        {
            ShowDB ShowDB = new ShowDB();
            return ShowDB.Delete(show);
        }
        public int DeleteMovies(Movie movie)
        {
            MovieDB movieDb = new MovieDB();
            return movieDb.Delete(movie);
        }
        public int DeleteUser(User user)
        {
            UserDB userdb = new UserDB();
            return userdb.Delete(user);
        }
        public int UpdateMovies(Movie movie)
        {
            MovieDB movieDB = new MovieDB();
            return movieDB.Update(movie);
        }
        public int UpdateShows(Show shows)
        {
            ShowDB ShowDB = new ShowDB();
            return ShowDB.Update(shows);
        }
        public int UpdateUser(User user)
        {
            UserDB userdb = new UserDB();
            return (userdb.Update(user));
        }

        public User Login(User user)
        {
            UserDB db = new UserDB();
            User tmp = db.Login(user);
            if (tmp == null) return null;
            if (!tmp.Password.Equals(user.Password)) return null;
            return tmp;
        }
        public bool CheckUserName(string UserName)
        {
            UserDB db = new UserDB();
            User tmp = db.CheckUserName(UserName);
            if (tmp == null) return true;
            return false;
        }

    }
    

    
}
