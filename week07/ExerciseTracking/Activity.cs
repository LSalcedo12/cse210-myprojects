public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public string GetDate() => _date;
    public int GetMinutes() => _minutes;

    public virtual double GetDistance() => 0.0;
    public virtual double GetSpeed() => 0.0;
    public virtual double GetPace() => 0.0;

    public virtual string GetSummary()
    {
        return $"{GetDate()} {GetType().Name} ({GetMinutes()} min): " +
        $"Distance {GetDistance():0.0} moles, " +
        $"Speed {GetSpeed():0.0} mph, " +
        $"Pace: {GetPace():0.0} min per mile";
    }
}