using System.Collections.Generic;

namespace BFS
{
    internal class Graph
    {
        public List<List<int>> graph;

        public Graph(int vertices)
        {
            // Инициализируем граф как список списков
            graph = new List<List<int>>();
            for (int i = 0; i < vertices; i++)
                graph.Add(new List<int>());
        }

        public void AddEdge(int v, int w)
        {
            graph[v].Add(w);
        }

        public (List<int>, int) BFS(int start, int goal)
        {
            bool[] visited = new bool[graph.Count];
            int[] distances = new int[graph.Count];

            // Инициализируем все расстояния значением -1 (недостижимость)
            for (int i = 0; i < graph.Count; i++)
                distances[i] = -1;

            Queue<(int, List<int>)> queue = new Queue<(int, List<int>)>();
            queue.Enqueue((start, new List<int> { start }));
            visited[start] = true;
            distances[start] = 0;

            while (queue.Count > 0)
            {
                var (node, path) = queue.Dequeue();

                // Если нашли целевую вершину, возвращаем путь и расстояние
                if (node == goal)
                    return (path, distances[goal]);

                foreach (int neighbor in graph[node])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        distances[neighbor] = distances[node] + 1; // Обновляем расстояние до соседа

                        var newPath = new List<int>(path) { neighbor };
                        queue.Enqueue((neighbor, newPath));
                    }
                }
            }

            // Если путь не найден, возвращаем null и -1 как расстояние
            return (null, -1);
        }
    }
}
