using System;

namespace Dynastic.API.DTO
{
    public class CreatePersonDTO
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string MotherId { get; set; }
        public string FatherId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}