namespace Backjoon.P1654;

public class HaeGong
{
    class Example
    {
        public void Run()
        {
            int[] KN = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            int K = KN[0];
            int N = KN[1];
        
            List<int> KList = new List<int>();

            for (int i = 0; i < K; i++)
            {
                KList.Add(int.Parse(Console.ReadLine()!));
            }

            long left = 1;
            long right = KList.Max();
            long result = 0;

            while (left <= right)
            {
                long mid = (left + right) / 2;
                long count = 0;

                foreach (long i in KList)
                {
                    count = count + i / mid;
                }

                if (count >= N)
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