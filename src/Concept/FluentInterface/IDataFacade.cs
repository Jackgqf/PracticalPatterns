using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.FluentInterface
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public interface IDataFacade
    {
        IEnumerable<Currency> ExecuteQuery(Func<Currency, bool> filter);

        /// <summary>
        /// add new currency record
        /// </summary>
        /// <param name="code">currency code</param>
        /// <param name="name">currency name</param>
        /// <returns>fluent instance</returns>
        IDataFacade AddNewCurrency(string code, string name);
    }
}
