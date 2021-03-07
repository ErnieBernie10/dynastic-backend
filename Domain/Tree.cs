using System.Collections.Generic;
using System.Linq;
using Dynastic.Models;
using Mapster;

namespace Dynastic.Domain
{
    public class Tree
    {
        public Tree(Person dynasticHead)
        {
            Loaded = new HashSet<Member>();
            DynasticHead = loadPerson(dynasticHead);
        }

        private Member loadPerson(Person person)
        {
            Member member = null;
            if (person == null) return member;
            member = Loaded.FirstOrDefault(l => l.Id.Equals(person.Id));
            if (member == null)
            {
                member = new Member
                {
                    Id = person.Id,
                    CreatedAt = person.CreatedAt,
                    ModifiedAt = person.ModifiedAt,
                    Father = loadPerson(person.Father),
                    FatherId = person.FatherId,
                    Mother = loadPerson(person.Mother),
                    MotherId = person.MotherId,
                    Firstname = person.Firstname,
                    Lastname = person.Lastname,
                    Middlename = person.Middlename,
                };
                Loaded.Add(member);
                List<Couple> couple = null;
                if (person.Relationships != null)
                {
                    couple = person.Relationships.Select(partner => new Couple() { Partner = loadPerson(partner.Partner), Children = person.Children.Where(c => partner.Partner.Children.Contains(c)).Select(p => loadPerson(p)).ToList() }).ToList();
                    member.Relationships = couple;
                }
            }
            return member;
        }

        public Member DynasticHead { get; set; }
        public Dynasty Dynasty { get; set; }
        private HashSet<Member> Loaded { get; set; }
    }
}