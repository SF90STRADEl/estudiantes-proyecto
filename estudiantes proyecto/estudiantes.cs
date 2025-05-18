namespace StudentManagementSystem;

public class Student
{
    public string Name { get; set; }
    public string Matricula { get; set; }
    public float Average { get; set; }

    public Student(string name, string matricula, float average)
    {
        Name = name;
        Matricula = matricula;
        Average = average;
    }

    public override string ToString()
    {
        return $"Nombre: {Name}, Matrícula: {Matricula}, Promedio: {Average}";
    }
}