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
        public async Task<RegularUser> Handle(UpdateRegularUserCommand request, CancellationToken cancellationToken)
        {
            RegularUser user =await _repository.GetByIdWithBookLists(request.Id);
            user.UserName = request.Name;
            user.Email = request.Email;
            //user.Password = request.Password;
            user.ProfilePicture = request.ProfilePicture;
            user.Reviews = request.Reviews;
            user.Read = request.Read;
            user.CurrentlyReading = request.CurrentlyReading;
            user.WantToRead = request.WantToRead;
            //_repository.Update(user);
            await _repository.Save();
            return user;
            
        }
    }
}
