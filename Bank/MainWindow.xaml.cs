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
        Close();
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
      SQL.Open();

      SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "INSERT INTO admin (identifiant, password) values ('"+identifiant+"', '"+password+"')";
      command.ExecuteNonQuery();
      
      SQL.Close();
    }
    
    
    public static void Co_User(string UserLastName, string pin)
    {
      //Connection de l'user
      try
      {
        SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
        SQL.Open();
        
        SQLiteCommand commandSelect = SQL.CreateCommand();
        commandSelect.CommandText = "select * from client where last_name='"+ UserLastName + "'and  pin ='"+ pin +"'";

        SQLiteDataReader reader = commandSelect.ExecuteReader();
        while (reader.Read())
        {
          User MyUser = new User(reader["id"].ToString() , reader["block"].ToString(),
            reader["first_name"].ToString(),
            reader["last_name"].ToString(),
            reader["pin"].ToString(),
            reader["main_currency"].ToString(),
            reader["user_try"].ToString());
        
          PageClient p = new PageClient(MyUser); //New page admin
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
    
    public static void Create_User(string first_name, string last_name,string pin, string main_currency)
    {
      
      string id = Guid.NewGuid().ToString();
      bool block = false;
      
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();

      SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "INSERT INTO client (id, block, first_name, last_name, pin, main_currency, user_try) values ('"+id+"', "+block+",'"+first_name+"','"+last_name+"',"+Int32.Parse(pin)+",'"+main_currency+"',0)";
      command.ExecuteNonQuery();
      
      SQL.Close();
      
    }
    public static User select_User(string UserLastName )
    {
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "select * from client where last_name=\""+ UserLastName+ "\"";
      
      SQLiteDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
        User MyUser = new User(reader["id"].ToString() , reader["block"].ToString(),
          reader["first_name"].ToString(),
          reader["last_name"].ToString(),
          reader["pin"].ToString(),
          reader["main_currency"].ToString(),
        reader["user_try"].ToString());
        return MyUser;
      }

      return null;
    }

    public static void update(string pin, string UserLastName)
    {
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      SQLiteCommand command = SQL.CreateCommand();
      // UPDATE table SET nom_colonne_1 = 'nouvelle valeur' WHERE condition
    //  command.CommandText = "delete from client where last_name=\""+ UserLastName+ "\"";
      command.CommandText = "update client set pin=\""+ pin +"\" where last_name =\"" + UserLastName + "\""; 
    //  command.CommandText = $"update client set pin=\"{pin}\" where last_name=\"{UserLastName}";
      command.ExecuteNonQuery();
      SQL.Close();
    }
    
    public static void delete(string UserLastName)
    {
         
 
         
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
   
      SQLiteCommand command = SQL.CreateCommand();
       

      command.CommandText = "delete from client where last_name=\""+ UserLastName+ "\"";
      command.ExecuteNonQuery();
         
      SQL.Close();
         
    }
  }
}
