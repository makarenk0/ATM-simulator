using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ATMprocessor;

namespace ATM_Interface.Models
{
    static class ProcessorModel
    {
        private static Processor _processor;
        
        public static void Init()
        {
            _processor = new Processor();
            _processor.turnOnMachine();
              
        }

        public static Processor Processor { 
            get => _processor;
        }
    }
}
