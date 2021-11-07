using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Bank
{
    public partial class CreationCompteAdmin : Window
    {
        public CreationCompteAdmin()
        {
            InitializeComponent();
        }

        public void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            MainWindow.Create_Admin(pseudo.Text,passwordAdminCreate.Password);
            Menu menu = new Menu();
            menu.Show();
            Close();
        }
        
        private void retour(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
           menu.Show();
           Close();
        }
       
    }
}

