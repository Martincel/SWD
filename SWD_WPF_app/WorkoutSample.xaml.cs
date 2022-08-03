using System.Data.SqlClient;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class WorkoutSample : Page
    {
        public WorkoutSample()
        {
            InitializeComponent();
            var a = GlobalnaVar.odabrano + 3;
            fill_WSample(a);
        }

        public void fill_WSample(int a)
        {
            string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database = SmartwatchData; Integrated Security = True; Trusted_Connection = true;" +
                " MultipleActiveResultSets = True";
            SqlConnection connection = new SqlConnection(ConnectionString);

            // __________________________________________________________________________DEFINICIJA TJ PRIKAZ IDUCEG PROPERTYA__________________________________
            connection.Open();
            SqlCommand cmd;
            SqlDataReader reader;

            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample = "select Intensity from Workouts WHERE _id=";
            sample += a;

            cmd.CommandText = sample;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBlock6_Copy3.Text = reader["Intensity"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample2 = "select Goal from Activities WHERE _id=(select Activity_id from Workouts where _id=";
            sample2 += a + ")";

            cmd.CommandText = sample2;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBlockGoal.Text = reader["Goal"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample3 = "select Duration from Activities WHERE _id=(select Activity_id from Workouts where _id=";
            sample3 += a + ")";
            cmd.CommandText = sample3;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBlock6_Copy2.Text = reader["Duration"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample4 = "select Date from Activities WHERE _id=(select Activity_id from Workouts where _id=";
            sample4 += a + ")";
            cmd.CommandText = sample4;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBlock6_Copy1.Text = reader["Date"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample5 = "select StepCount from Steps WHERE _id=(select Step_id from Workouts where _id=";
            sample5 += a + ")";
            cmd.CommandText = sample5;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBlock6.Text = reader["StepCount"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample6 = "select StepGoal from Steps WHERE _id=(select Step_id from Workouts where _id=";
            sample6 += a + ")";
            cmd.CommandText = sample6;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBlock6_Copy.Text = reader["StepGoal"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample7 = "select LowestHR from HeartRates WHERE _id=(select HeartRate_id from Workouts where _id=";
            sample7 += a + ")";
            cmd.CommandText = sample7;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number3.Text = reader["LowestHR"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample8 = "select HighestHR from HeartRates WHERE _id=(select HeartRate_id from Workouts where _id=";
            sample8 += a + ")";
            cmd.CommandText = sample8;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number4.Text = reader["HighestHR"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample9 = "select Range from HeartRates WHERE _id=(select HeartRate_id from Workouts where _id=";
            sample9 += a + ")";
            cmd.CommandText = sample9;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number5.Text = reader["Range"].ToString();
            }
            // __________________________________________________________________________DEFINICIJA TJ PRIKAZT IDUCEG PROPERTYA__________________________________
            cmd = new SqlCommand();
            cmd.Connection = connection;
            string sample10 = "select Average from HeartRates WHERE _id=(select HeartRate_id from Workouts where _id=";
            sample10 += a + ")";
            cmd.CommandText = sample10;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Number6.Text = reader["Average"].ToString();
            }
            connection.Close();
        }
    }
}


