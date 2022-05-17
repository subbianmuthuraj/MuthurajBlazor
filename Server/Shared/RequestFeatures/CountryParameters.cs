using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDto.RequestFeatures
{
    public class CountryParameters : RequestParameters
    {
        public CountryParameters() => OrderBy = "CountryName";
        public string? SearchTerm { get; set; }

    }
}
