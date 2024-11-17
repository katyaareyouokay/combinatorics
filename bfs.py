from collections import deque
def bfs(graph, start):
    distances = {start: 0}          # Словарь для хранения расстояний от начальной вершины
    queue = deque([start])          # Очередь для обработки вершин, начиная с начальной
    
    while queue:                    # Пока очередь не пуста
        vertex = queue.popleft()    # Извлекаем вершину из начала очереди
        
        for neighbor in graph[vertex]:           # Проходим по всем соседям вершины
            if neighbor not in distances:        # Если сосед еще не посещен
                distances[neighbor] = distances[vertex] + 1  # Устанавливаем расстояние
                queue.append(neighbor)           # Добавляем соседа в очередь

    return distances
# Граф
graph = {
    'A': ['B', 'C'],
    'B': ['E', 'C', 'D'],
    'C': ['F', 'G', 'B'],
    'D': [],
    'E': [],
    'F': ['H', 'G'],
    'G':['F'],
    'H':[],
}
# Запускаем BFS начиная с вершины 'A' и получаем расстояния
distances = bfs(graph, 'A')
print("Расстояния от вершины 'A':")
for vertex, distance in distances.items():
    print(f"До {vertex}: {distance}")
