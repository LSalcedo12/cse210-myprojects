using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
        Comments = new List<Comment>();
    }

    // Method that return the number of comments
    public int GetCommentCount()
    {
        return Comments.Count;
    }

    // Method that add comments for the list
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }
}