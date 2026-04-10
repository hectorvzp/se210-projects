using System;
// ================= BASE CLASS =================
public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration (seconds): ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        PauseWithAnimation(3);
    }

    public void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        PauseWithAnimation(2);
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        PauseWithAnimation(3);
    }

    protected void PauseWithAnimation(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}

// ================= BREATHING =================
public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
        "This activity will help you relax by guiding your breathing.")
    { }

    public void Run()
    {
        StartMessage();

        int time = 0;
        while (time < _duration)
        {
            Console.Write("Breathe in... ");
            Countdown(4);

            Console.Write("Breathe out... ");
            Countdown(4);

            time += 8;
        }

        EndMessage();
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// ================= REFLECTION =================
public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone.",
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful?",
        "Have you done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "How can you use this again in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
        "Reflect on times when you showed strength and resilience.")
    { }

    public void Run()
    {
        StartMessage();

        Random rand = new Random();

        Console.WriteLine("\nConsider this prompt:");
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);

        PauseWithAnimation(4);

        int time = 0;
        while (time < _duration)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine("\n" + question);

            PauseWithAnimation(4);
            time += 4;
        }

        EndMessage();
    }
}

// ================= LISTING =================
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "Who are your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity",
        "List as many positive things as you can.")
    { }

    public void Run()
    {
        StartMessage();

        Random rand = new Random();

        Console.WriteLine("\nPrompt:");
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);

        Console.WriteLine("\nYou may begin in:");
        Countdown(5);

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");

        EndMessage();
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// ================= MAIN PROGRAM =================
class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("\nChoose an option: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                new BreathingActivity().Run();
            }
            else if (choice == "2")
            {
                new ReflectionActivity().Run();
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
            }
        }

        Console.WriteLine("\nGoodbye!");
    }
}