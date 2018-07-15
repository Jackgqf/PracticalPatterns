using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalPatterns.Concept.Operator
{
    public class Season
    {
        public static readonly string[] seasons =
            new string[] { "Spring", "Summer", "Autumn", "Winter" };
        int current;
        public Season()
        {
            current = default(int);
        }
        public static Season operator ++(Season season)
        {
            season.current = (season.current + 1) % 4;
            return season;
        }
        public override string ToString()
        {
            return seasons[current];
        }

        public static implicit operator string(Season season)
        {
            return season.ToString();
        }
    }
}
