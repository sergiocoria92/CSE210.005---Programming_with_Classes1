using System;
using System.Threading;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;

    // ✅ Campo privado para la duración, NO se debe usar directamente en clases hijas
    private int _duration;

    // ✅ Constructor que inicializa nombre y descripción
    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // ✅ Propiedad pública para acceder a la duración desde clases hijas (solo lectura)
    public int Duration
    {
        get => _duration;
        protected set => _duration = value;
    }

    // ✅ Este método establece la duración y muestra la bienvenida
    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        // ✅ Guarda la duración en el campo privado (la propiedad Duration lo leerá)
        while (!int.TryParse(Console.ReadLine(), out int input) || input <= 0)
{
    Console.WriteLine("Please enter a valid positive number of seconds.");
    Console.Write("How long, in seconds, would you like for your session? ");
}

    Duration = input; // ✅ Asignamos usando la propiedad, que internamente actualiza _duration

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    // ✅ Usa la propiedad Duration en lugar de acceder al campo directamente
    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {Duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    // ✅ Métodos auxiliares para animaciones
    protected void ShowSpinner(int seconds, string message = "")
    {
        if (!string.IsNullOrEmpty(message))
        {
            Console.Write(message);
        }

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinnerChars = { "⣾", "⣽", "⣻", "⢿" };

        while (DateTime.Now < endTime)
        {
            foreach (var spinnerChar in spinnerChars)
            {
                Console.Write(spinnerChar);
                Thread.Sleep(250);
                Console.Write("\b \b");
                if (DateTime.Now >= endTime) break;
            }
        }
    }

    protected void ShowBreathingAnimation(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("♡");
            Thread.Sleep(100);
            Console.Write("\b \b");
            Console.Write("♥");
            Thread.Sleep(100);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Método abstracto para que las clases hijas lo implementen
    public abstract void Run();
}
