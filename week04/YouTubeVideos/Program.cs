using System;
using System.Collections.Generic;

public class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }
}


public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int DurationSeconds { get; set; }

    private List<Comment> comments = new List<Comment>();


    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }


    public int GetCommentCount()
    {
        return comments.Count;
    }

    public IReadOnlyList<Comment> GetComments()
    {
        return comments.AsReadOnly();
    }
}

class Program
{
    static void Main(string[] args)
    {

        List<Video> videos = new List<Video>();



        // Video 1
        Video video1 = new Video
        {
            Title = "Introducción a C#",
            Author = "Carlos Pérez",
            DurationSeconds = 600
        };
        video1.AddComment(new Comment("Ana", "Muy buen tutorial, gracias!"));
        video1.AddComment(new Comment("Luis", "Me ayudó mucho a entender clases."));
        video1.AddComment(new Comment("Marta", "¿Podrías hacer uno sobre herencia?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video
        {
            Title = "Tutorial de JavaScript",
            Author = "Laura Gómez",
            DurationSeconds = 720
        };
        video2.AddComment(new Comment("Pedro", "Excelente explicación."));
        video2.AddComment(new Comment("Juan", "¿Dónde puedo encontrar el código fuente?"));
        video2.AddComment(new Comment("Sofía", "¡Muy claro y sencillo!"));
        video2.AddComment(new Comment("Miguel", "Gracias por compartir."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video
        {
            Title = "Aprendiendo Python",
            Author = "Ricardo Martínez",
            DurationSeconds = 900
        };
        video3.AddComment(new Comment("Laura", "¿Qué versión de Python usas?"));
        video3.AddComment(new Comment("Daniel", "Me encanta esta serie."));
        video3.AddComment(new Comment("Andrea", "¡Muy útil para principiantes!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Título: {video.Title}");
            Console.WriteLine($"Autor: {video.Author}");
            Console.WriteLine($"Duración (segundos): {video.DurationSeconds}");
            Console.WriteLine($"Número de comentarios: {video.GetCommentCount()}");
            Console.WriteLine("Comentarios:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Author}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
