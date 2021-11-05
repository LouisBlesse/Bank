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
           
          string test = "";
          for (int i = 0; i < Users.Capacity; i++)
          {
              test +=  Users[i].first_name;
          }
        
        
           
 
          first_name.Text = test;
        }
    }
}