using System;


namespace Gnode.Core.Threading
{
    public class ThreadManager
    {
        private ThreadPool _threadPool;

        public ThreadManager(int workerCount)
        {
            _threadPool = new ThreadPool(workerCount);
        }

        public void EnqueueTask(Action task)
        {
            _threadPool.EnqueueTask(task);
        }

        public void Dispose()
        {
            _threadPool.Dispose();
        }
    }
}
