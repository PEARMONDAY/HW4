using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HW4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            stra dijk = new stra();
            dijk.dijkstraAlgo(graph, 0);
        }
    }
    public class stra
    {
        static int number = 9;
        int minDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;
            for (int v = 0; v < number; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }
            return min_index;
        }
        void printPaths(int[] dist, int n, int srcVert)
        {
            Console.Write("Vertex Distance from Source {0}\n", srcVert);
            for (int i = 0; i < number; i++)
            {
                Console.Write(i + " \t\t " + dist[i] + "\n");
            }
        }
        public void dijkstraAlgo(int[,] graph, int srcVert)
        {
            int[] dist = new int[number];
            bool[] sptSet = new bool[number];
            for (int i = 0; i < number; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }
            dist[srcVert] = 0;
            for (int count = 0; count < number - 1; count++)
            {
                int minDist = minDistance(dist, sptSet);
                sptSet[minDist] = true;
                for (int indx = 0; indx < number; indx++)
                {
                    if (!sptSet[indx] && graph[minDist, indx] != 0 && dist[minDist] != int.MaxValue && dist[minDist] + graph[minDist, indx] < dist[indx])
                    {
                        dist[indx] = dist[minDist] + graph[minDist, indx];
                    }
                }
            }
            printPaths(dist, number, srcVert);
        }
    }
}