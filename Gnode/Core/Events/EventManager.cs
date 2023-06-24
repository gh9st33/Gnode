using System;
using System.Collections.Generic;

namespace Gnode.Core.Events
{
    public class EventManager
    {
        private Dictionary<Type, List<Delegate>> eventListeners = new Dictionary<Type, List<Delegate>>();

        public void Register<T>(Action<T> listener)
        {
            Type eventType = typeof(T);
            if (!eventListeners.ContainsKey(eventType))
            {
                eventListeners[eventType] = new List<Delegate>();
            }
            eventListeners[eventType].Add(listener);
        }

        public void Unregister<T>(Action<T> listener)
        {
            Type eventType = typeof(T);
            if (eventListeners.ContainsKey(eventType))
            {
                eventListeners[eventType].Remove(listener);
            }
        }

        public void Dispatch<T>(T eventToDispatch)
        {
            Type eventType = typeof(T);
            if (eventListeners.ContainsKey(eventType))
            {
                foreach (Delegate listener in eventListeners[eventType])
                {
                    listener.DynamicInvoke(eventToDispatch);
                }
            }
        }
    }
}
