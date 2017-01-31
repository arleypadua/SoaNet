using SoaNet.Components.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoaNet.Components.Services.Classes;
using SoaNet.Components.Services.StepStatusExecutors;

namespace SoaNet.Components.Services
{
    public class ServiceBus : IServiceBus
    {
        private IList<IStepStatusExecutor> _executors = new List<IStepStatusExecutor>
        {
            new QueuedStepStatusExecutor()
        };

        public InsertProcessResponse InsertProcess(InsertProcessParameter parameter)
        {
            // TODO: insert the code
            return new InsertProcessResponse { };
        }

        public void ProcessSteps()
        {
            foreach (var executor in _executors)
            {
                ProcessSteps(executor);
            }
        }

        public void ProcessSteps(IStepStatusExecutor executor)
        {
            var steps = executor.GetProcessSteps();
            foreach (var step in steps)
            {
                var result = executor.ExecuteStep(step);
            }
        }

        public void AddExecutor(IStepStatusExecutor executor)
        {
            var executorInList = _executors.FirstOrDefault(e => e.ThisStatus == executor.ThisStatus); ;
            if (executorInList != null)
                throw new InvalidOperationException("There is already an executor of this type in list.");

            _executors.Add(executor);
        }
    }
}
