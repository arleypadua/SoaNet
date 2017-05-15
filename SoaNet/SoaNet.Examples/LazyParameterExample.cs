using SoaNet.Process;
using SoaNet.Process.Extensions.Http;
using SoaNet.Process.Extensions.Test;
using System;
using System.Net.Http;

namespace SoaNet.Examples
{
    public class LazyParameterExample
    {
        public Process.Process BuildExample()
        {
            Guid refGetCurrencyRate = Guid.Empty;

            ProcessBuilder builder = new ProcessBuilder();
            builder
                .ForceUseTestOptions()
                // Step 1 Getting USD rates
                .AddStep("http://api.fixer.io/latest?base=USD&symbols=GBP,BRL",
                    out refGetCurrencyRate)

                // Calling a api using the result of the first step
                .AddStep("http://soa-net.test/api/calculate-total/",
                    HttpMethod.Post,
                    () =>
                    {
                        var step1 = builder.GetDynamicStep(refGetCurrencyRate);
                        var currencyRate = step1.Result.Data;
                        
                        return new { usd_brl = Convert.ToDecimal(currencyRate.rates.BRL.ToString()) };
                    });
            
            return builder.Build();
        }
    }
}
