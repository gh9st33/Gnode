using Gnode.Core.Execution;
using Gnode.Core.Variables;
using Gnode.Interfaces;
using System;

namespace Gnode.Nodes
{
    public class SumNode : Node
    {
        private Port<float> _input1;
        private Port<float> _input2;
        private Port<float> _output;

        public SumNode()
        {
            _input1 = new Port<float>("input1", this);
            _input2 = new Port<float>("input2", this);
            _output = new Port<float>("output", this);

            AddInputPort(_input1);
            AddInputPort(_input2);
            AddOutputPort(_output);
        }

        public override void Execute()
        {
            float sum = _input1.GetData<float>() + _input2.GetData<float>();
            _output.Data.Value = sum;
        }
    }
}