namespace Backjoon.P1932
{
    /*
    n층에서 총 숫자의 개수는 n * (n+1) / 2,
    Depth가 1 ~ n이라고 하면, i번 인덱스의 대각선 아래는 i+depth, i+depth+1
    1. Depth: (1 ~ n-1)의 수들을 각 수의 대각선아래에 더함 (대각선 아래수와 더했을때의 최대값으로 저장)
    2. Depth: n 의 수들 중 최대값이 정답
    */
    public class Minseo
    {
            static void Main(string[] args)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                List<int> nums = new List<int>();

                for (int i = 0; i < n; i++)
                {
                    nums.AddRange(Console.ReadLine()!.Split(" ").Select(int.Parse));
                }

                int result = solve(n, nums);
                Console.WriteLine(result);
            }

            static int solve(int n, List<int> nums)
            {
                // 원본값 복사
                List<int> original = new List<int>();
                for (int i = 0; i < nums.Count; i++)
                {
                    original.Add(nums[i]);
                }

                int lasetDepthIndex = (n * (n + 1) / 2) - n;

                int depth = 1;
                int cnt = 0;
                for (int i = 0; i < lasetDepthIndex; i++)
                {
                    // 현재수를 좌, 우 대각선의 수에 더하면서 큰 경우에 갱신
                    nums[i + depth] = Math.Max(nums[i + depth], original[i + depth] + nums[i]);
                    nums[i + depth + 1] = Math.Max(nums[i + depth + 1], original[i + depth + 1] + nums[i]);

                    cnt++; // 현재 층에서 계산한 갯수
                    if (cnt == depth)
                    {
                        depth++;
                        cnt = 0;
                    }
                }

                int result = 0;

                for (int i = lasetDepthIndex; i < lasetDepthIndex + n; i++)
                {
                    result = Math.Max(result, nums[i]);
                }

                return result;
            }
    }
}