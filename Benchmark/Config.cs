using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Validators;

namespace BenchmarkTeoVincent
{
    public class Config : ManualConfig
    {
        public Config()
        {
            Add(new Job("LegacyJit-Clr-X86", RunMode.Default, EnvMode.LegacyJitX86)
            {
                Env = { Runtime = Runtime.Clr }
            });
            
            //Add(new Job("LegacyJit-Clr-X64", RunMode.Default, EnvMode.LegacyJitX64)
            //{
            //    Env = { Runtime = Runtime.Clr }
            //});

            //Add(new Job("RyuJit-Clr-X86", RunMode.Default)
            //{
            //    Env = { Runtime = Runtime.Clr, Jit = Jit.RyuJit, Platform = Platform.X86 }
            //});

            //Add(new Job("RyuJit-Clr-X64", RunMode.Default)
            //{
            //    Env = { Runtime = Runtime.Clr, Jit = Jit.RyuJit, Platform = Platform.X64 }
            //});

            Add(ConsoleLogger.Default);
            Add(EnvironmentAnalyser.Default);
            Add(BaselineValidator.FailOnError, JitOptimizationsValidator.FailOnError, ExecutionValidator.FailOnError);
        }
    }
}
