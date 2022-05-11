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
    public class UpdateRegularUserCommandHandler : IRequestHandler<UpdateRegularUserCommand, User>
    {
        private readonly IUserRepository _repository;
        public UpdateRegularUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> Handle(UpdateRegularUserCommand request, CancellationToken cancellationToken)
        {
            User user =await _repository.GetByIdWithBookLists(request.Id);
            user.UserName = request.Name;
            user.Email = request.Email;
            //user.Password = request.Password;
            user.ProfilePicture = request.ProfilePicture;
            user.Reviews = request.Reviews;
            user.Read = request.Read;
            user.CurrentlyReading = request.CurrentlyReading;
            user.WantToRead = request.WantToRead;
            //_repository.Update(user);
            _repository.Update(user);
            return user;
            
        }
    }
}
