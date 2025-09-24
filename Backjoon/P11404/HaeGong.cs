namespace Backjoon.P11404;

using System.Text;

class Example
{
    public void Run()
    {
        int n = int.Parse(Console.ReadLine()!);
        int m = int.Parse(Console.ReadLine()!);
        
        int[,] graph = new int[n + 1, n + 1];
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == j)
                {
                    graph[i, j] = 0;
                }
                else
                {
                    graph[i, j] = int.MaxValue / 2;
                }
            }
        }
        
        for (int i = 0; i < m; i++)
        {
            int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            graph[input[0], input[1]] = Math.Min(graph[input[0], input[1]], input[2]);
        }

        for (int k = 1; k <= n; k++)
        {
            for (int a = 1; a <= n; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    graph[a, b] = Math.Min(graph[a, b], graph[a, k] + graph[k, b]);
                }
            }
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (graph[i, j] == int.MaxValue / 2)
                {
                    sb.Append("0 ");
                }
                else
                {
                    sb.Append(graph[i, j] + ' ');
                }
            }
            sb.Append('\n');
        }
        
        Console.WriteLine(sb.ToString());
    }
}


class Program
{
    static void Main(string[] args)
    {
        new Example().Run();
    }
}