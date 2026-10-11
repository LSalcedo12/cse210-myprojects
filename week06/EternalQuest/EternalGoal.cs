public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }
    
    public override void RecordEvent()
    {
        //Gain some value
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[ ] {GetShortName()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal: {GetShortName()}, {GetDescription()}, {GetPoints()}";
    }   
}