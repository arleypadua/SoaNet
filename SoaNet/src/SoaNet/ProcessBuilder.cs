using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SoaNet.Step;

namespace SoaNet
{
    public class ProcessBuilder
    {
        public ProcessBuilder()
        {
            Steps = new List<IStepProtocol>();
        }

        public IList<IStepProtocol> Steps { get; set; }

        public IStepProtocol CreateStep(string url, string method, object data)
        {
            return new Step.Step(url, method, data);
        }

        public ProcessBuilder Do(string url)
        {
            var reference = Guid.Empty;
            return Do(url, out reference);
        }

        public ProcessBuilder Do(string url, out Guid reference)
        {
            return Do(url, "GET", null, out reference);
        }

        public ProcessBuilder Do(string url, string method, object data)
        {
            var reference = Guid.Empty;
            return Do(url, method, data, out reference);
        }

        public ProcessBuilder Do(string url, string method, object data, out Guid reference)
        {
            var step = new Step.Step(url, method, data);
            reference = step.Reference;

            Steps.Add(step);

            return this;
        }

        public ProcessBuilder Do(string url, string method, Func<object> lazyData)
        {
            var reference = Guid.Empty;
            return Do(url, method, lazyData, out reference);
        }

        public ProcessBuilder Do(string url, string method, Func<object> lazyData, out Guid reference)
        {
            var step = new LazyStep(url, method, lazyData);
            reference = step.Reference;

            Steps.Add(step);

            return this;
        }

        public ProcessBuilder If(Func<bool> expression, IStepProtocol truePart, IStepProtocol falsePart)
        {
            var reference = Guid.Empty;
            return If(expression, truePart, falsePart, out reference);
        }

        public ProcessBuilder If(Func<bool> expression, IStepProtocol truePart, IStepProtocol falsePart, out Guid reference)
        {
            var step = new IfStep(expression, truePart, falsePart);
            reference = step.Reference;

            Steps.Add(step);

            return this;
        }

        public IStepProtocol GetStep(Guid reference)
        {
            return Steps.FirstOrDefault(s => s.Reference == reference);
        }

        public Process Build()
        {
            return new Process(this);
        }
    }
}
