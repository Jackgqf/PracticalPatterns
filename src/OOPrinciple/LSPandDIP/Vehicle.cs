using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.OOPrinciple.LSPandDIP
{
    interface IVehicle
    {
        void Run();
    }

    class Bicycle : IVehicle
    {
        public void Run()
        {
            //Run like a bicycle
        }
    }

    class Train : IVehicle
    {
        public void Run()
        {
            //Run like a train
        }
    }

    class Client
    {
        public void ShowAVehicleRun(IVehicle vehicle)
        {
            vehicle.Run();
        }
    }
}
