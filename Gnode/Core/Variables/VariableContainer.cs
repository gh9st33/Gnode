using Gnode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnode.Core.Variables
{
    public class VariableContainer
    {
        private Dictionary<string, IVariable<object>> _variables;

        public VariableContainer()
        {
            _variables = new Dictionary<string, IVariable<object>>();
        }

        public void AddVariable(string name, object value)
        {
            _variables[name] = new Variable<object>(name) { Value = value };
        }

        public IVariable<object> GetVariable(string name)
        {
            if (_variables.TryGetValue(name, out var variable))
            {
                return variable;
            }

            throw new KeyNotFoundException($"Variable with name {name} not found.");
        }

        public bool RemoveVariable(string name)
        {
            return _variables.Remove(name);
        }
    }

}
