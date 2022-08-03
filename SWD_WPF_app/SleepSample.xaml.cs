using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for SleepSample.xaml
    /// </summary>
    public partial class SleepSample : Page
    {
       
        public SleepSample()
        {
            InitializeComponent();
            var a = GlobalnaVar.odabrano;
            fill_SleepSample(a);//TREBA POSTAVITI a U VRIJEDNOST ODABRANOG BROJA ITEMA IZ LISTBOX-a
        }

        public void fill_SleepSample(int a)
        {
            string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database = SmartwatchData; Integrated Security = True; Trusted_Connection = true; MultipleActiveResultSets = True";
            SqlConnection connection = new SqlConnection(ConnectionString);

            // __________________________________________________________________________DEFINICIJA TJ PRIKAZ IDUCEG PROPERTYA__________________________________
            connection.Open();
            SqlCommand cmd;
            SqlDataReader reader;

            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample1 = "select Date from Activities WHERE _id=(select Activity_id from Sleeps where _id=";

            sample1 += a + ")";

            cmd.CommandText = sample1;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                textBlock6_Copy1.Text = reader["Date"].ToString();
            }

            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________

            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample2 = "select Duration from Activities WHERE _id=(select Activity_id from Sleeps where _id=";
            sample2 += a + ")";

            cmd.CommandText = sample2;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBlock6_Copy2.Text = reader["Duration"].ToString();
            }

            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________

            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample3 = "select Goal from Activities WHERE _id=(select Activity_id from Sleeps where _id=";

            sample3 += a + ")";

            cmd.CommandText = sample3;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBlock6_Copy3.Text = reader["Goal"].ToString();
            }

            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample4 = "select Quality from Sleeps WHERE _id=";

            sample4 += a;

            cmd.CommandText = sample4;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                textBlock6.Text = reader["Quality"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________

            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample5 = "select LowestHR from HeartRates WHERE _id=(select HeartRate_id from Sleeps where _id=";

            sample5 += a + ")";

            cmd.CommandText = sample5;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number3.Text = reader["LowestHR"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________

            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample6 = "select HighestHR from HeartRates WHERE _id=(select HeartRate_id from Sleeps where _id=";

            sample6 += a + ")";

            cmd.CommandText = sample6;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number4.Text = reader["HighestHR"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________

            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample7 = "select Range from HeartRates WHERE _id=(select HeartRate_id from Sleeps where _id=";

            sample7 += a + ")";

            cmd.CommandText = sample7;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number5.Text = reader["Range"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________

            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample8 = "select Average from HeartRates WHERE _id=(select HeartRate_id from Sleeps where _id=";

            sample8 += a + ")";

            cmd.CommandText = sample8;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number6.Text = reader["Average"].ToString();
            }


            connection.Close();
        }
    }
}

    
