using System.Collections.Generic;

namespace Dynastic.API.DTO
{
    public class FlatTreeDTO
    {
        public FlatTreeDTO()
        {
            Members = new Dictionary<string, BasicMemberDTO>();
        }
        public Dictionary<string, BasicMemberDTO> Members { get; set; }
    }
}