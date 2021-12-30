using Dynastic.Architecture.Repositories;
using Dynastic.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dynastic.Application.Dynasties.Commands
{
    public class CreateMemberCommand : IRequest<Guid>
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string MotherId { get; set; }
        public string FatherId { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Guid>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IDynastyRepository _dynastyRepository;

        public CreateMemberCommandHandler(IDynastyRepository dynastyRepository, IPersonRepository personRepository)
        {
            _dynastyRepository = dynastyRepository;
            _personRepository = personRepository;
        }

        public async Task<Guid> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            Guid? motherId = string.IsNullOrEmpty(request.MotherId) ? null : new Guid(request.MotherId);
            Guid? fatherId = string.IsNullOrEmpty(request.FatherId) ? null : new Guid(request.FatherId);
            var person = await _personRepository.Create(new Person()
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Middlename = request.Middlename,
                BirthDate = request.BirthDate,
                MotherId = motherId,
                FatherId = fatherId
            });
            if (motherId is not null && fatherId is not null)
            {
                await _personRepository.AddRelationship(motherId.Value, fatherId.Value);
            }
            var dynasty = await _dynastyRepository.GetById(new Guid(request.Id));
            dynasty.Members.Add(person);
            await _dynastyRepository.Update(dynasty);
            return new Guid(request.Id);
        }
    }
}
