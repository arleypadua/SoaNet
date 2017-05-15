using SoaNet.Process;
using SoaNet.Process.Extensions.Http;
using SoaNet.Process.Extensions.Test;
using SoaNet.Step;
using SoaNet.Step.Http;
using System;
using System.Linq;
using System.Net.Http;

namespace SoaNet.Examples
{
    public class AsyncStepsExample
    {
        public Process.Process BuildExample()
        {
            Guid asyncStepReference = Guid.Empty;

            ProcessBuilder builder = new ProcessBuilder();
            builder
                .ForceUseTestOptions()

                .AddAsyncSteps(
                    out asyncStepReference,
                    builder.CreateHttpStep("http://api.fixer.io/latest?base=USD&symbols=GBP", HttpMethod.Get, null, StepOptions.Test),
                    builder.CreateHttpStep("http://api.fixer.io/latest?base=USD&symbols=BRL", HttpMethod.Get, null, StepOptions.Test)
                )

                .AddStep("http://soa-net.test/api/compare-rates/",
                        HttpMethod.Post,
                        () =>
                        {
                            var asyncSteps = builder.GetStep(asyncStepReference) as AsyncSteps;

                            var gbp = asyncSteps.AsyncStepsList.ElementAt(0) as HttpStep;
                            var brl = asyncSteps.AsyncStepsList.ElementAt(1) as HttpStep;

                            return new
                            {
                                rate1 = Convert.ToDecimal(gbp.Result.Data.rates.GBP.ToString()),
                                rate2 = Convert.ToDecimal(brl.Result.Data.rates.BRL.ToString())
                            };
                        });

            return builder.Build();
        }
    }
}
