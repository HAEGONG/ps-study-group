namespace Backjoon.P1920;

public class Kyohyeong
{
	class Example
	{
		public static void Run()
		{
			// 입력 데이터 정리
			int n = int.Parse(Console.ReadLine()!);
			int[] a = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

			int m = int.Parse(Console.ReadLine()!);
			int[] xArr = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

			// 배열 오름차순으로 정리
			Array.Sort(a);
			
			// 결과값 배열을 모두 0으로 초기화한다.
			int[] result = new int[m];

			// X라는 정수가 A 배열 안에 있는지 이분탐색으로 확인
			for (int i = 0; i < m; i++)
			{
				int left = 0; // 왼쪽 인덱스
				int right = n - 1; // 오른쪽 인덱스
				while (left <= right)
				{
					int mid = (left + right) / 2; // 기준값 인덱스

					if (xArr[i] == a[mid])
					{
						result[i] = 1;
						break;
					}
					
					if (xArr[i] < a[mid])
					{
						right = mid - 1;
					}
					else
					{
						left = mid + 1;
					}
				}
			}
			
			// 결과값 출력
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for (int j = 0; j < m; j++)
			{
				sb.AppendLine(result[j].ToString());
			}
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