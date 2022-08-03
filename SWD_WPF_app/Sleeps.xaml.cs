using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Sleeps.xaml
    /// </summary>
    public partial class Sleeps : Page
    {
        public bool ButtonClicked=false;
        public void Fill_Sleeplistbox()
        {
            string connectionString;
            SqlConnection connection;
            connectionString = "Server=(localdb)\\MSSQLLocalDB;Database = SmartwatchData; Integrated Security = True; Trusted_Connection = true; MultipleActiveResultSets = True";
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from Sleeps";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SleepListBox.Items.Add(reader["_id"]);
            }
            connection.Close();
        }
        public Sleeps()
        {
            InitializeComponent();
            Fill_Sleeplistbox();
        }

        private void OpenSelectedSleep(object sender, RoutedEventArgs e)
        {
            GlobalnaVar.odabrano = SleepListBox.SelectedIndex + 1;
            White.Height = 0;
            White.Width = 0;
            SleepsFrame.Content = new SleepSample();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked = true;
                SleepsFrame.Content = new SleepSample();
                textBox_TextChanged();
        }
        private void textBox_TextChanged()
        {
            if (this.IsLoaded && SleepListBox.SelectedIndex != -1 && InputTextBox.Text.Length > 0)
            {
                double a = -1;
                var uneseno = InputTextBox.Text.ToString();
                a = Double.Parse(uneseno);
                if (a >= 0 && a < 24)
                {
                    string connectionString;
                    SqlConnection connection;
                    connectionString = "Server=(localdb)\\MSSQLLocalDB;Database = SmartwatchData; Integrated Security = True; Trusted_Connection = true; MultipleActiveResultSets = True";
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlCommand cmd;
                    cmd = new SqlCommand();
                    cmd.Connection = connection;
                    string Naredba = "Update Activities Set Goal =";
                    Naredba += a.ToString();
                    Naredba += " Where _id= (SELECT Activity_id from Sleeps where _id=";
                    Naredba += GlobalnaVar.odabrano;
                    Naredba += ")";
                    cmd.CommandText = Naredba;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }
    }
}
