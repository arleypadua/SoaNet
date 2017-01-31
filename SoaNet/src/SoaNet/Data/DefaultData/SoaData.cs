using SoaNet.Components.Model.Soa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Data.DefaultData
{
    public class SoaData
    {
        public class StepDefinitionDate
        {
            public static StepDefinition FirstQueuedStep = new StepDefinition { StepDefinitionName = "Process Queued" };
        }

        public class ProcessStepStatusData
        {
            public static ProcessStepStatus Queued = new ProcessStepStatus { ProcessStepStatusId = new Guid("8994e3bc-5a59-4ef4-b9bf-d026faf59ad4"), Status = "Queued" };
            public static ProcessStepStatus WaitingNotification = new ProcessStepStatus { ProcessStepStatusId = new Guid("8645c8d0-109c-4d72-b73a-38de6927c4ea"), Status = "Wating external Notification" };
            public static ProcessStepStatus Finished = new ProcessStepStatus { ProcessStepStatusId = new Guid("3d4a349f-82ec-4a56-a83b-59256d3f7b78"), Status = "Finished" };
            public static ProcessStepStatus ActionNeeded = new ProcessStepStatus { ProcessStepStatusId = new Guid("2f4ceb4e-c562-43a2-b629-2f888248cf4a"), Status = "Action needed" };
        }
    }
}
