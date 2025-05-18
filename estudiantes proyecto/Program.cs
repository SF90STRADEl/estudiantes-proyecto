namespace StudentManagementSystem;

using System.Collections.Generic;

public class Program
{
    private static readonly List<Student> students = [];
    private static readonly BST<string, Student> matriculaTree = new();
    private static readonly BST<string, List<Student>> nameTree = new();

    public static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n1. Agregar estudiante");
            Console.WriteLine("2. Ordenar por matrícula");
            Console.WriteLine("3. Buscar por matrícula");
            Console.WriteLine("4. Buscar por nombre");
            Console.WriteLine("5. Mostrar todos");
            Console.WriteLine("6. Pruebas de eficiencia");
            Console.WriteLine("7. Salir");
            Console.Write("Opción: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    StudentOperations.AddStudent(students, matriculaTree, nameTree);
                    break;
                case "2":
                    StudentOperations.QuickSortStudents(students, 0, students.Count - 1);
                    Console.WriteLine("\nEstudiantes ordenados.");
                    break;
                case "3":
                    SearchOperations.SearchByMatricula(matriculaTree);
                    break;
                case "4":
                    SearchOperations.SearchByName(nameTree);
                    break;
                case "5":
                    SearchOperations.DisplayStudents(students);
                    break;
                case "6":
                    EfficiencyTests.RunEfficiencyTests();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nOpción inválida.");
                    break;
            }
        }
    }
}