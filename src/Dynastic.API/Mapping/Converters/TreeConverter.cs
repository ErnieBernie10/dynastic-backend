using System.Collections.Generic;
using System.Linq;
using Dynastic.API.DTO;
using Dynastic.Application.Common;

namespace Dynastic.API.Mapping.Converters
{
    public class TreeConverter : ITypeConverter<Tree, FlatTreeDTO>
    {
        public FlatTreeDTO Convert(Tree source)
        {
            var treeDto = new FlatTreeDTO();
            foreach (var pair in source.Members)
            {
                var member = pair.Value;
                var memberDto = new BasicMemberDTO()
                {
                    Firstname = member.Firstname,
                    Lastname = member.Lastname,
                    Middlename = member.Middlename,
                    Relationships = new List<BasicRelationshipDTO>()
                };

                source.Members.TryGetValue(member.MotherId.ToString(), out var mother);
                source.Members.TryGetValue(member.FatherId.ToString(), out var father);
                MakePartner(member, treeDto, father, mother);
                MakePartner(member, treeDto, mother, father);

                treeDto.Members.TryAdd(member.Id.ToString(), memberDto);
            }

            return treeDto;
        }

        private void MakePartner(Member member, FlatTreeDTO treeDto, Member parent, Member partner)
        {
            var children = new List<string>(new[] {member.Id.ToString()});
            if (parent is not null)
            {
                if (!treeDto.Members.TryGetValue(parent.Id.ToString(), out var res))
                {
                    res = new BasicMemberDTO()
                    {
                        Firstname = parent.Firstname,
                        Lastname = parent.Lastname,
                        Middlename = parent.Middlename,
                        Relationships = new List<BasicRelationshipDTO>()
                    };
                    res.Relationships.Add(new BasicRelationshipDTO()
                    {
                        Partner = partner?.Id.ToString(),
                        Children = children
                    });
                }
                else
                {
                    var rel = res.Relationships.FirstOrDefault(r =>
                        r.Partner.Equals(partner.Id.ToString()));
                    if (rel is not null)
                    {
                        rel.Children.Add(member.Id.ToString());
                    }
                    else
                    {
                        res.Relationships.Add(new BasicRelationshipDTO()
                        {
                            Partner = partner.Id.ToString(),
                            Children = children
                        });
                    }
                }

                treeDto.Members.TryAdd(parent.Id.ToString(), res);
            }
        }
    }
}