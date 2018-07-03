using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;

namespace PracticalPatterns.Concept.Tests
{
    [TestClass]
    public class LinqFixture
    {
        IDictionary<Type, IEnumerable<KeyValuePair<string, Type>>> registry =
            new Dictionary<Type, IEnumerable<KeyValuePair<string, Type>>>();

        [TestInitialize]
        public void Initialize()
        {
            registry.Add(
                typeof(DbProviderFactory),
                new KeyValuePair<string, Type>[]
                {
                    new KeyValuePair<string,Type>("sql",typeof(SqlClientFactory)),
                    new KeyValuePair<string,Type>("oledb",typeof(OleDbFactory)),
                    new KeyValuePair<string,Type>("odbc",typeof(OdbcFactory)),
                });
            registry.Add(
                typeof(ICollection<string>),
                new KeyValuePair<string, Type>[]
                {
                    new KeyValuePair<string,Type>("list",typeof(List<string>)),
                    new KeyValuePair<string,Type>("hashSet",typeof(HashSet<string>)),
                    new KeyValuePair<string,Type>("sortedSet",typeof(SortedSet<string>))
                });
        }

        const string TestName = "odbc";

        [TestMethod]
        public void NoLinq()
        {
            IEnumerable<KeyValuePair<string, Type>> dbFactories;

            if (!registry.TryGetValue(typeof(DbProviderFactory), out dbFactories))
            {
                return;
            }

            Type targetType = null;
            foreach (var item in dbFactories)
            {
                if (string.Equals(TestName,item.Key))
                {
                    targetType = item.Value;
                    break;
                }
            }

            Assert.IsNotNull(targetType);
            Assert.AreEqual<Type>(typeof(OdbcFactory), targetType);
        }

        [TestMethod]
        public void WithLinq()
        {
            Assert.AreEqual<Type>(
                registry.FirstOrDefault(x => x.Key == typeof(DbProviderFactory)).Value.FirstOrDefault(
                x => x.Key.Equals(TestName)).Value, typeof(OdbcFactory));
        }
    }
}
