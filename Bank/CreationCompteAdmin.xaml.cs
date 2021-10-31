using System.Windows;


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
            MainWindow.Create_Admin(pseudo.Text,mdp.Text);
            this.Close();
        }
    }
}

