using Gnode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnode.Core.Variables
{
    public class Variable<T> : IVariable<T>
    {
        public T Value { get; set; } = default!; // Suppress nullability warning by assigning default value
        public string Name { get; set; } = string.Empty;
        public Variable(T value)
        {
            Value = value;
        }

        public object GetValue() => Value;

        public void SetValue(object value)
        {
            if (value is T typedValue)
            {
                Value = typedValue;
            }
        }
    }

}
