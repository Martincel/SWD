using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System;

namespace WpfApp1
{
    public partial class Workouts : Page
    {
        public bool ButtonClicked=false;
        public void Fill_Workoutlistbox()
        {
            string connectionString;
            SqlConnection connection;
            connectionString = "Server=(localdb)\\MSSQLLocalDB;Database = SmartwatchData; Integrated Security = True; " +
                "Trusted_Connection = true; MultipleActiveResultSets = True";
            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from Workouts";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var i = reader["Count"];
                WorkoutsListBox.Items.Add(i);
            }
            connection.Close();
        }
        public Workouts()
        {
            InitializeComponent();
            Fill_Workoutlistbox();
        }
        private void OpenSelectedWorkout(object sender, RoutedEventArgs e)
        {
            GlobalnaVar.odabrano = WorkoutsListBox.SelectedIndex;
            White.Height = 0;
            White.Width = 0;
            WorkoutsFrame.Content = new WorkoutSample();
        }
        private void textBox_TextChanged(/*object sender, TextChangedEventArgs e*/)
        {
            if (this.IsLoaded && WorkoutsListBox.SelectedIndex!=-1 && InputTextBox.Text.Length>0) 
            {
                int a;
                    var uneseno = InputTextBox.Text.ToString();
                a = Int16.Parse(uneseno);
                    if (a >= 0 && a < 999)
                    {
                        string connectionString;
                        SqlConnection connection;
                        connectionString = "Server=(localdb)\\MSSQLLocalDB;Database = SmartwatchData; Integrated Security = True; " +
                        "Trusted_Connection = true; MultipleActiveResultSets = True";
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                        SqlCommand cmd;
                        cmd = new SqlCommand();
                        cmd.Connection = connection;
                        string Naredba = "Update Activities Set Goal =";
                        Naredba += a.ToString();
                        Naredba += " Where _id= (SELECT Activity_id from Workouts where _id=";
                        Naredba += GlobalnaVar.odabrano + 3;
                        Naredba += ")";
                        cmd.CommandText = Naredba;
                        cmd.ExecuteNonQuery();
                        connection.Close();
                }
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked = true;
            WorkoutsFrame.Content = new WorkoutSample();
            textBox_TextChanged();
        }
    }
}
