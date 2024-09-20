using MediatR;
using OnionCarBook.Application.Features.Mediator.Results.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Queries.ServiceResults
{
    public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
    {
        public int Id { get; set; }
        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
