using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Wotch___Server.DataProcessBL
{
    public static class DataProcessBL
    {
        public static async Task SendProcessData()
        {
            do
            {
                var objList = new List<object>();
                for (int i = 0; i < DataProcessor.DataProcessor.MaxConcurrentCalls; i++)
                {
                    if (RequestQueue.queuList.Count > 0)
                    {
                        objList.Add(RequestQueue.queuList.Dequeue());
                    }
                }
                Console.WriteLine("items list count: {0}", objList.Count);

                var x = objList.Select(obj => Task.FromResult(runSendProcees(obj)));

                await Task.WhenAll(x);
            }
            while (RequestQueue.queuList.Count > 0);
        }

        private static Task<bool> runSendProcees(object obj)
        {
            DataProcessor.DataProcessor.ProcessData(obj);
            return Task.FromResult(true);
        }
    }
}
