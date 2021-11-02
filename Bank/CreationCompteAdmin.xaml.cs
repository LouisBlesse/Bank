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

            salut.Background = Brushes.Green;
            MainWindow.Create_Admin(pseudo.Text,mdp.Text);
            // this.Close();
        }

        private void retour(object sender, RoutedEventArgs e)
        {
           // test.Background = Brushes.Green;
           Menu menu = new Menu();
           menu.Show();
           Close();
        }

        // test.Background = Brushes.Green;

        private void adminPage(object sender, RoutedEventArgs e)
        {
            test.Background = Brushes.White;
            Menu menu = new Menu();
            
        }
    }
}

