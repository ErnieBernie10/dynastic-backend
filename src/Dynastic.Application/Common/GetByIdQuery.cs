using Dynastic.Domain;
using Dynastic.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// This is definitely overkill but it shows off nicely how to use generics
namespace Dynastic.Application.Common
{
    public abstract class GetByIdQuery<T> : IRequest<T>
    {
        public string Id { get; set; }
    }
    public abstract class GetByIdQueryHandler<T, R, I> : IRequestHandler<I, R> where T : IRepository<R> where R : Base where I : GetByIdQuery<R>
    {
        private readonly T _repository;
        public GetByIdQueryHandler(T repository)
        {
            _repository = repository;
        }
        public Task<R> Handle(I request, CancellationToken cancellationToken)
        {
            return _repository.GetById(new Guid(request.Id));
        }
    }
}
