using System.Collections.Generic;
using System.Linq;
using Dynastic.Application.Common;
using Mapster;

namespace Dynastic.Architecture.Models
{
    public class Dynasty : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Person> Members { get; set; }

        public Tree ToTree()
        {
            var members = Members.Select(m =>
            {
                var member = m.ToMember();
                if (m.Relationships.Count > 0)
                {
                    member.Relationships = m.Relationships.Select(r => new Couple()
                    {
                        Partner = r.Partner.ToMember(),
                        Children = new HashSet<Member>()
                    }).ToHashSet();
                }

                return member;
            });
            return new Tree(members);
        }
    }
}