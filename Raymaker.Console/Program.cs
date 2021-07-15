using BenchmarkDotNet.Running;

namespace Raymaker.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}