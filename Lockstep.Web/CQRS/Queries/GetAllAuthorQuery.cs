using Lockstep.Domain.DAO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Queries
{
    public class GetAllAuthorQuery : IRequest<IEnumerable<Author>> { }

    public class GetAllContentQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<Author>>
    {
        private readonly IAuthorRepository _repository;

        public GetAllContentQueryHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get();
        }
    }
}
