using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnode.Interfaces
{
    public interface IVariable<T>
    {
        string Name { get; }
        T Value { get; set; }
        Type DataType { get; }
    }

}
