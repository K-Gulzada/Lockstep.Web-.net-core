using Lockstep.Domain.DAO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Queries
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public int Id { get; set; }
    }

    internal class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorRepository _repository;

        public GetAuthorByIdQueryHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}

// реализовать отправку запроса к LockStep.WebApi через Медиатор
// прочитать Host ASP>NET Core on Linux With NGinx
