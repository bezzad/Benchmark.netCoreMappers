using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace ObjectsMapperBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = DefaultConfig.Instance.With(ConfigOptions.DisableOptimizationsValidator);
            var res = BenchmarkRunner.Run<BenchmarkContainer>(config);
            Console.ReadLine();
        }
    }
}
