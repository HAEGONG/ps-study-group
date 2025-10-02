namespace Backjoon.P2887;

public class kyohyeong
{
	class Example
	{
		private static (int x, int y, int z)[] _coodinates;
		private static List<(int a, int b, int cost)> _edges;
		private static int[] _parent;

		private static int FindParent(int i)
		{
			if (_parent[i] != i)
				_parent[i] = FindParent(_parent[i]);
		
			return _parent[i];
		}

		private static void UnionParent(int i, int j)
		{
			int a = FindParent(i);
			int b = FindParent(j);
		
			if (a > b)
				_parent[a] = b;
			else
				_parent[b] = a;
		}
	
		public static void Run()
		{
			// 입력 받기
			int n = int.Parse(Console.ReadLine()!);

			var coordinates = new (int x, int y, int z, int index)[n];
			for (int i = 0; i < n; i++)
			{
				int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
				coordinates[i] = (input[0], input[1], input[2], i);
			}

			// 부모 배열 초기화
			_parent = new int[n];
			for (int i = 0; i < n; i++) _parent[i] = i;

			_edges = new List<(int a, int b, int cost)>();

			// x 기준 정렬
			var sortedX = coordinates.OrderBy(c => c.x).ToArray();
			for (int i = 0; i < n - 1; i++)
			{
				int cost = Math.Abs(sortedX[i].x - sortedX[i + 1].x);
				_edges.Add((sortedX[i].index, sortedX[i + 1].index, cost));
			}

			// y 기준 정렬
			var sortedY = coordinates.OrderBy(c => c.y).ToArray();
			for (int i = 0; i < n - 1; i++)
			{
				int cost = Math.Abs(sortedY[i].y - sortedY[i + 1].y);
				_edges.Add((sortedY[i].index, sortedY[i + 1].index, cost));
			}

			// z 기준 정렬
			var sortedZ = coordinates.OrderBy(c => c.z).ToArray();
			for (int i = 0; i < n - 1; i++)
			{
				int cost = Math.Abs(sortedZ[i].z - sortedZ[i + 1].z);
				_edges.Add((sortedZ[i].index, sortedZ[i + 1].index, cost));
			}

			// 간선 정렬
			// 이 때 동일한 간선에 대해 2개 이상의 cost가 나올 수 있다.
			_edges.Sort((a, b) => a.cost.CompareTo(b.cost));

			// Kruskal 알고리즘
			// 동일한 간선에 대해 2번째 cost에 대해 알고리즘을 수행하더라도 안전하다
			// 부모 노드가 같으므로 조건문에서 걸러지기 때문이다
			int result = 0;
			foreach (var edge in _edges)
			{
				if (FindParent(edge.a) != FindParent(edge.b))
				{
					UnionParent(edge.a, edge.b);
					result += edge.cost;
				}
			}

			Console.WriteLine(result);
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