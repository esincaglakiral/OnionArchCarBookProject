using MediatR;
using OnionCarBook.Application.Features.Mediator.Queries.ServiceResults;
using OnionCarBook.Application.Features.Mediator.Results.ServiceResults;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                Description = x.Description,
                IconUrl = x.IconUrl,
                Title = x.Title,
                ServiceID = x.ServiceID
            }).ToList();
        }
    }
}
