using System;
using System.Collections.Generic;

namespace Dynastic.Models
{
    public class Person : Base
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public Person Mother { get; set; }
        public Guid MotherId { get; set; }
        public Person Father { get; set; }
        public Guid FatherId { get; set; }
        public List<Person> Children { get; set; }
    }
}