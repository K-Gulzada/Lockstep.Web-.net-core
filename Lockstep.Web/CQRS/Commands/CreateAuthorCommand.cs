using Lockstep.Domain.DAO;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Commands
{
    public class CreateAuthorCommand : IRequest
    {
        [Display(Name = "Наименование")]
        public string FullName { get; set; }
    }

    public class CreateContentCommandHandler : IRequestHandler<CreateAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _repository;

        public CreateContentCommandHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            await _repository.Insert(new Author { FullName = command.FullName });
            return Unit.Value;
        }
    }
}
