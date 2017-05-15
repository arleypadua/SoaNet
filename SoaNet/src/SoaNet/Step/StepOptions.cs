using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Step
{
    public class StepOptions
    {
        public static StepOptions Default = new StepOptions { StopProcessOnError = true };
        public static StepOptions Test = new StepOptions
        {
            StopProcessOnError = false,
            OnStart = reference => Console.WriteLine($"Step {reference} started: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}"),
            OnSuccess = (reference, step) => Console.WriteLine($"Step {reference} succeeded: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}"),
            OnFail = (reference, exception) => Console.WriteLine($"Step {reference} failed: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} with error: {exception.ToString()}"),
            OnFinish = (reference) => Console.WriteLine($"Step {reference} finished on {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}")
        };

        public bool StopProcessOnError { get; set; }

        public Action<Guid> OnStart { get; set; }
        public Action<Guid, IStep> OnSuccess { get; set; }
        public Action<Guid, Exception> OnFail { get; set; }
        public Action<Guid> OnFinish { get; set; }
    }
}
