using System;
using System.Collections.Generic;
using System.IO;

// ===== BASE CLASS =====
public class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public virtual int RecordEvent()
    {
        return 0;
    }

    public virtual string GetStatus()
    {
        return "";
    }

    public virtual string Save()
    {
        return "";
    }
}

// ===== SIMPLE GOAL =====
public class SimpleGoal : Goal
{
    private bool _done;

    public SimpleGoal(string name, string desc, int points)
        : base(name, desc, points)
    {
        _done = false;
    }

    public override int RecordEvent()
    {
        if (!_done)
        {
            _done = true;
            return _points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return $"[{(_done ? "X" : " ")}] {_name}";
    }

    public override string Save()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_done}";
    }
}

// ===== ETERNAL GOAL =====
public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetStatus()
    {
        return $"[∞] {_name}";
    }

    public override string Save()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}

// ===== CHECKLIST GOAL =====
public class ChecklistGoal : Goal
{
    private int _count;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _count = 0;
    }

    public override int RecordEvent()
    {
        _count++;
        int total = _points;

        if (_count == _target)
        {
            total += _bonus;
        }

        return total;
    }

    public override string GetStatus()
    {
        return $"[ ] {_name} ({_count}/{_target})";
    }

    public override string Save()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_target}|{_bonus}|{_count}";
    }
}

// ===== MAIN PROGRAM =====
class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main()
    {
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save/Load");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");

            choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            if (choice == "2") ListGoals();
            if (choice == "3") RecordEvent();
            if (choice == "4") SaveLoad();
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("1. Simple\n2. Eternal\n3. Checklist");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            goals.Add(new SimpleGoal(name, desc, points));

        if (type == "2")
            goals.Add(new EternalGoal(name, desc, points));

        if (type == "3")
        {
            Console.Write("Target: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    static void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Choose goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = goals[index].RecordEvent();
        score += earned;

        Console.WriteLine($"+{earned} points!");
    }

    static void SaveLoad()
    {
        Console.WriteLine("1. Save\n2. Load");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            File.WriteAllText("goals.txt", score + "\n");

            foreach (Goal g in goals)
            {
                File.AppendAllText("goals.txt", g.Save() + "\n");
            }

            Console.WriteLine("Saved!");
        }

        if (choice == "2")
        {
            string[] lines = File.ReadAllLines("goals.txt");

            goals.Clear();
            score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] p = lines[i].Split('|');

                if (p[0] == "Simple")
                    goals.Add(new SimpleGoal(p[1], p[2], int.Parse(p[3])));

                if (p[0] == "Eternal")
                    goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));

                if (p[0] == "Checklist")
                    goals.Add(new ChecklistGoal(p[1], p[2], int.Parse(p[3]),
                                               int.Parse(p[4]), int.Parse(p[5])));
            }

            Console.WriteLine("Loaded!");
        }
    }
}