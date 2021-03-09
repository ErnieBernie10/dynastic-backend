using System.Collections.Generic;
using System.Linq;
using Dynastic.Architecture.Models;
using Mapster;

namespace Dynastic.Application.Common
{
    public class Tree
    {
        public Tree(Person dynasticHead)
        {
            Loaded = new HashSet<Member>();
            Member = LoadPerson(dynasticHead);
        }

        private Member LoadPerson(Person person)
        {
            Member member = null;
            if (person == null) return null;
            member = Loaded.FirstOrDefault(l => l.Id.Equals(person.Id));
            if (member == null)
            {
                member = new Member
                {
                    Id = person.Id,
                    CreatedAt = person.CreatedAt,
                    ModifiedAt = person.ModifiedAt,
                    Father = LoadPerson(person.Father),
                    FatherId = person.FatherId,
                    Mother = LoadPerson(person.Mother),
                    MotherId = person.MotherId,
                    Firstname = person.Firstname,
                    Lastname = person.Lastname,
                    Middlename = person.Middlename,
                };
                Loaded.Add(member);
                List<Couple> couple = null;
                if (person.Relationships != null)
                {
                    couple = person.Relationships.Select(partner => new Couple() { Partner = LoadPerson(partner.Partner), Children = person.Children.Where(c => partner.Partner.Children.Contains(c)).Select(p => LoadPerson(p)).ToList() }).ToList();
                    member.Relationships = couple;
                }
            }
            return member;
        }

        public Member Member { get; set; }
        public Dynasty Dynasty { get; set; }
        private HashSet<Member> Loaded { get; set; }
    }
}