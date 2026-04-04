using System;
using System.Collections.Generic;

// Comment class
public class Comment
{
    public string author;
    public string text;
}

// Video class
public class Video
{
    public string title;
    public string author;
    public int length;

    public List<Comment> comments = new List<Comment>();

    public int GetCommentCount()
    {
        return comments.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("YouTube Videos Project\n");

        // Create videos
        Video v1 = new Video();
        v1.title = "Learn C# Basics";
        v1.author = "Hector";
        v1.length = 600;

        Video v2 = new Video();
        v2.title = "OOP Explained";
        v2.author = "CodeMaster";
        v2.length = 800;

        Video v3 = new Video();
        v3.title = "Data Structures";
        v3.author = "TechGuru";
        v3.length = 750;

        // Create comments for video 1
        Comment c1 = new Comment();
        c1.author = "Alice";
        c1.text = "Great video!";

        Comment c2 = new Comment();
        c2.author = "Bob";
        c2.text = "Very helpful.";

        Comment c3 = new Comment();
        c3.author = "Charlie";
        c3.text = "Thanks!";

        v1.comments.Add(c1);
        v1.comments.Add(c2);
        v1.comments.Add(c3);

        // Comments for video 2
        Comment c4 = new Comment();
        c4.author = "David";
        c4.text = "Now I understand OOP.";

        Comment c5 = new Comment();
        c5.author = "Eva";
        c5.text = "Nice explanation.";

        Comment c6 = new Comment();
        c6.author = "Frank";
        c6.text = "Awesome!";

        v2.comments.Add(c4);
        v2.comments.Add(c5);
        v2.comments.Add(c6);

        // Comments for video 3
        Comment c7 = new Comment();
        c7.author = "Grace";
        c7.text = "Good intro.";

        Comment c8 = new Comment();
        c8.author = "Hannah";
        c8.text = "Clear and simple.";

        Comment c9 = new Comment();
        c9.author = "Ian";
        c9.text = "Helped a lot!";

        v3.comments.Add(c7);
        v3.comments.Add(c8);
        v3.comments.Add(c9);

        // List of videos
        List<Video> videos = new List<Video>();
        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        // Display everything
        foreach (Video v in videos)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Title: " + v.title);
            Console.WriteLine("Author: " + v.author);
            Console.WriteLine("Length: " + v.length + " seconds");
            Console.WriteLine("Comments: " + v.GetCommentCount());

            Console.WriteLine("Comments list:");
            foreach (Comment c in v.comments)
            {
                Console.WriteLine(c.author + ": " + c.text);
            }
            Console.WriteLine();
        }
    }
}