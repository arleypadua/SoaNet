using SoaNet.Process;
using System;
using System.Collections.Generic;
using System.Text;
using SoaNet.Process.Extensions.Http;
using SoaNet.Step.Http;
using System.Net.Http;
using SoaNet.Step;
using SoaNet.Step.Dynamics;
using System.Linq.Expressions;

namespace SoaNet.Examples
{
    public class DbExample
    {
        public DbExample()
        {
            ProcessBuilder builder = new ProcessBuilder();

            dynamic processes = null;
            dynamic dbSteps = processes.Steps;
            //dynamic stepTypes = null;
            dynamic inputDataTypes = null;

            foreach (var dbStep in dbSteps)
            {
                if (dbStep.InputDataType == inputDataTypes.StepResult)
                {
                    var step = builder.GetDynamicStep((Guid)dbStep.InputDataStepReference);
                    var inputDataRaw = step.Result.Data;

                    BlockExpression blocExpression = Expression.Block(
                            new List<ParameterExpression>
                            {

                            },
                            Expression.
                        )
                }
            }
        }
    }
}
