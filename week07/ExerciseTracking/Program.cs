using System;
using System.Collections.Generic;

// ===== BASE CLASS =====
public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public string GetDate()
    {
        return _date.ToString("dd MMM yyyy");
    }

    // Métodos abstratos
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Método comum
    public virtual string GetSummary()
    {
        return $"{GetDate()} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance {GetDistance():0.0} km, " +
               $"Speed {GetSpeed():0.0} kph, " +
               $"Pace {GetPace():0.00} min per km";
    }
}

// ===== RUNNING =====
public class Running : Activity
{
    private double _distance; // km

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / _distance;
    }
}

// ===== CYCLING =====
public class Cycling : Activity
{
    private double _speed; // kph

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        return (_speed * GetMinutes()) / 60;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

// ===== SWIMMING =====
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0; // km
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

// ===== MAIN =====
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 5.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 20.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 30, 40));

        foreach (Activity act in activities)
        {
            Console.WriteLine(act.GetSummary());
        }
    }
}