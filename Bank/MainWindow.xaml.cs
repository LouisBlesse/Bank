using System;
using System.Data.SQLite;
using System.Windows;

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
      
      
      
      
      SQLiteCommand command = SQL.CreateCommand();
      command.CommandText = "INSERT INTO admin (identifiant, password) values (\"1111\",\"0000\")";
      command.ExecuteNonQuery();
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
  }
}
