using SoaNet.Components.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoaNet.Components.Model.Soa;
using SoaNet.Components.Services.Classes;
using SoaNet.Components.Model.Http;

namespace SoaNet.Components.Services.StepStatusExecutors
{
    public class QueuedStepStatusExecutor : IStepStatusExecutor
    {
        public ProcessStepStatus ThisStatus
        {
            get
            {
                return Data.DefaultData.SoaData.ProcessStepStatusData.Queued;
            }
        }

        public ExecuteStepResult ExecuteStep(ProcessStep step)
        {
            var stepDefinitionDatas = (List<StepDefinitionData>)null; // TODO: get data from repositories
            var stepDefinitionDataIds = stepDefinitionDatas.Select(s => s.DataDefinitionId);

            var processDatas = (IEnumerable<ProcessData>)null; // TODO: get data from repositories where id 
            processDatas = processDatas.Where(d => stepDefinitionDataIds.Contains(d.DataDefinitionId));

            var headerData = processDatas.Where(d => !d.DataDefinition.IsBodyData);
            var bodyData = processDatas.Where(d => d.DataDefinition.IsBodyData);

            if (bodyData.Count() > 1)
                throw new InvalidOperationException("A process step cannot have more than one body data.");

            var request = new HttpSoaRequest
            {
                Method = step.StepDefinition.StepMethod,
                RequestUrl = step.StepDefinition.StepUrl
            };

            request.HttpSoaRequestHeaders = headerData.Select(h =>
                new HttpSoaRequestHeader
                {
                    HttpSoaRequestId = request.HttpSoaRequestId,
                    Key = h.DataDefinition.DataDefinitionName,
                    Value = h.Value
                }).ToList();

            var body = bodyData.FirstOrDefault();
            if (body != null)
            {
                var value = body.Value;
                request.RequestBody = value;
            }

            var response = HttpProcessor.Request(request);

            return new ExecuteStepResult
            {
                ThisStep = step
            };
        }

        public IEnumerable<ProcessStep> GetProcessSteps()
        {
            // TODO: add code here
            return new List<ProcessStep>();
        }
    }
}
