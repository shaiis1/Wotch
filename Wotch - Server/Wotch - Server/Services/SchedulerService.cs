using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Wotch___Server.Services
{
    public sealed class SchedulerService : IHostedService
    {
        private Timer _t;

        private static int MilliSecondsToStartProcess()
        {
            return 30000; //30 seconds
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // set up a timer to be non-reentrant
            _t = new Timer(async _ => await OnTimerFiredAsync(cancellationToken),
                null, MilliSecondsToStartProcess(), Timeout.Infinite);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _t?.Dispose();
            return Task.CompletedTask;
        }

        private async Task OnTimerFiredAsync(CancellationToken cancellationToken)
        {
            try
            {
                // do your work here
                await DataProcessBL.DataProcessBL.SendProcessData();
                Debug.WriteLine("Simulating heavy I/O bound work");
                await Task.Delay(2000, cancellationToken);
            }
            finally
            {
                // set timer to fire off again
                _t?.Change(MilliSecondsToStartProcess(), Timeout.Infinite);
            }
        }
    }
}
