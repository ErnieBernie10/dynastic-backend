using Dynastic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Dynastic.Application.Common {
    public class Member : Base {

        public Member()
        {
            Relationships = new HashSet<Couple>();
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
        public DateTime? BirthDate { get; set; }
        public HashSet<Couple> Relationships { get; set; }

        public void AddChildWithPartner(Member child, Member partner)
        {
            Couple relationship = null;
            if (partner is not null)
            {
                relationship = Relationships.FirstOrDefault(m => m.Partner.Id.Equals(partner.Id));
            }
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