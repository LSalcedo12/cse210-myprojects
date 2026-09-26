using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the video List
        List<Video> videos = new List<Video>();

        //Video 1
        Video video1 = new Video("Learn Math problems tips in 5 minutes.");
        video1.AddComment(new Comment("John", "Very good explanation!"));
        video1.AddComment(new Comment("Diana", "Excellent tips, I used them in my test today."));
        video1.AddComment(new Comment("Mary", "Give us more tips"));
        videos.Add(video1);

        //Video 2
        Video video2 = new Video("Learn about Abstraction.");
        video2.AddComment(new Comment("Karen", "I loved the examples!"));
        video2.AddComment(new Comment("Fer", "Thank you its so helpfull for me."));
        video2.AddComment(new Comment("Adrian", "Can you give us more examples?"));
        videos.Add(video2);

        //Video 3
        Video video3 = new Video("Principle og encapsulation.");
        video3.AddComment(new Comment("Catalina", "Thank you! I understood better with your video"));
        video3.AddComment(new Comment("Jesus", "It was very easy to understand."));
        video3.AddComment(new Comment("Javier", "I though it was hard to understand. tank you for sharing!"));
        videos.Add(video3);

        foreach(Video video in videos)
        {
            Console.WriteLine("==================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"LengthSeconds: {video.LengthSeconds}");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("==================");
            Console.WriteLine("Comments");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($" - {comment.Name}: \ "{comment.Text}\"");
            }
           
            Console.WriteLine("==================");
        }
    }
}