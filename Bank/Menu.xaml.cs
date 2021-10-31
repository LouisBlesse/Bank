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
                PageClient p = new PageClient( );
                p.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }    
        }
    }
}