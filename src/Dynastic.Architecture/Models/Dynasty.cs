using System.Collections.Generic;

namespace Dynastic.Architecture.Models
{
    public class Dynasty : Base
    {
        public string Name { get; set; }
        public Person Head { get; set; }
        public List<Person> Members { get; set; }
    }
}