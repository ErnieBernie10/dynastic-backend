using System.Collections.Generic;
using System.Linq;
using Dynastic.Domain.Models;
using Mapster;

namespace Dynastic.Application.Common
{
    public class Tree
    {
        public HashSet<Member> NestedTree { get; }
        public Dictionary<string, Member> Members { get; }
        public Tree(IEnumerable<Member> members)
        {
            Members = members.ToDictionary(m => m.Id.ToString(), m => m);
            NestedTree = new HashSet<Member>();
            InitializeNestedTree(Members);
        }

        private void InitializeNestedTree(Dictionary<string, Member> loaded)
        {
            foreach (var person in loaded)
            {
                LoadPerson(person.Value);
            }
        }

        private Member LoadPerson(Member person)
        {
            var member = Members[person.Id.ToString()];
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
                        member.Father = LoadPerson(Members[person.FatherId.ToString()]);
                    }

                    if (member.MotherId is not null)
                    {
                        member.Mother = Members[person.MotherId.ToString()];
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