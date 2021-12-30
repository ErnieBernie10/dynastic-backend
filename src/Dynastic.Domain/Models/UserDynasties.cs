using System;

namespace Dynastic.Domain.Models
{
    public class UserDynasties
    {
        public string Id { get; set; }
        public Guid DynastyId { get; set; }
        public Dynasty Dynasty { get; set; }
    }
}