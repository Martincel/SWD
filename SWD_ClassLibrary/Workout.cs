namespace SWData
{
    public class Workout : Activity
    {
        public int Intensity { get; set; }
        public int Count { get; set; }
        //ispod cu probat
        public int Activity_id { get; set; }

        public Workout(DateTime date, int duration, int intensity, int goal, int count)
        {
            Intensity = intensity;
            Goal = goal;
            Duration = duration;
            Date = date;
            Count = count;
            Activity_id = _id;//dodano
        }

        public void SetWGoal(int wGoal) { Goal = wGoal; }
        public virtual Step Step { get; set; }
        public virtual HeartRate HeartRate { get; set; }//dodano i radi, dosad se pokazivac nasljediva iz activity sta je glupo

        public override string ToString()
        {
            Console.WriteLine("\t Workout n*" + Count + ": ");
            Console.WriteLine("\t\t Date & Time: " + Date);
            Console.WriteLine("\t\t Duration: " + Duration + " minutes");
            Console.WriteLine("\t\t Goal: " + Goal + " minutes");
            Console.WriteLine("\t\t With a total of: " + Step.StepCount + " steps and a goal of: " + Step.StepGoal);
            Console.WriteLine("\t\t\t Recorded Heart Rate Data: ");
            Console.WriteLine("\t\t\t The Lowest Heart Rate Was " + HeartRate.LowestHR + " BPM" + " and The Highest " + HeartRate.HighestHR);
            Console.WriteLine("\t\t\t Range: " + HeartRate.Range + " BPM");
            Console.WriteLine("\t\t\t Average: " + HeartRate.Average + " BPM");
            return "";
        }
    }
}
