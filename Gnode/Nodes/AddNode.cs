using Gnode.Core.Execution;
using Gnode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gnode.Nodes
{
    public class AddNode : Node
    {
        private Port<int> inputPort1;
        private Port<int> inputPort2;
        private Port<int> outputPort;

        public AddNode()
        {
            InitializePorts();
        }

        protected void InitializePorts()
        {
            this.AddInputPort(inputPort1);
            this.AddInputPort(inputPort2);
            this.AddOutputPort(outputPort);

        }

        public override void Execute()
        {
            int val1 = inputPort1.GetData<int>();
            int val2 = inputPort2.GetData<int>();
            int result = val1 + val2;

            outputPort.Data.Value = result;
        }
    }

}
