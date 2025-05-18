namespace StudentManagementSystem;

using System.Collections.Generic;

public static class StudentOperations
{
    public static void AddStudent(List<Student> students, BST<string, Student> matriculaTree, BST<string, List<Student>> nameTree)
    {
        Console.Write("\nNombre: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("Matrícula: ");
        var matricula = Console.ReadLine() ?? "";
        Console.Write("Promedio: ");
        var average = float.Parse(Console.ReadLine() ?? "0");

        var student = new Student(name, matricula, average);
        students.Add(student);

        matriculaTree.Insert(matricula, student);
        nameTree.InsertOrUpdate(name, [student], list => { list.Add(student); return list; });
    }

    public static void QuickSortStudents(List<Student> list, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(list, low, high);
            QuickSortStudents(list, low, pi - 1);
            QuickSortStudents(list, pi + 1, high);
        }
    }

    private static int Partition(List<Student> list, int low, int high)
    {
        var pivot = list[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (string.Compare(list[j].Matricula, pivot.Matricula) < 0)
            {
                i++;
                Swap(list, i, j);
            }
        }
        Swap(list, i + 1, high);
        return i + 1;
    }

    private static void Swap(List<Student> list, int i, int j)
    {
        (list[j], list[i]) = (list[i], list[j]);
    }
}