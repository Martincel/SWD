public class HeartRate
{
    public int _id;
    public int Range;
    public double Average;
    public int HighestHR;
    public int LowestHR;
    
    
    public void SetAverage() { Average = (HighestHR + LowestHR) / 2; }
    public void SetRange() { Range = HighestHR - LowestHR; }

    public HeartRate(int HighestHR, int LowestHR) 
    {
        this.HighestHR=HighestHR; 
        this.LowestHR=LowestHR;
        SetAverage(); SetRange();
    }
    
    public override string ToString()
    {
        return "Heart Rate Range: " + Range + "   Highest Heart Rate: " + HighestHR + "   " +
            "Lowest Heart Rate: " + LowestHR + "With Average of " + Average;
    }
}

