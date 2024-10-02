using MediatR;
using OnionCarBook.Application.Features.Mediator.Commands.BlogCommands;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);
            value.Title = request.Title;
            value.CreatedDate = request.CreatedDate;
            value.Description = request.Description;
            value.CoverImageUrl = request.CoverImageUrl;
            value.AuthorID = request.AuthorID;
            value.CategoryID = request.CategoryID;
            await _repository.UpdateAsync(value);
        }
    }
}
