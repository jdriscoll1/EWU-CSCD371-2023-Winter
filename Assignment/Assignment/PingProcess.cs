﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;

public record struct PingResult(int ExitCode, string? StdOutput);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {

        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult(process.ExitCode, stringBuilder?.ToString());
    }

    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return Task.Run(() => new PingResult(process.ExitCode, stringBuilder?.ToString()));

    }

    async public Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        cancellationToken.ThrowIfCancellationRequested(); 
        return await Task.Run(() =>
        {
            return new PingResult(process.ExitCode, stringBuilder?.ToString());

        }); 
      }
    async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default) {
        StringBuilder? str = null;

        object stringBuilderAppendLocker = new();

        ParallelQuery<Task<PingResult>>? all = hostNameOrAddresses.AsParallel().Select(async item =>
        {
            return await RunAsync(item, cancellationToken);

        });

        PingResult[] results = await Task.WhenAll(all);

        int total = all.Aggregate(0, (total, item) => total + item.Result.ExitCode);
        foreach (PingResult result in results) {
            lock (stringBuilderAppendLocker) {
                (str ??= new StringBuilder()).Append(result.StdOutput?.Trim() + Environment.NewLine);
            }
        }
        return new PingResult(total, str?.ToString().Trim());

    }

    async public Task<PingResult> RunAsync(params string[] hostNameOrAddresses)
    {
        StringBuilder? stringBuilder = null;
        ParallelQuery<Task<int>>? all = hostNameOrAddresses.AsParallel().Select(async item =>
        {
            StartInfo.Arguments = item;
            void updateStdOutput(string? line) =>
                (stringBuilder ??= new StringBuilder()).AppendLine(line);
            Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);

            Task<PingResult> task = Task.Run(() => new PingResult(process.ExitCode, stringBuilder?.ToString())); 

            await task.WaitAsync(default(CancellationToken));
            return task.Result.ExitCode;
        });

        await Task.WhenAll(all);

        int total = all.Aggregate(0, (total, item) => total + item.Result);
        return new(total, stringBuilder?.ToString());
    }

    public Task<PingResult> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token)
    {
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
        (stringBuilder ??= new StringBuilder()).AppendLine(line);



        TaskScheduler schedule = TaskScheduler.Current;
        return Task.Factory.StartNew<PingResult>(() => {
            Process process = RunProcessInternal(startInfo, updateStdOutput, progressError, token);
           // process.WaitForExit(); 
           // var result = process.StandardOutput.ReadToEndAsync(); 
            return new PingResult(process.ExitCode,stringBuilder?.ToString());

        }, token, TaskCreationOptions.LongRunning, schedule);
    }

    async public Task<PingResult> RunLongRunningAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        StringBuilder? stringBuilder = null;
        StartInfo.Arguments = hostNameOrAddress;
        void updateStdOutput(string? line) =>
              (stringBuilder ??= new StringBuilder()).AppendLine(line);

        return await RunLongRunningAsync(StartInfo, updateStdOutput, default, cancellationToken); 

    }

    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }

            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}