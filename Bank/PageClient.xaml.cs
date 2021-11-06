using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Bank.Entity;

namespace Bank
{
    public partial class PageClient : Window
    {
       // private static Task<Exchangerate.Root> AllData;
        private static Task<Exchangerate.RootRoot> AllCurrency;
        private User MyUser;
 
         public PageClient(User MyUser)
         {
             this.MyUser = MyUser;
             InitializeComponent();
             Hello.Content = "Bonjour Monsieur " + MyUser.last_name;
         //   PageClient.AllData = Initialize();
            AllCurrency = InitializeCurrency();
            currencyHigh.ItemsSource = MainWindow.GetAllCur(MyUser);
            ComboBoxtest.ItemsSource = MainWindow.GetAllCur(MyUser);
            ComboBoxtestAjout.ItemsSource = MainWindow.GetAllCur(MyUser);

         }
         //function conversion

         private async void Initialize()
        {
            Exchangerate Lune = new Exchangerate();
            string a = ComboBoxtest.SelectedValue.ToString(), b = currencyRight.SelectedValue.ToString();
            int c = Int32.Parse(State_Copy1.Text);
            string test  = await Lune.Connect(a,b,c);
            State_Copy2.Text = Lune.transfert(test).conversion_result.ToString();

            double Var = Convert.ToDouble(State_Copy2.Text);
            MainWindow.ConvertVal(ComboBoxtest.SelectedValue.ToString(), currencyRight.SelectedValue.ToString(),Int32.Parse(State_Copy1.Text),Var,MyUser);
            currencyHigh.ItemsSource = MainWindow.GetAllCur(MyUser);
            ComboBoxtest.ItemsSource = MainWindow.GetAllCur(MyUser);
            ComboBoxtestAjout.ItemsSource = MainWindow.GetAllCur(MyUser);
        }
         
         public async Task<Exchangerate.RootRoot> InitializeCurrency()
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
                    //ComboBoxtest.ItemsSource = allCurrency;
                    currencyRight.ItemsSource = allCurrency;    
                    //currencyHigh.ItemsSource = allCurrency;
                }
                catch (Exception e)
                {
                     e.ToString();
                }
                return tmp;
        }
        private void convert(object sender, RoutedEventArgs e)
        { 
          Initialize();
        }

        private void deconnexion(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Close();
        }

        public void SeachMoney(object sender, RoutedEventArgs e)
        {
            ValueIS.Content = "est de :"+MainWindow.GetVAlue(MyUser.id, currencyHigh.SelectedValue.ToString()).ToString();
        }
        
        public void AddArgent(object sender, RoutedEventArgs e)
        {
            MainWindow.ajoutArgent(Int32.Parse(AmountAdd.Text), MyUser, ComboBoxtestAjout.SelectedValue.ToString());
        }
        
        public void EnleverArgent(object sender, RoutedEventArgs e)
        {
            MainWindow.enleveArgent(Int32.Parse(AmountAdd.Text), MyUser, ComboBoxtestAjout.SelectedValue.ToString());
        }
        
    }
}