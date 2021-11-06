using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Runtime.Remoting;
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
      SQL.Close();
      return null;
    }

    public static void update(string pin, string UserLastName)
    {
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "update client set pin=\""+ pin +"\" where last_name =\"" + UserLastName + "\""; 
      command.ExecuteNonQuery();
      SQL.Close();
    }

    public static void updateAdmin(string password, string identifiant)
    {
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "update admin set password=\""+ password +"\" where identifiant =\"" + identifiant + "\""; 
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

    public static List<User>  printAllUser()
    {
      List<User>   first = new List<User> {  };

      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
   
      SQLiteCommand command = SQL.CreateCommand();
       
      command.CommandText = "select * from client";
      
      SQLiteDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
        User MyUser = new User(reader["id"].ToString() , reader["block"].ToString(),
          reader["first_name"].ToString(),
          reader["last_name"].ToString(),
          reader["pin"].ToString(),
          reader["main_currency"].ToString(),
          reader["user_try"].ToString());
        first.Add(MyUser);
    
      }
      SQL.Close();
      return first;
    }

    public static List<string> GetAllCur(User user)
    {
      List<string> Cur = new List<string> ();

      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      
      SQLiteCommand command = SQL.CreateCommand();
       
      command.CommandText = "select id_currency from user_currency where id_user =\""+ user.id+ "\"";
      
      SQLiteDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
        Cur.Add(reader["id_currency"].ToString());
      }

      return Cur;
    }
    
    public static void GiveToUser(string last_name, int amount)
    {
      string cur_name="try";
      string id_user = "try";
      
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      
      SQLiteCommand command3 = SQL.CreateCommand();
      command3.CommandText = "select id from client where last_name =\""+ last_name+ "\"";
      SQLiteDataReader reader3 = command3.ExecuteReader();
      while (reader3.Read())
      {
        id_user=(reader3["id"].ToString());
      }
      
      
      SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "select main_currency from client where id =\""+ id_user+ "\"";
      SQLiteDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
        cur_name=(reader["main_currency"].ToString());
      }
      
      SQLiteCommand command2 = SQL.CreateCommand();
      command2.Parameters.AddWithValue("@param1", id_user);
      command2.Parameters.AddWithValue("@param2", cur_name);
      command2.Parameters.AddWithValue("@param3", amount);
      try
      {
        command2.CommandText = "INSERT INTO user_currency (id_user, id_currency, amount) values (@param1, @param2,@param3)";
        command2.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        command2.CommandText = "UPDATE user_currency SET amount=@param3 where id_user=@param1 and  id_currency = @param2;";
        command2.ExecuteNonQuery();
        Console.WriteLine(e);
      }

      SQL.Close();
    }

    public static int GetVAlue(string id_user, string id_currency)
    {
      int amount = 0;
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "select amount from user_currency where id_user='"+ id_user + "'and  id_currency ='"+ id_currency +"'";
      
      SQLiteDataReader reader = command.ExecuteReader();
      while (reader.Read())
      {
        amount = Int32.Parse(reader["amount"].ToString());
      }
      SQL.Close();
      return amount;
    }


    public static void ConvertVal(string NameOld, string NameNew,int ValOld, double ValNew, User user)
    {
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      
      SQLiteCommand command = SQL.CreateCommand();
      command.Parameters.AddWithValue("@param1", ValOld);
      command.Parameters.AddWithValue("@paramID", user.id);
      command.Parameters.AddWithValue("@paramNO", NameOld);
      command.CommandText = "update user_currency set amount=amount - @param1 where id_user =@paramID and id_currency =@paramNO"; 
      command.ExecuteNonQuery();
      
      
      
      SQLiteCommand command2 = SQL.CreateCommand();
      command2.Parameters.AddWithValue("@param1", user.id);
      command2.Parameters.AddWithValue("@param2", NameNew);
      command2.Parameters.AddWithValue("@param3", ValNew);
      try
      {
        command2.CommandText = "INSERT INTO user_currency (id_user, id_currency, amount) values (@param1, @param2,@param3)";
        command2.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        command2.CommandText = "UPDATE user_currency SET amount= amount + @param3 where id_user=@param1 and  id_currency = @param2;";
        command2.ExecuteNonQuery();
        Console.WriteLine(e);
      }
      SQL.Close();
    }


    public static void ajoutArgent(int amount, User user, string currency)
    {
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      
      SQLiteCommand command = SQL.CreateCommand();
      command.Parameters.AddWithValue("@param1", user.id);
      command.Parameters.AddWithValue("@param2", currency);
      command.Parameters.AddWithValue("@param3", amount);
      try
      {
        command.CommandText = "INSERT INTO user_currency (id_user, id_currency, amount) values (@param1, @param2,@param3)";
        command.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        command.CommandText = "UPDATE user_currency SET amount= amount + @param3 where id_user=@param1 and  id_currency = @param2;";
        command.ExecuteNonQuery();
        Console.WriteLine(e);
      }
      SQL.Close();
    }
    
    public static void enleveArgent(int amount, User user, string currency)
    {
      SQLiteConnection SQL = new SQLiteConnection("Data Source=BDD.db");
      SQL.Open();
      
      SQLiteCommand command = SQL.CreateCommand();
      command.Parameters.AddWithValue("@param1", user.id);
      command.Parameters.AddWithValue("@param2", currency);
      command.Parameters.AddWithValue("@param3", amount);
      try
      {
        command.CommandText = "INSERT INTO user_currency (id_user, id_currency, amount) values (@param1, @param2,-@param3)";
        command.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        command.CommandText = "UPDATE user_currency SET amount= amount - @param3 where id_user=@param1 and  id_currency = @param2;";
        command.ExecuteNonQuery();
        Console.WriteLine(e);
      }
      SQL.Close();
    }
  }
  
  

}
