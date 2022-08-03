namespace SWData
{
    public class Sleep : Activity
    {
        public string Quality { get; set; }
        public int Count { get; set; }
        public int Activity_id { get; set; }
        public void SetSleepGoal(int sleepGoal) { Goal = sleepGoal; }
        public Sleep(DateTime date, int duration, string quality, int goal, int count)
        {
            Quality = quality;
            Goal = goal;
            Duration = duration;
            Date = date;
            Count = count;
            Activity_id = _id;
        }
        public virtual HeartRate HeartRate { get; set; }//dodano

        public override string ToString()
        {
            Console.WriteLine("\t Sleep n*" + Count + ": ");
            Console.WriteLine("\t\t Date & Time: " + Date);
            Console.WriteLine("\t\t Duration: " + Duration + " hours");
            Console.WriteLine("\t\t Quality: " + Quality);
            Console.WriteLine("\t\t Goal: " + Goal + " hours");
            return "";
        }
    }
}
