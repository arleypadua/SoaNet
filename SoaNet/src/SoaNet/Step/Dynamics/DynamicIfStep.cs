using SoaNet.Step.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SoaNet.Step.Dynamics
{
    /// <summary>
    /// A class that represents a conditional step
    /// </summary>
    public class DynamicIfStep : DynamicStep
    {
        public DynamicIfStep(Func<bool> expression, DynamicStep truePart, DynamicStep falsePart)
        {
            BoolExpression = expression;
            TruePart = truePart;
            FalsePart = falsePart;
        }
        
        public DynamicStep TruePart { get; private set; }
        public DynamicStep FalsePart { get; private set; }
        public Func<bool> BoolExpression { get; private set; }

        protected override void Execute()
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
        }
    }
}
