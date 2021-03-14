using System;
using System.Collections.Generic;
using Dynastic.Architecture.Models;

namespace Dynastic.Application.Common {
    public class Member : Base {

        public Member()
        {
            
        }

        public Member(Person person)
        {
            Firstname = person.Firstname;
            Middlename = person.Middlename;
            Lastname = person.Lastname;
            Mother = person.Mother == null ? null : new Member(person.Mother);
            Father = person.Father == null ? null : new Member(person.Father);
            MotherId = person.MotherId;
            FatherId = person.FatherId;
        }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public Member Mother { get; set; }
        public Guid? MotherId { get; set; }
        public Member Father { get; set; }
        public Guid? FatherId { get; set; }
        public List<Couple> Relationships { get; set; }
    }
}