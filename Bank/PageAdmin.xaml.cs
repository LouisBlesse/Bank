using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Bank.Entity;

namespace Bank
{
    public partial class PageAdmin : Window
    {
        private Admin MyAdmin;
        public Task<Exchangerate.RootRoot> AllCurrency;
        public PageAdmin(Admin MyAdmin)
        {
            this.MyAdmin = MyAdmin;
            AllCurrency = GetAll();
            InitializeComponent();
            Hello.Content = "Bonjour Monsieur " + MyAdmin.identifiant;
        }

        public async Task<Exchangerate.RootRoot> GetAll()
        {
            Exchangerate Lune = new Exchangerate();
            string mavariable = await Lune.ConnectGetAllCurency();
            Exchangerate.RootRoot tmp = Lune.transfertCurrency(mavariable);
            List<string> allCurrency = new List<string>(); 
            try
            {
                for (int i = 0; i < tmp.supported_codes.Count; i++)
                {
                    allCurrency.Add(tmp.supported_codes[i][0]);
                }
                currencyHigh.ItemsSource = allCurrency;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return tmp;
        }

        public void Button_Creat_user(object sender, RoutedEventArgs e)
        {
            //User MyUser = new User(first_name.Text, last_name.Text, pin.Text, currencyHigh.SelectedValue.ToString());
            MainWindow.Create_User(first_name.Text, last_name.Text, pin.Text, currencyHigh.SelectedValue.ToString());
        }

        private void decoAdmin(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            Close();
            menu.Show();
        }

        private void showDataClient(object sender, RoutedEventArgs e)
        {
          User user =   MainWindow.select_User(nomClient.Text);
          if (user != null)
          {
              statusClient.IsChecked = Convert.ToBoolean(user.block);
              PinClient.Text = user.pin;
          }
          else
          {
              MessageBox.Show("il n'y pas de user " + nomClient.Text);
          }



        }
    }
}