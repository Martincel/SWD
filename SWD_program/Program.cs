using SWData;

namespace SWDprogram
{
    class Program
    {
        static Sleep sleepA, sleepB;
        static Step step1, step2, step3, step4;
        static Workout WorkoutA, WorkoutB, WorkoutC, WorkoutD;
        static HeartRate heartrate1, heartrate2, heartrate3, heartrate4, heartrate5, heartrate6;
        static DataContext context;
        static DateTime date1, date2, date3, date4, date5, date6;
        static void Main(string[] args)
        {
            CreateObjects();
            PrintData();
            PopulateDatabase();
            ExecuteQueries();
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
        static void CreateObjects()
        {
            date1 = new DateTime(2021, 12, 25, 07, 03, 24);
            date2 = new DateTime(2021, 1, 10, 09, 20, 58);
            date3 = new DateTime(2022, 6, 2, 19, 11, 12);
            date4 = new DateTime(2022, 6, 10, 18, 22, 01);
            date5 = new DateTime(2022, 6, 11, 19, 27, 23);
            date6 = new DateTime(2022, 6, 13, 21, 00, 07);
            sleepA = new Sleep(date1, 8, "Good", 8, 1);
            sleepB = new Sleep(date2, 6, "Bad", 8, 2);
            WorkoutA = new Workout(date3, 47, 5, 60,/*count*/1);
            WorkoutB = new Workout(date4, 123, 2, 120,/*count*/ 2);
            WorkoutC = new Workout(date5, 32, 7, 60,/*count*/3);
            WorkoutD = new Workout(date6, 140, 4, 130,/*count*/4);
            heartrate1 = new HeartRate(180, 60);
            heartrate2 = new HeartRate(102, 58);
            heartrate3 = new HeartRate(130, 73);
            heartrate4 = new HeartRate(115, 44);
            heartrate5 = new HeartRate(54, 46);
            heartrate6 = new HeartRate(72, 58);
            step1 = new Step(4125, 4500);
            step2 = new Step(7932, 6000);
            step3 = new Step(2530, 2000);
            step4 = new Step(1214, 5000);
            WorkoutA.Step = step1;
            WorkoutB.Step = step2;
            WorkoutC.Step = step3;
            WorkoutD.Step = step4;
            WorkoutA.Activity_id = 1;
            WorkoutB.Activity_id = 2;
            WorkoutC.Activity_id = 3;
            WorkoutD.Activity_id = 4;
            WorkoutA.HeartRate = heartrate1;
            WorkoutB.HeartRate = heartrate2;
            WorkoutC.HeartRate = heartrate3;
            WorkoutD.HeartRate = heartrate4;
            sleepA.HeartRate = heartrate5;
            sleepB.HeartRate = heartrate6;
            sleepA.Activity_id = 5;
            sleepB.Activity_id = 6;
        }
        static void PrintData()
        {
            Console.WriteLine("Successfully created database----------------------------------------------");
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Workouts:"); Console.WriteLine();
            Console.WriteLine(WorkoutA);
            Console.WriteLine(WorkoutB);
            Console.WriteLine(WorkoutC);
            Console.WriteLine(WorkoutD);
            Console.WriteLine("Sleeps:"); Console.WriteLine();
            Console.WriteLine(sleepA);
            Console.WriteLine(sleepB);
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Data printing complete-------------------------");
        }
        static void PopulateDatabase()
        {
            context = new DataContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Sleeps.Add(sleepA);
            context.Sleeps.Add(sleepB);
            context.Workouts.Add(WorkoutA);
            context.Workouts.Add(WorkoutB);
            context.Workouts.Add(WorkoutC);
            context.Workouts.Add(WorkoutD);
            int noRows = context.SaveChanges();
        }
        static void ExecuteQueries() { }
    }
}

