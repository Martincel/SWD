using System.Linq;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for HeartRatesSample.xaml
    /// </summary>
    
    public partial class HeartRatesSample : Page
    {
        public HeartRatesSample()
        {
            InitializeComponent();
            var a = GlobalnaVar.odabrano;
            fill_HRSample(a);//TREBA POSTAVITI a U VRIJEDNOST ODABRANOG BROJA ITEMA IZ LISTBOX-a
        }

        public void fill_HRSample(int a) { 
        string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database = SmartwatchData; Integrated Security = True; Trusted_Connection = true; MultipleActiveResultSets = True";
        SqlConnection connection = new SqlConnection(ConnectionString);

        // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
        connection.Open();
            SqlCommand cmd;
        SqlDataReader reader;

        cmd = new SqlCommand();
        cmd.Connection = connection;
            string sample = "select Range from HeartRates WHERE _id=";
            sample += a;
            
            cmd.CommandText = sample;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number5.Text = reader["Range"].ToString();
            }
                
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample2 = "select LowestHR from HeartRates WHERE _id=";
            sample2 += a;

            cmd.CommandText = sample2;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number3.Text = reader["LowestHR"].ToString();
            }
            
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample3 = "select HighestHR from HeartRates WHERE _id=";
            sample3 += a;

            cmd.CommandText = sample3;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number4.Text = reader["HighestHR"].ToString();
            }
            
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample4 = "select Average from HeartRates WHERE _id=";
            sample4 += a;

            cmd.CommandText = sample4;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number6.Text = reader["Average"].ToString();
            }
            connection.Close();
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
        }
    }
}
