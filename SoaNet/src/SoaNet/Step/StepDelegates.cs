using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Step
{
    public delegate void OnStartStepDelegate(Guid reference);
    public delegate void OnSuccessStepDelegate(Guid reference, IStep thisStep);
    public delegate void OnFailStepDelegate(Guid reference, Exception exception);
    public delegate void OnFinishStepDelegate(Guid reference);
}
