namespace Backjoon.P2805;

public class Kyohyeong
{
	class Example
	{
		public static void Run()
		{
			// 입력 데이터 정리
			int[] input = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();
			int n = input[0];
			int m = input[1];
			
			int[] hArr = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();
			
			// 이분탐색으로 가능한 나무 높이의 최댓값 구하기
			int start = 0;
			int end = hArr.Max();
			int result = 0; // 결과값을 저장할 변수
			
			while (start <= end)
			{
				long total = 0; // 가져갈 수 있는 나무의 총 길이 (타입 주의!)
				int mid = (start + end) / 2;
				for (int i = 0; i < n; i++)
				{
					if (hArr[i] > mid)
						total += hArr[i] - mid;
				}

				if (total < m)
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