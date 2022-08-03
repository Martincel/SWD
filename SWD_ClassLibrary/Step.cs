public class Step
{
    public int _id { get; set; }    
    public int StepCount { get; set; }
    public int StepGoal { get; set; }
    
    public void SetStepGoal(int stepGoal) { this.StepGoal = stepGoal; }
    public Step(int stepCount, int stepGoal) { StepCount = stepCount; StepGoal = stepGoal; }
    public override string ToString()
    {
        return "Step Count: " + StepCount + " steps " + "   [Step Goal: " + StepGoal + " steps]";
    }
}

