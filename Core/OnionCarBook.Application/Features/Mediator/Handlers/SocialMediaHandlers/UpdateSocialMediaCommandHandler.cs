using MediatR;
using OnionCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaID);
            value.Url = request.Url;
            value.Name = request.Name;
            value.Icon = request.Icon;
            await _repository.UpdateAsync(value);
        }
    }
}
