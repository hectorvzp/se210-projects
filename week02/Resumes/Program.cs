using System;

class Program
{
    static void Main(string[] args)
    {

        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2015;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._company = "Google";
        job2._jobTitle = "Senior Software Engineer";
        job2._startYear = 2020;
        job2._endYear = 2024;

        resume myResume = new resume();
        myResume._name = "Hector Zambrano";
        myResume._jobs = new List<Job>();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
    }
}