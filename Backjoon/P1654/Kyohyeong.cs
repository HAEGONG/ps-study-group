namespace Backjoon.P1654;

public class Kyohyeong
{
	class Example
	{
		public static void Run()
		{
			// 입력 데이터 정리
			int[] input = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();
			int k = input[0];
			int n = input[1];
			
			int[] hArr = new int[n];
			for (int i = 0; i < k; i++)
			{
				hArr[i] = int.Parse(Console.ReadLine()!);
			}

			// 이분 탐색으로 가능한 랜선 길이의 최댓값 구하기
			long start = 1;
			long end = hArr.Max();
			long result = 0; // 결과값을 저장할 변수

			while (start <= end)
			{
				long total = 0; // 만들 수 있는 랜선의 길이
				long mid = (start + end) / 2;
				for (int i = 0; i < k; i++)
				{
					total += hArr[i] / mid;
				}

				if (total < n)
				{
					end = mid - 1;
				}
				else
				{
					result = mid;
					start = mid + 1;
				}
			}
			
			// 결과값 출력
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
