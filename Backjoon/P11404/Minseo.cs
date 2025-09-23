using System.Text;

namespace Backjoon.P11404;

public class Minseo
{
    static int Min(int a, int b)
    {
        return a < b ? a : b;
    }
    
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // 도시(노드)의 수
        int m = int.Parse(Console.ReadLine()); // 버스(간선)의 수

        int INF = 100000 * (n - 1) + 1;
        
        int[,] adj = new int[n + 1, n + 1]; // 노선의 정보를 저장할 인접행렬
        
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                adj[i, j] = INF;
            }
        }

        // 노선의 정보입력
        for (int i = 0; i < m; i++)
        {
            var inputs =  Console.ReadLine().Split(' ');

            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            int cost = int.Parse(inputs[2]);

            adj[a, b] = Min(cost, adj[a, b]); // 노선의 비용이 작은경우에만 저장(시작 도시와 도착 도시를 연결하는 노선은 하나가 아닐 수 있다.)
            adj[a, a] = 0; // A도시에서 A로 가는경우 비용을 0으로 설정
        }
        
        // 플로이드 마샬 실행 (k: 거쳐가는 노드, i: 출발노드, j: 도착노드)
        for (int k = 1; k <= n; k++)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    adj[i, j] = Min(adj[i, j], adj[i, k] + adj[k, j]); // 경로 (i > j)와 (i > k > j)의 비용중 작은비용으로 갱신
                }
            }
        }

        // 출력
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                int cost = (adj[i, j] != INF) ? adj[i, j] : 0;

                sb.Append($"{cost} ");
            }
            sb.Append('\n');
        }

        Console.WriteLine(sb.ToString());
    }
}