using System;
using System.Collections.Generic;

namespace Dynastic.DTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public Guid? MotherId { get; set; }
        public Guid? FatherId { get; set; }
        public List<PersonDTO> Children { get; set; }
    }
}