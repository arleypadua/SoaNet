using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SoaNet.Step
{
    public class IfStep : IStepProtocol
    {
        public IfStep(Func<bool> expression, IStepProtocol truePart, IStepProtocol falsePart)
        {
            Reference = Guid.NewGuid();

            BoolExpression = expression;
            TruePart = truePart;
            FalsePart = falsePart;
        }

        public Guid Reference { get; private set; }
        
        public StepResult Result { get; private set; }
        public IStepProtocol TruePart { get; private set; }
        public IStepProtocol FalsePart { get; private set; }
        public Func<bool> BoolExpression { get; private set; }

        public void ExecuteStep()
        {
            if (BoolExpression())
            {
                TruePart.ExecuteStep();
                Result = TruePart.Result;
            }
            else
            {
                FalsePart.ExecuteStep();
                Result = FalsePart.Result;
            }

            return;
        }
    }
}
