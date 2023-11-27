using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace WCF_RON
{
    [ServiceContract]
    public  interface IService
    {
        [OperationContract]

        MovieList GetAllMovies();
        [OperationContract]
        UserList GetAllUsers();
        [OperationContract]
        User Login(User user);
        [OperationContract]
        ShowList GetAllShows();
        [OperationContract]
        int InsertMovie(Movie movie);
        [OperationContract]
        int UpdateMovie(Movie movie);
        [OperationContract]
        int DeleteMovie(Movie movie);
        [OperationContract]
        int InsertUser(User user);
        [OperationContract]
        int UpdateUser(User user);
        [OperationContract] 
        int DeleteUser(User user);
        [OperationContract]
        int InsertShow(Show show);
        [OperationContract]
        int UpdateShows(Show show);
        [OperationContract]
        int DeleteShows(Show show);

    }
}
