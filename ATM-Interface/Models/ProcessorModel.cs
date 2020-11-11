using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ATMprocessor;

namespace ATM_Interface.Models
{
    static class ProcessorModel
    {
        private const int _updateTimeMillis = 500;
        private static Processor _processor;
        private static bool _processorIsRunning;
        private static Thread _updateThread;



        public static void Init()
        {
            _processor = new Processor();
            _processor.turnOnMachine();
            _processorIsRunning = true;
            _updateThread = new Thread(new ThreadStart(UpdateProcessor));
            _updateThread.Start();
        }

        public static void Stop()
        {
            _processorIsRunning = false;
            _updateThread.Join();
        }

        public static Processor Processor 
        { 
            get => _processor;
        }

        private static void UpdateProcessor()   // Updating proceesor in extra thread 
        {
            Console.WriteLine("Update thread started");
            while (_processorIsRunning)
            {
                _processor.updateMachine();
                Thread.Sleep(_updateTimeMillis);
            }
            Console.WriteLine("Update thread finished");
        }
    }
}
