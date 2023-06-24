using System;
using System.Collections.Generic;

namespace Gnode.Core.Events
{
    public class SignalManager
    {
        private Dictionary<string, List<Action>> signalListeners = new Dictionary<string, List<Action>>();

        public void Register(string signal, Action listener)
        {
            if (!signalListeners.ContainsKey(signal))
            {
                signalListeners[signal] = new List<Action>();
            }
            signalListeners[signal].Add(listener);
        }

        public void Unregister(string signal, Action listener)
        {
            if (signalListeners.ContainsKey(signal))
            {
                signalListeners[signal].Remove(listener);
            }
        }

        public void Dispatch(string signal)
        {
            if (signalListeners.ContainsKey(signal))
            {
                foreach (Action listener in signalListeners[signal])
                {
                    listener.Invoke();
                }
            }
        }
    }
}
