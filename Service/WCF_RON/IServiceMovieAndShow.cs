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
        [OperationContract] ShowList GetAllShows();
        [OperationContract] MovieList GetAllMovies();
        [OperationContract] UserList GetAllUsers();
        [OperationContract] User Login(User user);
        [OperationContract] bool CheckUserName(string UserName);
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        [OperationContract] int InsertMovies(Movie movie);
        [OperationContract] int UpdateMovies(Movie movie);
        [OperationContract] int DeleteMovies(Movie movie);
        [OperationContract] int InsertShows(Show show);
        [OperationContract] int UpdateShows(Show show);
        [OperationContract] int DeleteShows(Show show);

    }
}
