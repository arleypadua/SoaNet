using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Examples
{
    public class LazyParameterExample
    {
        public Process BuildExample()
        {
            Guid refGetCurrencyRate = Guid.Empty;
            Guid refSendEmail = Guid.Empty;

            ProcessBuilder builder = new ProcessBuilder();
            builder
                // Obtendo a cotação atual
                .Do("http://api.fixer.io/latest?base=USD&symbols=GBP,BRL",
                    out refGetCurrencyRate)

                // Calculando o total com a cotação atual
                .Do("http://soa-net.test/api/calculate-total/",
                    "POST",
                    () =>
                    {
                        var step1 = builder.GetStep(refGetCurrencyRate);
                        var currencyRate = step1.Result.Data;
                        
                        return new { usd_brl = Convert.ToDecimal(currencyRate.rates.BRL.ToString()) };
                    });
            
            return builder.Build();
        }
    }
}
