using System.Windows;
using Bank.Entity;

namespace Bank
{
    public partial class PageAdmin : Window
    {
        private Admin MyAdmin;
        public PageAdmin(Admin MyAdmin)
        {
            this.MyAdmin = MyAdmin;
            InitializeComponent();
            Hello.Content = "Bonjour Monsieur " + MyAdmin.identifiant;
        }
    }
}