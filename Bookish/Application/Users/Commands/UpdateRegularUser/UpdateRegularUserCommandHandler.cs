using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateRegularUser
{
    public class UpdateRegularUserCommandHandler : IRequestHandler<UpdateRegularUserCommand, RegularUser>
    {
        private readonly IRegularUserRepository _repository;
        public UpdateRegularUserCommandHandler(IRegularUserRepository repository)
        {
            _repository = repository;
        }
        public Task<RegularUser> Handle(UpdateRegularUserCommand request, CancellationToken cancellationToken)
        {
            RegularUser user = _repository.GetByIdWithBookLists(request.Id);
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.ProfilePicture = request.ProfilePicture;
            user.Reviews = request.Reviews;
            user.Read = request.Read;
            user.CurrentlyReading = request.CurrentlyReading;
            user.WantToRead = request.WantToRead;
            _repository.Update(user);
            _repository.Save();
            return Task.FromResult(user);
            
        }
    }
}
