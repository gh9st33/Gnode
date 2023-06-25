using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Gnode.Core.Threading
{
    public class ThreadPool : IDisposable
    {
        private BlockingCollection<Action> _tasks = new BlockingCollection<Action>();
        private List<Thread> _workers;

        public ThreadPool(int workerCount)
        {
            _workers = new List<Thread>(workerCount);

            for (int i = 0; i < workerCount; i++)
            {
                var worker = new Thread(Work);
                worker.Start();
                _workers.Add(worker);
            }
        }

        public void EnqueueTask(Action task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            _tasks.Add(task);
        }

        private void Work()
        {
            while (_tasks.TryTake(out var task, Timeout.Infinite))
                task();
        }

        public void Dispose()
        {
            _tasks.CompleteAdding();

            foreach (var worker in _workers)
                worker.Join();

            _tasks.Dispose();
        }
    }
}
