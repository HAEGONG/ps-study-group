namespace Backjoon.P3665;

public class kyohyeong
{
	class Example
	{
		// 위상 정렬 수행하여 결과를 문자열로 반환
		// 정렬 결과 1개만 가능하면 정렬 순서대로 반환
		// 정렬 결과가 2개 이상 가능하다면 "?" 반환
		// 정렬이 불가능하면 (사이클 발생하면) "IMPOSSIBLE" 반환
		public static string TopologySort(int v, int[] indegree, List<int>[] graph)
		{
			List<int> result = new List<int>(); // 결과 저장
			Queue<int> q = new Queue<int>();   // 큐 초기화

			// 진입 차수가 0인 노드 삽입
			for (int i = 1; i <= v; i++)
			{
				if (indegree[i] == 0)
					q.Enqueue(i);
			}
			
			// 팀의 갯수만큼 반복
			for (int i = 0; i < v; i++)
			{
				// 팀 갯수만큼 반복하기 전에 큐가 빈 경우 (사이클 발생)
				if (q.Count == 0)
				{
					return "IMPOSSIBLE";
				}
				
				// 들어있는 큐의 갯수가 1개보다 많을 경우 2개 이상의 정렬 결과가 나올 수 있다.
				if (q.Count > 1)
				{
					return "?";
				}
				
				// 위상 정렬 수행
				int now = q.Dequeue();
				result.Add(now);

				// 해당 원소와 연결된 노드들의 진입차수 1 빼기
				foreach (int next in graph[now])
				{
					indegree[next]--;
					if (indegree[next] == 0)
						q.Enqueue(next);
				}
			}

			// 결과 출력
			return string.Join(" ", result);
		}
		
		public static void Run()
		{
			// 결과를 한번에 출력하기 위한 변수
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			// 테이스 케이스 갯수만큼 테스트 반복
			int t = int.Parse(Console.ReadLine()!);
			while (t-- > 0)
			{
				// 팀의 갯수 입력 받기
				int v = int.Parse(Console.ReadLine()!);
			
				// 진입 차수 배열 초기화
				int[] indegree = new int[v + 1];
			
				// 그래프 (인접 리스트) 초기화
				List<int>[] graph = new List<int>[v + 1];
				for (int i = 1; i <= v; i++)
				{
					graph[i] = new List<int>();
				}

				// 작년 팀의 순위를 받아서 그래프에 저장 및 진입차수 저장
				int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
				for (int i = 0; i < v - 1; i++)
				{
					for (int j = i + 1; j < v; j++)
					{
						graph[input[i]].Add(input[j]);
						indegree[input[j]]++;
					} }
			
				// 순위가 바뀐 팀의 쌍 갯수 입력 받기
				int m = int.Parse(Console.ReadLine()!);
				for (int i = 0; i < m; i++)
				{
					// 바뀐 순위 정보를 통해 그래프 수정 및 진입차수 수정
					int[] switchNums = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

					if (graph[switchNums[0]].Contains(switchNums[1]))
					{
						graph[switchNums[0]].Remove(switchNums[1]);
						indegree[switchNums[1]]--;
				
						graph[switchNums[1]].Add(switchNums[0]);
						indegree[switchNums[0]]++;
					}
					else if (graph[switchNums[1]].Contains(switchNums[0]))
					{
						graph[switchNums[1]].Remove(switchNums[0]);
						indegree[switchNums[0]]--;
				
						graph[switchNums[0]].Add(switchNums[1]);
						indegree[switchNums[1]]++;
					}
				}
				
				// 바뀐 순위 정보를 기준으로 위상 정렬 수행하여 문자열에 추가한다.
				sb.AppendLine(TopologySort(v, indegree, graph));
			}
			
			// 모든 테스트가 끝나면 결과를 한 번에 출력
			Console.WriteLine(sb.ToString());
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