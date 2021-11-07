using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
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
            
            for (int i = 0; i < Users.Count; i++)
            {  
                StackPanel panel = new StackPanel();
              
                panel.Orientation = Orientation.Horizontal;
                panel.HorizontalAlignment = HorizontalAlignment.Center;
                panel.VerticalAlignment = VerticalAlignment.Center;

                panel.Children.Add(CreateTextBox( Users[i].first_name));
                panel.Children.Add(CreateTextBox( Users[i].block));
                panel.Children.Add(CreateTextBox( Users[i].last_name));
                panel.Children.Add(CreateTextBox( Users[i].pin));
              
                StackUser.Children.Add(panel);
            }
        }

        public TextBlock CreateTextBox(string value)
        {
            TextBlock box = new TextBlock();
            box.Text = value;
            box.Foreground = Brushes.White;
            box.Margin = new Thickness(10, 10, 10, 10);

            return box;
        }

        private void closePage(object sender, RoutedEventArgs e)
        {
           Close();
        }
    }
}