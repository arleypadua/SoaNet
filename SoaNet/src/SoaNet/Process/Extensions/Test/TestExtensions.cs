using SoaNet.Step;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Process.Extensions.Test
{
    public static class TestExtensions
    {
        /// <summary>
        /// Forces every step of the process to use test options
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ProcessBuilder ForceUseTestOptions(this ProcessBuilder builder)
        {
            builder.StepOptions = StepOptions.Test;
            return builder;
        }
    }
}
