using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ViewModel;

namespace WCF_RON
{

    public class Service : IService
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
        public int insertUser(User user)
        {
            UserDB userdb = new UserDB();
            return userdb.Insert(user); 

        }
        public int insertMovie (Movie movie)
        {
            MovieDB movieDB = new MovieDB();
            return movieDB.Insert(movie);

        }
        public int InsertShow(Show show)
        {
            ShowDB ShowDB = new ShowDB();
            return ShowDB.Insert(show);

        }
        public int DeleteShow(Show show)
        {
            ShowDB ShowDB = new ShowDB();
            return ShowDB.Delete(show);
        }
        public int DeletMovkie(Movie movie)
        {
            MovieDB movieDb = new MovieDB();
            return movieDb.Delete(movie);
        }
        public int DeleteUser(User user)
        {
            UserDB userdb = new UserDB();
            return userdb.Delete(user);
        }
        public int update(Movie movie)
        {
            MovieDB movieDB = new MovieDB();
            return movieDB.Update(movie);
        }
        public int update(Show shows)
        {
            ShowDB ShowDB = new ShowDB();
            return ShowDB.Update(shows);
        }
        public int update(User user)
        {
            UserDB userdb = new UserDB();
            return (userdb.UpdateLastName(user) + userdb.UpdateAdmin(user)+ userdb.UpdateFirstName(user)+ userdb.UpdatePassword(user));
        }

        public User login(User user)
        {
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }

        public int insert(Movie movie)
        {
            throw new NotImplementedException();
        }

        public int delete(Movie movie)
        {
            throw new NotImplementedException();
        }

        public int insert(User user)
        {
            throw new NotImplementedException();
        }

        public int delete(User user)
        {
            throw new NotImplementedException();
        }

        public int insertShow(Show show)
        {
            throw new NotImplementedException();
        }

        public int delete(Show show)
        {
            throw new NotImplementedException();
        }
    }
    

    
}
