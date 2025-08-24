namespace Backjoon.P2805;

public class HaeGong
{
    class Example
    {
        public void Run()
        {
            int[] nm = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
            int n = nm[0];
            int m = nm[1];
        
            int[] trees = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
        
            int start = 0;
            int end = trees.Max();

            int result = 0;

            while (start < end)
            {
                int mid = start + (end - start) / 2;

                long sum = 0;
                foreach (int tree in trees)
                {
                    if (tree > mid)
                    {
                        sum = sum + (tree - mid);
                    }
                }

                if (sum >= m)
                {
                    result = Math.Max(result, mid);
                
                    start = mid + 1;
                }
                else
                {
                    end = mid;
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