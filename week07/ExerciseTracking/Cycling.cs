using System.Diagnostics;

public class Cycling : Activity
{
    private double _speed;
    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;
    public override double GetDistance()
    {
        // If we have speed, the distance will calculate: (speed * minutes) / 60
        return (_speed * GetMinutes()) / 60;
    }

    public override double GetPace()
    {
        // Pace = 60 / speed
        return 60 / _speed;
    }
}