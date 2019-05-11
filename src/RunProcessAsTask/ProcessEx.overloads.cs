﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace RunProcessAsTask
{
    // these overloads match the ones in Process.Start to make it a simpler transition for callers
    // see http://msdn.microsoft.com/en-us/library/system.diagnostics.process.start.aspx
    public partial class ProcessEx
    {
        public static Task<ProcessResults> RunAsync(string fileName)
            => RunAsync(new ProcessStartInfo(fileName));

        public static Task<ProcessResults> RunAsync(string fileName, string arguments)
            => RunAsync(new ProcessStartInfo(fileName, arguments));

        public static Task<ProcessResults> RunAsync(ProcessStartInfo processStartInfo)
            => RunAsync(processStartInfo, CancellationToken.None);

        public static Task<ProcessResults> RunAsync(ProcessStartInfo processStartInfo, CancellationToken cancellationToken) =>
            RunAsync(processStartInfo, s => { }, s => { }, cancellationToken);

        public static Task<ProcessResults> RunAsync(ProcessStartInfo processStartInfo,
            IObserver<string> onOutputObserver, IObserver<string> onErrorObserver, CancellationToken cancellationToken)
            => RunAsync(processStartInfo, onOutputObserver.OnNext, onErrorObserver.OnNext, cancellationToken);
    }
}
