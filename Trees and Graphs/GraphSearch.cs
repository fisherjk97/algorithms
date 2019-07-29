using System;
using System.Collections;
using System.Collections.Generic;


//example used from https://www.koderdojo.com/blog/depth-first-search-algorithm-in-csharp-and-net-core
namespace Algorithms.Graphs
{
  
        //pseudocode

        public class Graph<T> {
            public Graph() {}
            public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T,T>> edges) {
                foreach(var vertex in vertices)
                    AddVertex(vertex);

                foreach(var edge in edges)
                    AddEdge(edge);
            }

            public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

            public void AddVertex(T vertex) {
                AdjacencyList[vertex] = new HashSet<T>();
            }

            public void AddEdge(Tuple<T,T> edge) {
                if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2)) {
                    AdjacencyList[edge.Item1].Add(edge.Item2);
                    AdjacencyList[edge.Item2].Add(edge.Item1);
                }
            }
        }

        public class Algorithms {
        public HashSet<T> DFS<T>(Graph<T> graph, T start) {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;
                
            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0) {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach(var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }

 
        public HashSet<T> BFS<T>(Graph<T> graph, T start) {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;
                
            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0) {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach(var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }

        public Func<T, IEnumerable<T>> ShortestPathFunction<T>(Graph<T> graph, T start) {
            var previous = new Dictionary<T, T>();
                
            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0) {
                var vertex = queue.Dequeue();
                foreach(var neighbor in graph.AdjacencyList[vertex]) {
                    if (previous.ContainsKey(neighbor))
                        continue;
                    
                    previous[neighbor] = vertex;
                    queue.Enqueue(neighbor);
                }
            }

            Func<T, IEnumerable<T>> shortestPath = v => {
                var path = new List<T>{};

                var current = v;
                while (!current.Equals(start)) {
                    path.Add(current);
                    current = previous[current];
                };

                path.Add(start);
                path.Reverse();

                return path;
            };

            return shortestPath;
        }
    }
    

      public class GraphSearch
    {
        public static void Test(){

            var vertices = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);


            var vertices2 = new[] {1, 2, 3, 5, 7, 8};
            var edges2 = new[]{Tuple.Create(1,2), Tuple.Create(2,3),
                Tuple.Create(5,7), Tuple.Create(5,2), Tuple.Create(7,8)};

            var graph2 = new Graph<int>(vertices2, edges2);

            var algorithms = new Algorithms();

            //Console.WriteLine("Depth First Search");
            //Console.WriteLine(string.Join(", ", algorithms.DFS(graph, 1)));
            Console.WriteLine("Depth First Search");
            Console.WriteLine(string.Join(", ", algorithms.DFS(graph2, 5)));
            //# 1, 3, 6, 5, 8, 9, 10, 7, 4, 2
            Console.WriteLine("Breadth First Search");
            //Console.WriteLine(string.Join(", ", algorithms.BFS(graph, 1)));
            Console.WriteLine(string.Join(", ", algorithms.BFS(graph2, 5)));

            var startVertex = 1;
            var shortestPath = algorithms.ShortestPathFunction(graph, startVertex);
            foreach (var vertex in vertices)
                Console.WriteLine("shortest path to {0,2}: {1}",
                        vertex, string.Join(", ", shortestPath(vertex)));


            var startVertex2 = 5;
            var shortestPath2 = algorithms.ShortestPathFunction(graph2, startVertex2);
            foreach (var vertex in vertices2)
                Console.WriteLine("shortest path to {0,2}: {1}",
                        vertex, string.Join(", ", shortestPath(vertex)));
        }

     
    }
}