public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Usamos el método público de la clase base para acceder al nombre del estudiante
        return $"{_title} by {GetStudentName()}";
    }
}
