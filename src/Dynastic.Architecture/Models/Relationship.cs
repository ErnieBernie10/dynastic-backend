using System;

namespace Dynastic.Architecture.Models
{
    public class Relationship
    {
        public Person Person { get; set; }
        public Guid PersonId { get; set; }
        public Person Partner { get; set; }
        public Guid PartnerId { get; set; } 
    }
}