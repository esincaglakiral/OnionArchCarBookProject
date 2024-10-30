using MediatR;
using OnionCarBook.Application.Features.Mediator.Results.StatisticsResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountByKmSmallerThen1000Query : IRequest<GetCarCountByKmSmallerThen1000QueryResult>
    {
    }
}
