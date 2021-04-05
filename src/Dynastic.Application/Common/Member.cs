using System;
using System.Collections.Generic;
using System.Linq;
using Dynastic.Architecture.Models;
using Newtonsoft.Json;

namespace Dynastic.Application.Common {
    public class Member : Base {

        public Member()
        {
            Relationships = new HashSet<Couple>();
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
        [JsonIgnore]
        public Member Mother { get; set; }
        public Guid? MotherId { get; set; }
        [JsonIgnore]
        public Member Father { get; set; }
        public Guid? FatherId { get; set; }
        [JsonIgnore]
        public HashSet<Couple> Relationships { get; set; }

        public void AddChildWithPartner(Member child, Member partner)
        {
            var relationship = Relationships.FirstOrDefault(m => m.Partner.Id.Equals(partner.Id));
            if (relationship is null)
            {
                Relationships.Add(new Couple()
                {
                    Partner = partner,
                    Children = new HashSet<Member>() {child}
                });
            }
            else
            {
                relationship?.Children.Add(child);
            }
        }
    }
}