namespace Backjoon.P2470;

public class HaeGong
{
    class Example
    {
        private int N;
        private int[] n;
        public void Run()
        {
            N = int.Parse(Console.ReadLine()!);
            n = Console.ReadLine()!.Split().Select(int.Parse).OrderBy(i => i).ToArray();
        
            int currentMin = int.MaxValue;

            int leftIndex = 0;
            int rightIndex = N - 1;

            int result1 = 0;
            int result2 = 0;

            while (leftIndex < rightIndex)
            {
                int sum = n[leftIndex] + n[rightIndex];

                if (currentMin > Math.Abs(sum))
                {
                    currentMin = Math.Abs(sum);
                
                    result1 = n[leftIndex];
                    result2 = n[rightIndex];
                }

                if (sum > 0)
                {
                    rightIndex--;
                }
                else if (sum < 0)
                {
                    leftIndex++;
                }
                else
                {
                    break;
                }
            }
        
            Console.WriteLine($"{result1} {result2}");
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