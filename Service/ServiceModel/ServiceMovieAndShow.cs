using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using ViewModel;

namespace ServiceModel
{

    public class ServiceMovieAndShow : IServiceMovieAndShow
    {
        public string GetMovieinfo(string movieName)
        {
            return ApiData.GetMovieData(movieName);
        }
        public ShowList GetAllShows()
        {
            ShowDB db = new ShowDB();
            ShowList list = db.SelectAll();
            return list;
        }
        public ShowList GetAllShowsFullData()
        {
            ShowDB db = new ShowDB();
            ShowList list = db.SelectAll();
            foreach (Show show in list)
            {
                ApiData.LoadShowsData(show);
            }
            return list;
        }

        public RateShowList GetShowRatingByShow(Show show)
        {
            RateShowDB db = new RateShowDB();
            RateShowList list = db.SelectByShow(show);
            return list;
        }
        public RateShowList GetShowRatingByUser(User user)
        {
            RateShowDB db = new RateShowDB();
            RateShowList list = db.SelectByUser(user);
            return list;
        }
        public MovieList GetAllMovies()
        {
            MovieDB db = new MovieDB();
            MovieList list = db.SelectAll();
            return list;
        }
        public MovieList GetAllMoviesFullData()
        {
            MovieDB db = new MovieDB();
            MovieList list = db.SelectAll();
            foreach (Movie movie in list)
            {
                ApiData.LoadMovieData(movie);
            }
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
        public RateMovieList GetMovieRatingByUser(User user)
        {
            RateMovieDB db = new RateMovieDB();
            RateMovieList list = db.SelectByUser(user);
            return list;
        }
        public RateMovieList GetMovieRatingByMovie(Movie movie)
        {
            RateMovieDB db = new RateMovieDB();
            RateMovieList list = db.SelectByMovie(movie);
            return list;
        }
        public int InsertMovies(Movie movie)
        {
            MovieDB movieDB = new MovieDB();
            return movieDB.Insert(movie);

        }
        public int RateMovies(RateMovie rateMovie)
        {
            RateMovieDB rateMovieDB = new RateMovieDB();
            RateMovie current = rateMovieDB.IsExist(rateMovie);
            if (current == null)
                return rateMovieDB.Insert(rateMovie);
            rateMovie.Id = current.Id;
            return rateMovieDB.Update(rateMovie);
        }
        public int RateShows(RateShow rateShow)
        {
            RateShowDB rateshowDB = new RateShowDB();
            RateShow current = rateshowDB.IsExist(rateShow);
            if (current == null)
                return rateshowDB.Insert(rateShow);
            rateShow.Id = current.Id;
            return rateshowDB.Update(rateShow);
       
        }
        public int InsertShows(Show show)
        {
            ShowDB ShowDB = new ShowDB();
            return ShowDB.Insert(show);

        }
        public string GetShowinfo(string ShowName)
        {
            return ApiData.GetMovieData(ShowName);
        }
        public int DeleteShows(Show show)
            {
                ShowDB ShowDB = new ShowDB();
                return ShowDB.Delete(show);
            }

        public int DeleteMovies(Movie movie)
        {

            RateMovieList rateMovies = GetMovieRatingByMovie(movie);
            foreach (RateMovie rate in rateMovies)
            {
                DeleteRateMovies(rate);
            }
            MovieDB movieDb = new MovieDB();
            return movieDb.Delete(movie);
        }
        public int DeleteRateMovies(RateMovie rateMovie)
            {
                RateMovieDB movieDb = new RateMovieDB();
                return movieDb.Delete(rateMovie);
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
        #region Category
            public CategoryList GetAllCategories()
            {
                CategoryDB categoryDB = new CategoryDB();
                return (categoryDB.SelectAll());
            }
            public int InsertCategory(Category category)
            {
                CategoryDB categoryDB = new CategoryDB();
                return (categoryDB.Insert(category));
            }
            public int UpdateCategory(Category category)
            {
                CategoryDB categoryDB = new CategoryDB();
                return (categoryDB.Update(category));
            }
            public int DeleteCategory(Category category)
            {
                CategoryDB categoryDB = new CategoryDB();
                return (categoryDB.Delete(category));
            }
            #endregion

        }
    }
