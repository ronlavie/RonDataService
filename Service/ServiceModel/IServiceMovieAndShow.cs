using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace ServiceModel
{
    [ServiceContract]
    public  interface IServiceMovieAndShow
    {
        #region Users
        [OperationContract] UserList GetAllUsers();
        [OperationContract] User Login(User user);
        [OperationContract] bool CheckUserName(string UserName);
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        #endregion
        #region Movies
        [OperationContract] MovieList GetAllMovies();
        [OperationContract] MovieList GetAllMoviesFullData();
        [OperationContract] int InsertMovies(Movie movie);
        [OperationContract] int UpdateMovies(Movie movie);
        [OperationContract] int DeleteMovies(Movie movie);
        [OperationContract] RateMovieList GetMovieRatingByMovie(Movie movie);
        [OperationContract] RateMovieList GetMovieRatingByUser(User user);
        //Rate actions
        [OperationContract] int RateMovies(RateMovie rateMovie);
        [OperationContract] int DeleteRateMovies(RateMovie rateMovie);
        //API info
        [OperationContract] string GetMovieinfo(string movieName);
        #endregion
        #region Shows
        [OperationContract] ShowList GetAllShows();
        [OperationContract] ShowList GetAllShowsFullData();
        [OperationContract] RateShowList GetShowRatingByShow(Show show);
        [OperationContract] RateShowList GetShowRatingByUser(User user);
        [OperationContract] int InsertShows(Show show);
        [OperationContract] int UpdateShows(Show show);
        [OperationContract] int DeleteShows(Show show);
        [OperationContract] int RateShows(RateShow rateShow);
        [OperationContract] string GetShowinfo(string ShowName);



        #endregion
        #region Category
        [OperationContract] CategoryList GetAllCategories();
        [OperationContract] int InsertCategory(Category category);
        [OperationContract] int UpdateCategory(Category category);
        [OperationContract] int DeleteCategory(Category category);
        #endregion
    }
}
