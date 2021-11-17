using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wotch___Server.DataProcessBL
{
    public static class RequestQueue
    {
        public static Queue<object> queuList = new Queue<object>();

        public static void AddToQueue(object obj)
        {
            queuList.Enqueue(obj);
        }
    }
}
