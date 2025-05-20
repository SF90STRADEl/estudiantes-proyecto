using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StudentManagementSystem
{
    public static class EfficiencyTests
    {
        public static void RunEfficiencyTests()
        {
            TestPerformance(1000);
            TestPerformance(10000);
        }

        private static void TestPerformance(int n)
        {
            var testData = GenerateTestData(n);
            var sw = new Stopwatch();

            sw.Start();
            var tempTree = new BST<string, Student>();
            foreach (var student in testData) tempTree.Insert(student.Matricula, student);
            sw.Stop();
            Console.WriteLine($"\nInserción BST ({n}): {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            SortAlgorithms.QuickSort(testData, 0, testData.Count - 1);
            sw.Stop();
            Console.WriteLine($"Ordenamiento ({n}): {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            SearchAlgorithms.BinarySearch(testData, testData[^1].Matricula);
            sw.Stop();
            Console.WriteLine($"Búsqueda Binaria: {sw.ElapsedTicks} ticks");

            sw.Restart();
            SearchAlgorithms.SequentialSearch(testData, testData[^1].Name);
            sw.Stop();
            Console.WriteLine($"Búsqueda Secuencial: {sw.ElapsedTicks} ticks");
        }

        private static List<Student> GenerateTestData(int n)
        {
            var random = new Random();
            var data = new List<Student>();
            for (int i = 0; i < n; i++)
                data.Add(new Student($"Estudiante{random.Next(1, 100)}", $"M{random.Next(100000, 999999)}", (float)random.NextDouble() * 10));
            return data;
        }
    }
}
