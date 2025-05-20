using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public class Program
    {
        private static readonly List<Student> students = new();
        private static readonly BST<string, Student> matriculaTree = new();
        private static readonly BST<string, List<Student>> nameTree = new();

        public static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n1. Agregar estudiante\n2. Ordenar\n3. Buscar por matrícula (BST)\n4. Buscar por nombre (BST)\n5. Buscar por matrícula (Binaria)\n6. Buscar por nombre (Secuencial)\n7. Pruebas\n8. Salir");
                Console.Write("Opción: ");
                switch (Console.ReadLine())
                {
                    case "1": AddStudent(); break;
                    case "2": SortAlgorithms.QuickSort(students, 0, students.Count - 1); break;
                    case "3": SearchByBSTMatricula(); break;
                    case "4": SearchByBSTName(); break;
                    case "5": SearchBinary(); break;
                    case "6": SearchSequential(); break;
                    case "7": EfficiencyTests.RunEfficiencyTests(); break;
                    case "8": exit = true; break;
                    default: Console.WriteLine("Opción inválida"); break;
                }
            }
        }

        private static void AddStudent()
        {
            Console.Write("\nNombre: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine() ?? "";
            Console.Write("Promedio: ");
            if (!float.TryParse(Console.ReadLine(), out float average)) average = 0;

            var student = new Student(name, matricula, average);
            students.Add(student);
            matriculaTree.Insert(matricula, student);
            nameTree.InsertOrUpdate(name, new List<Student> { student }, list => { list.Add(student); return list; });
        }

        private static void SearchByBSTMatricula()
        {
            Console.Write("\nMatrícula: ");
            string matricula = Console.ReadLine() ?? "";
            var result = matriculaTree.Search(matricula);
            Console.WriteLine(result != null ? result.ToString() : "No encontrado");
        }

        private static void SearchByBSTName()
        {
            Console.Write("\nNombre: ");
            string name = Console.ReadLine() ?? "";
            var result = nameTree.Search(name);
            if (result != null) DisplayStudents(result);
            else Console.WriteLine("No encontrados");
        }

        private static void SearchBinary()
        {
            Console.Write("\nMatrícula: ");
            string target = Console.ReadLine() ?? "";
            var result = SearchAlgorithms.BinarySearch(students, target);
            Console.WriteLine(result != null ? result.ToString() : "No encontrado");
        }

        private static void SearchSequential()
        {
            Console.Write("\nNombre: ");
            string name = Console.ReadLine() ?? "";
            var result = SearchAlgorithms.SequentialSearch(students, name);
            Console.WriteLine(result != null ? result.ToString() : "No encontrado");
        }

        private static void DisplayStudents(IEnumerable<Student> students)
        {
            Console.WriteLine();
            foreach (var student in students) Console.WriteLine(student);
        }
    }
}
