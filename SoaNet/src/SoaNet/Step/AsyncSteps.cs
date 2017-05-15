using SoaNet.Step.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoaNet.Step
{
    public class AsyncSteps : Step
    {
        public IEnumerable<IStep> AsyncStepsList { get; private set; }
        public AsyncSteps(IEnumerable<IStep> asyncSteps)
        {
            AsyncStepsList = asyncSteps;
        }
        
        protected override void Execute()
        {
            Parallel.ForEach(AsyncStepsList, a => a.ExecuteStep());
        }
    }
}
