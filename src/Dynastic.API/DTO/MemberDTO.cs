namespace Dynastic.API.DTO
{
    public class MemberDTO : PersonDTO
    {
        public RelationshipDTO Relationships { get; set; }
    }
}