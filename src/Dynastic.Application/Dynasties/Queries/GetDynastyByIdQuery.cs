using Dynastic.Application.Common;
using Dynastic.Architecture.Repositories;
using Dynastic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynastic.Application.Dynasties.Queries
{
    public class GetDynastyByIdQuery : GetByIdQuery<Dynasty>
    {
    }

    public class GetDynastyByIdQueryHandler : GetByIdQueryHandler<IDynastyRepository, Dynasty, GetDynastyByIdQuery>
    {
        public GetDynastyByIdQueryHandler(IDynastyRepository repository) : base(repository)
        {
        }
    }
}
