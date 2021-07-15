using BenchmarkDotNet.Running;

namespace Raymaker.BenchMarking
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<Md5VsSha256>();

            // Run with dotnet
            // dotnet build -c Release
            // dotnet C:\src\github\Raymaker.BenchMarking\Raymaker.BenchMarking\bin\Release\net5.0\Raymaker.BenchMarking.dll
            BenchmarkRunner.Run<DateParserBenchMarks>();

            //var parser = new DateParser();
            //var res = parser.GetYearFromSpanWithManualConversion("2021-07-15T06:48:00Z");
        }
    }
}
