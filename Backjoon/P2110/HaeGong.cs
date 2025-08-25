namespace Backjoon.P2110;

public class HaeGong
{
    class Example
    {
        public void Run()
        {
            int[] NC = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int N = NC[0];
            int C = NC[1];

            List<int> homeList = new List<int>();

            for (int i = 0; i < N; i++)
            {
                homeList.Add(int.Parse(Console.ReadLine()!));
            }

            List<int> sortedList = homeList.OrderBy(x => x).ToList();

            int left = 1;
            int right = sortedList.Last() - sortedList.First();

            int result = 0;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                int lastRouterIndex = 0;
                int count = 1;

                for (int i = 1; i < N; i++)
                {
                    if (sortedList[i] - sortedList[lastRouterIndex] >= mid)
                    {
                        count++;
                        lastRouterIndex = i;
                    }
                }

                if (count >= C)
                {
                    result = Math.Max(result, mid);
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            Console.WriteLine(result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Example().Run();
        }
    }
}