using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentConnect.Infrastructure
{
    public class Province
    {
        public string Country { get; private set; }
        public string Abbreviation { get; private set; }
        public string Name { get; private set; }

        internal static IEnumerable<Province> GetProvinces()
        {
            return new List<Province>()
            {
                new Province () { Country = "CA", Abbreviation = "AB", Name = "Alberta" },
                new Province () { Country = "CA", Abbreviation = "BC", Name = "British Columbia" },
                new Province () { Country = "CA", Abbreviation = "MB", Name = "Manitoba" },
                new Province () { Country = "CA", Abbreviation = "NB", Name = "New Brunswick" },
                new Province () { Country = "CA", Abbreviation = "NL", Name = "Newfoundland and Labrador" },
                new Province () { Country = "CA", Abbreviation = "NT", Name = "Northwest Territories" },
                new Province () { Country = "CA", Abbreviation = "NS", Name = "Nova Scotia" },
                new Province () { Country = "CA", Abbreviation = "NU", Name = "Nunavut" },
                new Province () { Country = "CA", Abbreviation = "ON", Name = "Ontraio" },
                new Province () { Country = "CA", Abbreviation = "PE", Name = "Prince Edward Island" },
                new Province () { Country = "CA", Abbreviation = "QC", Name = "Quebec" },
                new Province () { Country = "CA", Abbreviation = "SK", Name = "Saskatchewan" },
                new Province () { Country = "CA", Abbreviation = "YK", Name = "Yukon" }
            }.AsEnumerable();
        }
    }
}