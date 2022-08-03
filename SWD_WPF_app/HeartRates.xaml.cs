using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

static class GlobalnaVar
{
    public static int odabrano;

}

namespace WpfApp1
{   

    /// <summary> 
    /// Interaction logic for HeartRates.xaml
    /// </summary>
    public partial class HeartRates : Page
    {
        public void Fill_HRlistbox()
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
            cmd.CommandText = "select * from HeartRates";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBoxHeartRate.Items.Add(reader["_id"]);
            }
            //int i = listBoxHeartRate.Items.Count;
            connection.Close();
            
        }
        
        public HeartRates()
        {
            InitializeComponent();
            Fill_HRlistbox();
        } 

        void SelectHR(object sender, SelectionChangedEventArgs args)
        {   
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            GlobalnaVar.odabrano = listBoxHeartRate.SelectedIndex + 1;
            HeartRatesFrame.Content = new HeartRatesSample();
        }

        private void OpenSelectedHeartRate(object sender, RoutedEventArgs e)
        {
            HeartRatesFrame.Content = new HeartRatesSample();
        }
    }
}
