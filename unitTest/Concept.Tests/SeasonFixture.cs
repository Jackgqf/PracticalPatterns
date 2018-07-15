using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.Concept.Operator;
using System.Diagnostics;

namespace PracticalPatterns.Concept.Tests
{
    [TestClass]
    public class SeasonFixture
    {
        [TestMethod]
        public void TestSeasonIterator()
        {
            var season = new Season();

            Assert.AreEqual<string>(Season.seasons[0], season);
            Trace.WriteLine(season);

            season++;
            season++;

            Assert.AreEqual<string>(Season.seasons[2], season);
            Trace.WriteLine(season);
        }
    }
}
