using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDto.RequestFeatures
{
    public class GeneralParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }
    }
}
