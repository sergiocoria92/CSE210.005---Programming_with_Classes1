using System;

public class Cycling : Activity
{
    private double _speedKmPerHour;

    public Cycling(DateTime date, int durationMinutes, double speedKmPerHour)
        : base(date, durationMinutes)
    {
        _speedKmPerHour = speedKmPerHour;
    }

    public override double GetSpeed() => _speedKmPerHour;

    public override double GetDistance()
    {
        return (_speedKmPerHour * GetDuration()) / 60;
    }

    public override double GetPace()
    {
        return GetDuration() / GetDistance();
    }
}
