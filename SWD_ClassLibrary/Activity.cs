using System;

namespace SWData
{
    abstract public class Activity
    {
        public int _id;
        public int Goal { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return "Activity: " + "[" + Date + "]" + "Duration:" + Duration + " -Goal:" + Goal + "";//+ HeartRate;
        }
    }
}
