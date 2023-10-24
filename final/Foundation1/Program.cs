// Program 1: Abstraction with YouTube Videos.
// This program simulates the management of YouTube videos and their comments using the Video and Comment classes as described. 
// In this code, I have created the Comment and Video classes with their respective properties and methods.
// The Program class demonstrates how to create a video, add comments to it, and display the video's details.


using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; private set; }
    public string CommentText { get; private set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int LengthInSeconds { get; private set; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine("Video Details:");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- Comment by {comment.CommenterName}: {comment.CommentText}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a sample video
        Video video = new Video(" Primroselighthouse ", " Timileyin Micheal", 300);

        // Add comments to the video
        Comment comment1 = new Comment("User1", "Great video!");
        Comment comment2 = new Comment("User2", "I enjoyed it.");
        video.AddComment(comment1);
        video.AddComment(comment2);

        // Display video details
        video.DisplayVideoDetails();
    }
}
