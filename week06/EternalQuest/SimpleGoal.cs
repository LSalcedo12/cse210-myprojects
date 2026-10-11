public class SimpleGoal : Goal
{
    private bool _IsComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, int.Parse(points))
    {
        _IsComplete = false;
    }

    public override void RecordEvent()
    {
        _IsComplete = true;
    }

    public override bool IsComplete()
    {
        return _IsComplete;
    }

    public override string GetDetailsString()
    {
        string checkbox = _IsComplete ? "[x]" : "[ ]";
        return $"{checkbox} {GetShortName()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal: {_shortName}, {_description}, {_points}, {_IsComplete}";
    }
}