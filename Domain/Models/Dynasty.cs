using System.Collections.Generic;
using System.Linq;
using Dynastic.Domain.Common;

namespace Dynastic.Domain.Models
{
    public class Dynasty : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Person> Members { get; set; }
    }
}