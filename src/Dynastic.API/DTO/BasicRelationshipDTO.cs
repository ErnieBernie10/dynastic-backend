using System;
using System.Collections.Generic;

namespace Dynastic.API.DTO
{
    public class BasicRelationshipDTO
    {
        public string Partner { get; set; }
        public List<string> Children { get; set; }
    }
}