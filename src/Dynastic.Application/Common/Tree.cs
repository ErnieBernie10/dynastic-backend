using System.Collections.Generic;
using System.Linq;
using Dynastic.Architecture.Models;
using Mapster;

namespace Dynastic.Application.Common
{
    public class Tree
    {
        public Dynasty Dynasty { get; set; }
        public HashSet<Member> FlatTree { get; set; }
        public HashSet<Member> NestedTree { get; set; }
        public Tree(Dynasty dynasty)
        {
            FlatTree = new HashSet<Member>();
            NestedTree = new HashSet<Member>();
            foreach (var person in dynasty.Members)
            {
                FlatTree.Add(new Member()
                {
                    Id = person.Id,
                    CreatedAt = person.CreatedAt,
                    ModifiedAt = person.ModifiedAt,
                    Firstname = person.Firstname,
                    Lastname = person.Lastname,
                    Middlename = person.Middlename,
                    MotherId = person.MotherId,
                    FatherId = person.FatherId
                });
            }

            foreach (var member in FlatTree)
            {
                Relate(member);
            }
        }

        private void Relate(Member member)
        {
            var father = FlatTree.FirstOrDefault(p => p.Id.Equals(member.FatherId));
            var mother = FlatTree.FirstOrDefault(p => p.Id.Equals(member.MotherId));
            father?.AddChildWithPartner(member, mother);
            mother?.AddChildWithPartner(member, father);
            if (father is not null)
            {
                Relate(father);
                member.Father = father;
            }

            if (mother is not null)
            {
                Relate(mother);
                member.Mother = mother;
            }

            if (member.MotherId is null && member.FatherId is null)
            {
                NestedTree.Add(member);
            }
        }
    }
}