namespace Backjoon.P11404;

public class Kyohyeong
{
	class Example
	{
		private const int INF = (int)1e9; // int.MaxValue 를 쓰면 플로이드 워셧 덧셈 시 int 범위를 초과하여 원하는 값이 나오지 않는다.
		
		public static void Run()
		{
			int n = int.Parse(Console.ReadLine()!); // 노드 개수
			int m = int.Parse(Console.ReadLine()!); // 간선 개수

			// 2차원 배열 초기화
			int[,] graph = new int[n + 1, n + 1];

			for (int a = 1; a <= n; a++)
			{
				for (int b = 1; b <= n; b++)
				{
					if (a == b) graph[a, b] = 0;
					else graph[a, b] = INF;
				}
			}

			// 간선 정보 입력
			for (int i = 0; i < m; i++)
			{
				var input = Console.ReadLine()!.Split();
				int a = int.Parse(input[0]);
				int b = int.Parse(input[1]);
				int c = int.Parse(input[2]);
				if (graph[a, b] > c) // 기존 노선의 비용과 비교
					graph[a, b] = c;
			}

			for (int i = 1; i <= n; i++)
			{
				for (int j = 1; j <= n; j++)
				{
					Console.Write($"{graph[i, j]} ");
				}
			
				Console.WriteLine();
			}


			// 플로이드 워셜 알고리즘 수행
			for (int k = 1; k <= n; k++)
			{
				for (int a = 1; a <= n; a++)
				{
					for (int b = 1; b <= n; b++)
					{
						if (graph[a, b] > graph[a, k] + graph[k, b])
						{
							graph[a, b] = graph[a, k] + graph[k, b]; // 여기에서 int 범위를 초과하는 값이 나오지 않도록 주의한다.
						}
					}
				}
			}

			// 결과 출력
			StringBuilder sb = new StringBuilder();
			for (int a = 1; a <= n; a++)
			{
				for (int b = 1; b <= n; b++)
				{
					if (graph[a, b] == INF)
						sb.Append("0 ");
					else
						sb.Append(graph[a, b] + " ");
				}
				sb.AppendLine();
			}
		
			Console.WriteLine(sb);
		}
	}
	
	class Program
	{
		static void Main(string[] args)
		{
			Example.Run();
		}
	}
}