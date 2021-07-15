using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Raymaker.BenchMarking
{
    public class DateParser
    {
        public int GetYearFromDatetime(string dateString)
        {
            var dateTime = DateTime.Parse(dateString);
            return dateTime.Year;
        }

        public int GetYearFromSplit(string dateString)
        {
            var parts = dateString.Split('-');
            return int.Parse(parts[0]);
        }

        public int GetYearFromSubstring(string dateString)
        {
            var idx = dateString.IndexOf('-');
            return int.Parse(dateString.Substring(0, idx));
        }

        public int GetYearFromSpan(ReadOnlySpan<char> dateString)
        {
            var idx = dateString.IndexOf('-');
            return int.Parse(dateString.Slice(0, idx));
        }

        public int GetYearFromSpanWithManualConversion(ReadOnlySpan<char> dateString)
        {
            var idx = dateString.IndexOf('-');
            var span = dateString.Slice(0, idx);

            var temp = 0;
            for (int i = 0; i < span.Length; i++)
            {
                temp = temp * 10 + (span[i] - '0');
            }

            return temp;
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchMarks
    {
        private const string DateString = "2021-07-15T05:41:00Z";
        private static readonly DateParser Parser = new DateParser();

        [Benchmark(Baseline = true)]
        public void GetYearFromDate()
        {
            Parser.GetYearFromDatetime(DateString);
        }

        [Benchmark]
        public void GetYearFromSplit()
        {
            Parser.GetYearFromSplit(DateString);
        }

        [Benchmark]
        public void GetYearFromSubstring()
        {
            Parser.GetYearFromSubstring(DateString);
        }

        [Benchmark]
        public void GetYearFromSpan()
        {
            Parser.GetYearFromSpan(DateString);
        }

        [Benchmark]
        public void GetYearFromSpanManualConversion()
        {
            Parser.GetYearFromSpanWithManualConversion(DateString);
        }
    }
}