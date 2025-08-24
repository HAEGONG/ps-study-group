namespace Backjoon.P1920;

public class HaeGong
{
    class Example
    {
        public void Run()
        {
            int N = int.Parse(Console.ReadLine()!);
            List<int> n = Console.ReadLine()!.Split().Select(int.Parse).OrderBy(i => i).ToList();

            int M = int.Parse(Console.ReadLine()!);
            int[] m = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < M; i++)
            {
                int index = n.BinarySearch(m[i]);

                if (index < 0)
                {
                    sb.AppendLine("0");
                }
                else
                {
                    sb.AppendLine("1");
                }
            }
        
            Console.WriteLine(sb.ToString());
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