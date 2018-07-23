using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Builder.Attributed
{
    public interface IBuilder<T> where T:class,new()
    {
        T BuildUp();
    }

    public class Builder<T> : IBuilder<T> where T : class,new()
    {
        public virtual T BuildUp()
        {
            var steps = new BuilderStepDiscovery().DiscoveryBuildSteps(typeof(T));
            if (steps == null)
            {
                return new T(); 
            }
            var target = new T();
            foreach (var step in steps)
            {
                for (var i = 0; i < step.Times; i++)
                {
                    step.Method.Invoke(target, null);
                }
            }
            return target;
        }
    }
}
