using System.Collections.Generic;
using System.Linq;
using Mapster;

namespace Dynastic.Application.Common
{
    public class Tree
    {
        public HashSet<Member> FlatTree { get; }
        public HashSet<Member> NestedTree { get; }
        private HashSet<Member> Loaded;
        public Tree(IEnumerable<Member> members)
        {
            Loaded = new HashSet<Member>(members);
            FlatTree = new HashSet<Member>();
            NestedTree = new HashSet<Member>();
            foreach (var person in Loaded)
            {
                LoadPerson(person);
            }
        }

        private Member LoadPerson(Member person)
        {
            var member = Loaded.FirstOrDefault(m => m.Id.Equals(person.Id));
            if (person == null) return null;
            if (person.FatherId is null && person.MotherId is null)
            {
                NestedTree.Add(member);
            }
            else
            {
                if (member is not null)
                {
                    // TODO : Optimize unnecessary recursive calls
                    if (member.FatherId is not null)
                    {
                        member.Father = LoadPerson(Loaded.FirstOrDefault(p => p.Id.Equals(member.FatherId)));
                    }

                    if (member.MotherId is not null)
                    {
                        member.Mother = Loaded.FirstOrDefault(p => p.Id.Equals(member.MotherId));
                    }
                    NestedTree.Remove(member.Mother);
                    member = AddChild(member, member.Mother, member.Father);
                }
            }

            return member;
        }

        private Member AddChild(Member child, Member mother, Member father)
        {
            if (mother is null)
            {
                child = AddChild(child, father);
            } else if (father is null)
            {
                child = AddChild(child, mother);
            }
            else
            {
                father.AddChildWithPartner(child, mother);
            }
            return child;
        }

        private Member AddChild(Member member, Member parent)
        {
            parent.AddChildWithPartner(member, null);
            return member;
        }

    }
}