using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Builder.Classic
{
    public class Vehicle
    {
        public IEnumerable<string> Wheels { get; set; }
        public IEnumerable<string> Lights { get; set; }
    }

    public abstract class VehicleBuilderBase
    {
        public Vehicle Vehicle { get; protected set; }
        public virtual void Create() { Vehicle = new Vehicle(); }
        public abstract void AddWheels();
        public abstract void AddLights();
    }

    public class CarBuilder : VehicleBuilderBase
    {
        public override void AddWheels()
        {
            Vehicle.Wheels = new string[] { "front", "front", "back", "back" };       
        }

        public override void AddLights()
        {
            Vehicle.Lights = new string[] { "front", "front", "back", "back" };
        }
    }

    public class BicycleBuilder : VehicleBuilderBase
    {
        public override void AddWheels()
        {
            Vehicle.Wheels = new string[] { "front", "back" };
        }
        public override void AddLights()
        {
            Vehicle.Lights = null;
        }
    }

    public class VehicleMaker
    {
        public VehicleBuilderBase Builder { get; set; }
        public Vehicle Vehicle { get { return Builder.Vehicle; } }

        public void Construct()
        {
            Builder.Create();
            Builder.AddWheels();
            Builder.AddLights();
        }
    }

}
