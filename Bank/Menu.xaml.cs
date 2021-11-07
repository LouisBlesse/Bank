using System;
using System.Security.AccessControl;
using System.Windows;
using Bank.Entity;

namespace Bank
{
    public partial class Menu : Window
    {
         
        public Menu()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          try
          {
              if (MainWindow.Co_User(UserLastName.Text, UserMdp.Text))
                  Close();
              else
                  MessageBox.Show("bad credentials");
          }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }    
        }
        private void Button_Click_Admin(object sender, RoutedEventArgs e)
        {
        try
        {
            if (MainWindow.Co_Admin(AdminName.Text, AdminMdp.Text))
                Close();
            else
                MessageBox.Show("bad credentials");
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Button_Click_NewAdmin(object sender, RoutedEventArgs e)
        {
            CreationCompteAdmin p = new CreationCompteAdmin(); 
            p.Show();
        }
    }
}