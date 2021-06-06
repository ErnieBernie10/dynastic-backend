using System;
using System.Collections.Generic;

namespace Dynastic.API.DTO
{
    public class BasicMemberDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public Guid? MotherId { get; set; }
        public Guid? FatherId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public List<BasicRelationshipDTO> Relationships { get; set; }
    }
}