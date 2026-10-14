public class Swimming : Activity
{
    private double _laps;
    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance in miles = swimming laps * 50 / 1000 * 0.62
        // (0 in km if you prefered: _laps * 50 /1000)
        return (_laps * 50.0) / 1000 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}