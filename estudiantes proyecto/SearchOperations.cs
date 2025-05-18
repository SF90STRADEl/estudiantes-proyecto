namespace StudentManagementSystem;

using System.Collections.Generic;

public static class SearchOperations
{
    public static void SearchByMatricula(BST<string, Student> matriculaTree)
    {
        Console.Write("\nMatrícula: ");
        var matricula = Console.ReadLine() ?? "";
        var student = matriculaTree.Search(matricula);
        Console.WriteLine(student != null ? student.ToString() : "No encontrado.");
    }

    public static void SearchByName(BST<string, List<Student>> nameTree)
    {
        Console.Write("\nNombre: ");
        var name = Console.ReadLine() ?? "";
        var studentsFound = nameTree.Search(name);
        if (studentsFound != null) DisplayStudents(studentsFound);
        else Console.WriteLine("No encontrados.");
    }

    public static void DisplayStudents(IEnumerable<Student> students)
    {
        Console.WriteLine();
        foreach (var student in students)
            Console.WriteLine(student);
    }
}