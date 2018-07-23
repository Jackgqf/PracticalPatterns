using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace PracticalPatterns.Builder.Attributed
{
    public class BuildStep
    {
        public MethodInfo Method { get; set; }
        public int Times { get; set; }
        public int Sequence { get; set; }
    }

    public class BuilderStepDiscovery
    {
        static IDictionary<Type, IEnumerable<BuildStep>> cache =
            new Dictionary<Type, IEnumerable<BuildStep>>();

        static IList<Type> errorCache = new List<Type>();

        public IEnumerable<BuildStep> DiscoveryBuildSteps(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (errorCache.Contains(type))
            {
                return null;
            }
            if (!cache.ContainsKey(type))
            {
                var aType = typeof(BuildStepAttribute);
                var methods = from item in
                                  (from method in type.GetMethods()
                                   where method.IsDefined(aType, false)
                                   select new
                                   {
                                       M = method,
                                       A = (BuildStepAttribute)method.GetCustomAttributes(aType, false).First()
                                   }
                                  )
                              orderby item.A.Sequence
                              select new BuildStep
                              {
                                  Method = item.M,
                                  Times = item.A.Times,
                                  Sequence = item.A.Sequence
                              };
                if (methods.Count() == 0)
                {
                    errorCache.Add(type);
                    return null;
                }
                else
                {
                    cache.Add(type, methods);
                    return methods;
                }
            }
            else
                return cache[type];
        }
    }

}
