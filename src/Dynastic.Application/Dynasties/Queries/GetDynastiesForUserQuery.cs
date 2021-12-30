using Dynastic.Architecture.Repositories;
using Dynastic.Domain.Models;
using Dynastic.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dynastic.Application.Dynasties.Queries
{
    public class GetDynastiesForUserQuery : IRequest<IList<Dynasty>>
    {
    }

    public class GetDynastiesForUserQueryHandler : IRequestHandler<GetDynastiesForUserQuery, IList<Dynasty>>
    {
        private readonly IDynastyRepository _dynastyRepository;
        private readonly ICurrentUserService _currentUserService;
        public GetDynastiesForUserQueryHandler(IDynastyRepository repo, ICurrentUserService currentUserService)
        {
            _dynastyRepository = repo;
            _currentUserService = currentUserService;
        }
        public async Task<IList<Dynasty>> Handle(GetDynastiesForUserQuery request, CancellationToken cancellationToken)
        {
            return await _dynastyRepository.GetUserDynasties(_currentUserService.UserId);
        }
    }
}
