using Dynastic.Architecture.Repositories;
using Dynastic.Domain.Models;
using Dynastic.Domain.Services;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dynastic.Application.Dynasties.Commands
{
    public class CreateDynastyCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateDynastyCommandHandler : IRequestHandler<CreateDynastyCommand, Guid>
    {
        private readonly IDynastyRepository _dynastyRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateDynastyCommandHandler(ICurrentUserService currentUserService, IDynastyRepository dynastyRepository)
        {
            _currentUserService = currentUserService;
            _dynastyRepository = dynastyRepository;
        }

        public async Task<Guid> Handle(CreateDynastyCommand request, CancellationToken cancellationToken)
        {
            var created = await _dynastyRepository.Create(_currentUserService.UserId, request.Adapt<Dynasty>());
            return created.Id;
        }
    }
}
