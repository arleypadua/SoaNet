using SoaNet.Components.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoaNet.Components.Interfaces.Service
{
    public interface IServiceBus
    {
        InsertProcessResponse InsertProcess(InsertProcessParameter parameter);
        void ProcessSteps(IStepStatusExecutor executor);
        void ProcessSteps();
    }
}
