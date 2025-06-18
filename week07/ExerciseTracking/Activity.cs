using System;

public abstract class Activity
{
    private DateTime _date;
    private int _durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public DateTime GetDate() => _date;
    public int GetDuration() => _durationMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeed(); // km/h
    public abstract double GetPace();  // min/km

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {this.GetType().Name} ({_durationMinutes} min): Distancia {GetDistance():0.0} km, Velocidad: {GetSpeed():0.0} km/h, Ritmo: {GetPace():0.00} min por km";
    }
}
