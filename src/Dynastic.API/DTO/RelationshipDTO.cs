using System.Collections.Generic;

namespace Dynastic.API.DTO
{
    public class RelationshipDTO
    {
        public MemberDTO Partner { get; set; }
        public List<MemberDTO> Children { get; set; }
    }
}