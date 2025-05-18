namespace StudentManagementSystem;

using System.Collections.Generic;
using System.Diagnostics;

public static class EfficiencyTests
{
    public static void RunEfficiencyTests()
    {
        TestPerformance(1000);
        TestPerformance(10000);
        TestPerformance(100_000);
    }

    private static void TestPerformance(int n)
    {
        var testData = GenerateTestData(n);
        var stopwatch = new Stopwatch();

        // Prueba de inserción
        var tempMatriculaTree = new BST<string, Student>();
        var tempNameTree = new BST<string, List<Student>>();

        stopwatch.Start();
        foreach (var student in testData)
        {
            tempMatriculaTree.Insert(student.Matricula, student);
            tempNameTree.InsertOrUpdate(student.Name, [student], list => { list.Add(student); return list; });
        }
        stopwatch.Stop();
        Console.WriteLine($"\nInserción de {n}: {stopwatch.ElapsedMilliseconds} ms");

        // Prueba de ordenamiento
        stopwatch.Restart();
        StudentOperations.QuickSortStudents(testData, 0, testData.Count - 1);
        stopwatch.Stop();
        Console.WriteLine($"Ordenamiento de {n}: {stopwatch.ElapsedMilliseconds} ms");

        // Prueba de búsqueda
        if (testData.Count > 0)
        {
            var targetMatricula = testData[testData.Count / 2].Matricula;
            stopwatch.Restart();
            tempMatriculaTree.Search(targetMatricula);
            stopwatch.Stop();
            Console.WriteLine($"Búsqueda por matrícula en {n}: {stopwatch.ElapsedTicks} ticks");

            var targetName = testData[testData.Count / 2].Name;
            stopwatch.Restart();
            tempNameTree.Search(targetName);
            stopwatch.Stop();
            Console.WriteLine($"Búsqueda por nombre en {n}: {stopwatch.ElapsedTicks} ticks");
        }
    }

    private static List<Student> GenerateTestData(int n)
    {
        var students = new List<Student>();
        var random = new Random();

        for (int i = 0; i < n; i++)
        {
            students.Add(new Student(
                name: $"Estudiante{random.Next(1, 100)}",
                matricula: $"M{random.Next(100000, 999999)}",
                average: (float)random.NextDouble() * 10
            ));
        }
        return students;
    }
}