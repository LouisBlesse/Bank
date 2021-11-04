using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using Bank.Entity;

namespace Bank
{
    public partial class ListUsers : Window
    {
        public ListUsers()
        {
            InitializeComponent();
        }

 
        private void printUser(object sender, RoutedEventArgs e)
        {
          List<User> Users = MainWindow.printAllUser();
          List<string> AllUsers = new List<string>();
          string test = "";
          for (int i = 0; i < Users.Count; i++)
          {
              test = Users[i].id + " "  + Users[i].block + "" + Users[i].first_name  + Users[i].last_name;
              AllUsers.Add(test);
          }

          for (int i = 0; i < AllUsers.Capacity; i++)
          {
              test.Concat(AllUsers[i]);
          }

          first_name.Text = test;
        }
    }
}