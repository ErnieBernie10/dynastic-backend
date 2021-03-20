using System;

namespace Dynastic.Architecture.Models
{
    public class UserDynasties
    {
        public string Id { get; set; }
        public Guid DynastyId { get; set; }
        public Dynasty Dynasty { get; set; }
    }
}