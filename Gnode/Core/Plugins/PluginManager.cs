using Gnode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnode.Core.Plugins
{
    public class PluginManager
    {
        public List<IPlugin> Plugins { get; private set; }

        public PluginManager()
        {
            Plugins = new List<IPlugin>();
        }

        public void LoadPlugins(string directory) { /* Implementation */ }
    }
}
