using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public static class SortAlgorithms
    {
        public static void QuickSort(List<Student> list, int low, int high)
        {
            if (low >= high) return;
            int pi = Partition(list, low, high);
            QuickSort(list, low, pi - 1);
            QuickSort(list, pi + 1, high);
        }

        private static int Partition(List<Student> list, int low, int high)
        {
            var pivot = list[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (string.Compare(list[j].Matricula, pivot.Matricula) >= 0) continue;
                i++;
                (list[i], list[j]) = (list[j], list[i]);
            }
            (list[i + 1], list[high]) = (list[high], list[i + 1]);
            return i + 1;
        }
    }
}
