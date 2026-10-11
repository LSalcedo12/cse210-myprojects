public abstract class Goal
{
    private string _shortName;
    private string _description;
    private string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName() => _shortName;
    public string GetDescription() => _description;
    public string GetPoints() => _points;

    // Use polymorphism
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}