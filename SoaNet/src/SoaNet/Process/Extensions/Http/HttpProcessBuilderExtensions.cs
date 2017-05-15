using SoaNet.Step.Dynamics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using SoaNet.Step.Http;
using SoaNet.Step;

namespace SoaNet.Process.Extensions.Http
{
    public static class HttpProcessBuilderExtensions
    {
        public static DynamicStep GetDynamicStep(this ProcessBuilder builder, Guid reference)
        {
            return builder.Steps.OfType<DynamicStep>().FirstOrDefault(s => s.Reference == reference);
        }

        /// <summary>
        /// Creates a simple HTTP step
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpStep CreateHttpStep(this ProcessBuilder builder, string url, HttpMethod method, object data, StepOptions options = null)
        {
            options = options ?? StepOptions.Default;

            var step = new HttpStep(url, method, data);
            step.SetOptions(options);

            return step;
        }

        /// <summary>
        /// Creates a simple step
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HttpStep CreateHttpStep(this ProcessBuilder builder, string url)
        {
            var step = new HttpStep(url, HttpMethod.Get, new { });
            step.SetOptions(StepOptions.Default);

            return step;
        }

        /// <summary>
        /// Adds a step to the process that executes a simple GET request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static ProcessBuilder AddStep(this ProcessBuilder builder, string url)
        {
            var reference = Guid.Empty;
            return builder.AddStep(url, out reference);
        }

        /// <summary>
        /// Adds a step to the process that executes a simple GET request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="reference"></param>
        /// <returns>Returns a reference code to the step created</returns>
        public static ProcessBuilder AddStep(this ProcessBuilder builder, string url, out Guid reference)
        {
            return builder.AddStep(url, HttpMethod.Get, null, out reference);
        }

        /// <summary>
        /// Adds a step to the process that executes a request with the given method and data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ProcessBuilder AddStep(this ProcessBuilder builder, string url, HttpMethod method, object data)
        {
            var reference = Guid.Empty;
            return builder.AddStep(url, method, data, out reference);
        }

        /// <summary>
        /// Adds a step to the process that executes a request with the given method and data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <param name="reference"></param>
        /// <returns>Returns a reference code to the step created</returns>
        public static ProcessBuilder AddStep(this ProcessBuilder builder, string url, HttpMethod method, object data, out Guid reference, StepOptions options = null)
        {
            options = options ?? StepOptions.Default;

            var step = new HttpStep(url, method, data);
            step.SetOptions(options);

            reference = step.Reference;

            builder.Steps.Add(step);

            return builder;
        }

        /// <summary>
        /// Adds a step to the process that executes a request with a lazy loaded request data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="lazyData"></param>
        /// <returns></returns>
        public static ProcessBuilder AddStep(this ProcessBuilder builder, string url, HttpMethod method, Func<object> lazyData, StepOptions options = null)
        {
            var reference = Guid.Empty;
            return builder.AddStep(url, method, lazyData, out reference, options);
        }

        /// <summary>
        /// Adds a step to the process that executes a request with a lazy loaded request data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="lazyData"></param>
        /// <param name="reference"></param>
        /// <returns>Returns a reference code to the step created</returns>
        public static ProcessBuilder AddStep(this ProcessBuilder builder, string url, HttpMethod method, Func<object> lazyData, out Guid reference, StepOptions options)
        {
            options = options ?? StepOptions.Default;

            var step = new HttpLazyStep(url, method, lazyData);
            step.SetOptions(options);

            reference = step.Reference;

            builder.Steps.Add(step);

            return builder;
        }

        public static ProcessBuilder If(this ProcessBuilder builder, Func<bool> expression, DynamicIfStep truePart, DynamicIfStep falsePart)
        {
            var reference = Guid.Empty;
            return builder.If(expression, truePart, falsePart, out reference);
        }

        public static ProcessBuilder If(this ProcessBuilder builder, Func<bool> expression, DynamicIfStep truePart, DynamicIfStep falsePart, out Guid reference)
        {
            var step = new DynamicIfStep(expression, truePart, falsePart);
            reference = step.Reference;

            builder.Steps.Add(step);

            return builder;
        }
    }
}
