using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBite_Core.DTOs.AddOn
{
    public class CreateContainerWithAddOnDTO
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public List<CreateAddOn> AddOns { get; set; }
    }
}
