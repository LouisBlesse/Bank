using System;
using System.Windows;

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
                MainWindow.Co_User(UserLastName.Text, UserMdp.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }    
        }
        
        private void Button_Click_Admin(object sender, RoutedEventArgs e)
        {
        try
        {
            MainWindow.Co_Admin(AdminName.Text, AdminMdp.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void Button_Click_NewAdmin(object sender, RoutedEventArgs e)
        {
            CreationCompteAdmin p = new CreationCompteAdmin(); 
            p.Show();
        }
    }
}