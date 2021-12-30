using Dynastic.Application.Common;
using Dynastic.Architecture.Repositories;
using Dynastic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynastic.Application.Persons.Queries
{
    public class GetPersonByIdQuery : GetByIdQuery<Person>
    {
    }

    public class GetPersonByIdQueryHandler : GetByIdQueryHandler<IPersonRepository, Person, GetPersonByIdQuery>
    {
        public GetPersonByIdQueryHandler(IPersonRepository repository) : base(repository)
        {
        }
    }
}
