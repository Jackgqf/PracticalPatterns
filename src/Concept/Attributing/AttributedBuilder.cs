using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.Attributing
{
    public interface IAttributeBuilder
    {
        IList<string> Log { get; }
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    public sealed class DirectorAttribute : Attribute, IComparable<DirectorAttribute>
    {
        public int Priority { get; set; }
        public string MethodName { get; set; }
        public DirectorAttribute(int priority, string methodName)
        {
            if (priority <0)
            {
                throw new ArgumentOutOfRangeException("priority");
            }
            if (string.IsNullOrEmpty(methodName))
            {
                throw new ArgumentNullException("methodName"); 
            }
            Priority = priority;
            MethodName = methodName;
        }
        public int CompareTo(DirectorAttribute attribute)
        {
            return attribute.Priority - this.Priority;
        }
    }

    public class Director
    {
        public void BuildUp(IAttributeBuilder builder)
        {
            ((DirectorAttribute[])
                builder.GetType().GetCustomAttributes(typeof(DirectorAttribute), false))
                .OrderByDescending(x => x.Priority).ToList<DirectorAttribute>()
                .ForEach(x => InvokeBuildPartMethod(builder, x));
        }

        void InvokeBuildPartMethod(IAttributeBuilder builder, DirectorAttribute attribute)
        {
            switch (attribute.MethodName)
            {
                case "BuildPartA": builder.BuildPartA(); break;
                case "BuildPartB": builder.BuildPartB(); break;
                case "BuildPartC": builder.BuildPartC(); break;
                default:
                    break;
            }
        }
    }
}
