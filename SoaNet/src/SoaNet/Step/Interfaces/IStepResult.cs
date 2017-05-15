using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Step.Interfaces
{
    public interface IStepResult<TResult>
    {
        TResult Data { get; }
    }
}
