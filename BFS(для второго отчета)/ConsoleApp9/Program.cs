using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vertices = 9;
            Graph g = new Graph(vertices);

            // Задаем граф вручную через список смежности
            g.graph[0].AddRange(new List<int> { 1, 2 });
            g.graph[1].AddRange(new List<int> { 0, 2, 3, 4 });
            g.graph[2].AddRange(new List<int> { 0, 1, 5, 6 });
            g.graph[3].AddRange(new List<int> { 1, 8 });
            g.graph[4].AddRange(new List<int> { 1, 8 });
            g.graph[5].AddRange(new List<int> { 2, 6 });
            g.graph[6].AddRange(new List<int> { 2, 5, 7 });
            g.graph[7].AddRange(new List<int> { 6, 8 });
            g.graph[8].AddRange(new List<int> { 3, 4, 7 });

            int start = 0, goal = 7;
            var result = g.BFS(start, goal);

            if (result.Item1 != null)
            {
                Console.WriteLine("The shortest path " + string.Join(" -> ", result.Item1));
                Console.WriteLine("Distance: " + result.Item2 + " steps");
            }
            else
            {
                Console.WriteLine("The path was not found");
            }
            Console.ReadKey();
        }
    }
}
