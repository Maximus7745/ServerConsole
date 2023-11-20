using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    public static class Server
    {
        private static int count = 0;
        static ReaderWriterLock countLock = new ReaderWriterLock();
        public static int GetCount()
        {
            countLock.AcquireReaderLock(Timeout.InfiniteTimeSpan);
            try
            {
                return count;
            }
            finally
            {
                countLock.ReleaseReaderLock();
            }
        }
        public static void AddToCount(int value)
        {
            countLock.AcquireWriterLock(Timeout.InfiniteTimeSpan);
            try
            {
                count += value;
            }
            finally
            {
                countLock.ReleaseWriterLock();
            }
        }


    }
}
