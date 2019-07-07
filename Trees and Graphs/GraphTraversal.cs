using System;

namespace Algorithms.Graphs
{

    //examples from https://www.geeksforgeeks.org/dijkstras-shortest-path-algorithm-greedy-algo-7/
    public class GraphTraversal
    {



    //Prim's minimum spanning tree algorithm
    public static void PrimMST(int[,] graph, int v){
        //array to store the MST

        int[] parent = new int[v];

        //key values used to pick minimum edge in cut

        int[] key = new int[v];

        //to represent the set of vertices not yet included in the MST

        bool[] mstSet = new bool[v];

        //initialize all keys as infinite

        for (int i = 0; i < v; i++){
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }

        /*always include first vertext in MST
        make key 0 so that this vertix is picked first
        first node is always the root node of MST */
        key[0] = 0;
        parent[0] = -1;

        //the MST will have v vertices
        for(int i = 0; i < v - 1; i++){
            //pick the mimimum key vertiex from the set of vertices not yet includeed in the MST

            int u = MinKey(key, mstSet, v);

            /*update key value and parent index of the adjacent vertices of the picked index.
            Consider only those vetices that are not yet included in MST */
            for(int j = 0; j < v; j++){
                /*
                graph[u][v] is non-zero only for adjacent vertices of m
                mstSet[v] is false for vertices not yet included in MST
                Update the key only if graph[u][j] is smaller than key[j]
                 */

                 if(graph[u,j] != 0 && mstSet[j] == false && graph[u, j] < key[j]){
                     parent[j] = u;
                     key[j] = graph[u, j];
                 }
            }
        }
        PrintMST(parent, graph, v);

    }

    //utility function to help find the vertex with the minimum key value, from the set of vertices not yet included in MST
    private static int MinKey(int[] key, bool[] mstSet, int v){
        //initalize the min value
        int min = int.MaxValue; 
        int min_index = -1;

        for (int i = 0; i < v; i++){
            if(mstSet[i] == false && key[i] < min){
                min = key[i];
                min_index = i;
            }
            
        }

        return min_index;
    }




    /// <summary>
    /// Print minimum spanning tree
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="graph"></param>
    /// <param name="v"># of vertices</param>
    private static void PrintMST(int[] parent, int[, ] graph, int v)
    { 
        Console.WriteLine("Edge \tWeight"); 
        for (int i = 1; i < v; i++) {
        Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]); 
        }
    }


        //Kruskals algorithm

    

        /// <summary>
        ///  Dijkstra's shortest path algorithm
        /// </summary>
        /// <param name="graph">graph to find shortest path on</param>
        /// <param name="source">starting node</param>
        /// <param name="verticesCount"># of vertices in the graph</param>
        public static void Dijkstra(int[,] graph, int source, int verticesCount){
            int[] dist = new int[verticesCount];//initialize array with # of vertices

            bool[] shortestPathTreeSet = new bool[verticesCount];//initalize array with indicator of shortest path

            //Initialize all distances to be infinite and set shortest paths to false
            for(int i = 0; i < verticesCount; i++){
                dist[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            //the distance of the source vertex to itself is always 0
            dist[source] = 0;

            //find shortest path for all vertices
            for(int i = 0; i < verticesCount - 1; i++){
                //pick the minimum distance vertex from the set of vertices not yet processed. 
                //'u' is always equaol to the souce in first iteration
                int u = MinDistance(dist, shortestPathTreeSet, verticesCount);

                //mark the picked vertex as processed
                shortestPathTreeSet[u] = true;

                //update dist value of the adjacent vertices of the picked vertex
                for(int v = 0; v < verticesCount; v++){
                    /*
                    update dist[v] only if it is not in the shortest path set,
                    there is an edge from u to v, 
                    and the total weight of path from souce to v through u is smaller than the current value of dist[v] 
                    */

                    if(!shortestPathTreeSet[v] && graph[u,v] != 0  && dist[u] != int.MaxValue && dist[u] + graph[u,v] < dist[v]){
                        dist[v] = dist[u] + graph[u,v];
                    }

                    Print(dist, verticesCount);
                }
            }


        }


        /// <summary>
        /// Help determine min distance for dijkstra's algorithm
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="shortestPathTreeSet"></param>
        /// <param name="verticesCount"></param>
        /// <returns></returns>
        private static int MinDistance(int[] dist, bool[] shortestPathTreeSet, int verticesCount){
            //initalize min value
            int min = int.MaxValue;
            int min_index = -1;

            for(int v = 0; v < verticesCount; v++){
                if(shortestPathTreeSet[v] == false && dist[v] <= min){
                    min = dist[v];
                    min_index = v;
                }
            }
            return min_index;
        }

        // A utility function to print 
        // the constructed distance array 
        private static void Print(int[] dist, int verticesCount) 
        { 
            Console.Write("Vertex Distance from Source\n"); 
            for (int i = 0; i < verticesCount; i++) 
                Console.Write(i + " \t\t " +  dist[i] + "\n"); 
        }

    
    }
}