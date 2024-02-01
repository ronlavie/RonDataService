﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_RON.ServiceReferenceMovieAndShow;

namespace WPF_RON
{
    /// <summary>
    /// Interaction logic for UserControlEditUser.xaml
    /// </summary>
    public partial class UserControlEditUser : UserControl
    {
        UserList Users;
        User usr;
        bool update;
        ServiceMovieAndShowClient service;
        public UserControlEditUser()
        {
            InitializeComponent();
            service = new ServiceMovieAndShowClient();
            lbUsers.ItemsSource = Users = service.GetAllUsers();
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbUsers.ItemsSource = Users.FindAll(m => m.UserName.Contains(tbSearch.Text));
        }
        private void lbCategorys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usr = lbUsers.SelectedValue as User;
            spEdit.DataContext = usr;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            update = false;

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (update)
            {
                service.UpdateUser(usr);
            }
            else
            {
                service.InsertUser(usr);
            }

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            tbName.Clear();
        }
    }
}



