using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public static class SearchAlgorithms
    {
        public static Student BinarySearch(List<Student> students, string target)
        {
            int left = 0;
            int right = students.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(students[mid].Matricula, target);
                if (comparison == 0) return students[mid];
                if (comparison < 0) left = mid + 1;
                else right = mid - 1;
            }
            return null;
        }

        public static Student SequentialSearch(List<Student> students, string name)
        {
            foreach (var student in students)
                if (student.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) return student;
            return null;
        }
    }
}
