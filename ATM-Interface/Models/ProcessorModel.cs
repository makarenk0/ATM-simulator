using System;
using System.Collections.Generic;
using System.Text;
using ATMprocessor;

namespace ATM_Interface.Models
{
    class ProcessorModel
    {
        private Processor _processor;

        public ProcessorModel()
        {

        }


        public void Init()
        {
            _processor = new Processor();
            _processor.turnOnMachine();
        }

        //public Processor Processor { 
            //get => _processor; 
            //set => _processor = value; 
        //}
    }
}
