using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RunProcessAsTask
{
    public sealed class ProcessResults : IDisposable
    {
        public ProcessResults(Process process, DateTime processStartTime, IEnumerable<string> standardOutput, IEnumerable<string> standardError)
        {
            Process = process;
            ExitCode = process.ExitCode;
            RunTime = process.ExitTime - processStartTime;
            StandardOutput = standardOutput;
            StandardError = standardError;
        }

        public Process Process { get; }
        public int ExitCode { get; }
        public TimeSpan RunTime { get; }
        public IEnumerable<string> StandardOutput { get; }
        public IEnumerable<string> StandardError { get; }
        public void Dispose() { Process.Dispose(); }
    }
}
