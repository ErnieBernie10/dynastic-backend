using System.Collections.Generic;

namespace Dynastic.API.DTO
{
    public class BasicMemberDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public List<BasicRelationshipDTO> Relationships { get; set; }
    }
}