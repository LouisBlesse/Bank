using System;
using System.Data.SQLite;
using System.Globalization;
using System.Windows;
using Bank.Entity;

namespace Bank
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      
      /*SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "INSERT INTO admin (identifiant, password) values (\"1111\",\"0000\")";
      command.ExecuteNonQuery();*/
      SQLiteCommand commandSelect = SQL.CreateCommand();
      commandSelect.CommandText = "SELECT * FROM admin";
      
      SQLiteDataReader reader = commandSelect.ExecuteReader();
      while (reader.Read())
      {
        State.Text=reader["identifiant"].ToString();
      }
      SQL.Close();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      try
      { 
        Menu p = new Menu();
        p.Show();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        throw;
      }
    }
    
    
    public static void Co_Admin(string identifiant, string password)
    {
      //Connection de l'admin
      try
      {
        SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
        SQL.Open();
        
        SQLiteCommand commandSelect = SQL.CreateCommand();
        commandSelect.CommandText = "select * from admin where identifiant='"+ identifiant + "'and  password ='"+ password +"'";


        SQLiteDataReader reader = commandSelect.ExecuteReader();
        while (reader.Read())
        {
          Admin MyAdmin = new Admin(reader["id"].ToString() , reader["identifiant"].ToString(),
            reader["password"].ToString());// Create the Admin 
        
          PageAdmin p = new PageAdmin(MyAdmin); //New page admin
          p.Show();
        }
        SQL.Close();
      }
      catch (Exception e)
      {
        MessageBox.Show(e.ToString());
        throw;
      }
      
    }

    public static void Create_Admin(string identifiant, string password)
    {
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();//TODO Creat JSon file and get the value from it
      
      SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "INSERT INTO admin (identifiant, password) values ('"+identifiant+"', '"+password+"')";
      command.ExecuteNonQuery();
      
      //TODO Give the vale to the jason file
      SQL.Close();
    }
  }
}
