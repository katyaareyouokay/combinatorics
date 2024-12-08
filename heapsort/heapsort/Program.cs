using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heapsort
{
    using System;

    class Heapsort
    {
        public static void Sort(int[] array)
        {
            int n = array.Length;

            // Построение кучи
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            // Извлечение элементов из кучи
            for (int i = n - 1; i > 0; i--)
            {
                // Перемещение текущего корня в конец
                (array[0], array[i]) = (array[i], array[0]);

                // Восстановление свойств кучи
                Heapify(array, i, 0);
            }
        }

        private static void Heapify(int[] array, int n, int i)
        {
            int largest = i; // Инициализируем наибольший элемент как корень
            int left = 2 * i + 1; // Левый потомок
            int right = 2 * i + 2; // Правый потомок

            // Если левый потомок больше корня
            if (left < n && array[left] > array[largest])
                largest = left;

            // Если правый потомок больше текущего наибольшего
            if (right < n && array[right] > array[largest])
                largest = right;

            // Если наибольший элемент не корень
            if (largest != i)
            {
                (array[i], array[largest]) = (array[largest], array[i]);

                // Рекурсивно восстанавливаем свойства кучи
                Heapify(array, n, largest);
            }
        }

        public static void Main()
        {
            int[] array = { 4, 10, 3, 5, 1 };
            Console.WriteLine("Исходный массив: " + string.Join(", ", array));

            Sort(array);

            Console.WriteLine("Отсортированный массив: " + string.Join(", ", array));
            Console.ReadKey();
        }
    }

}
