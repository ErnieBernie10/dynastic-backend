using System;

namespace Dynastic.Architecture.Models
{
    public abstract class Base
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}