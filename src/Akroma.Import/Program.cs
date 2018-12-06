using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Akroma.Persistence.SQL;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Import
{
    class Program
    {
        private static bool _loading;
        private static readonly ManualResetEvent ResetEvent = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            
            var timer = new System.Timers.Timer()
            {
                Interval = 20000
            };
            timer.Elapsed += async (sender, eventArgs) => await LoadBlocks();
            timer.Start();

            Console.WriteLine("Started Background");
            Console.ReadLine();
            Console.CancelKeyPress += (sender, eventArgs) => ResetEvent.Set();
            ResetEvent.WaitOne();
        }

        private static async Task LoadBlocks()
        {
            if (_loading)
            {
                return;
            }

            _loading = true;

            var contextFactory = new AkromaContextFactory();

            //using (var context = contextFactory.Create())
            //{
            //    await context.Database.MigrateAsync();
            //}

            var import = new ImportService(contextFactory);
            await import.Execute();

            _loading = false;
        }
    }
}
