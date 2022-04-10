using Application.Books.Queries.GetBooks;
using Application.Interfaces;
using Application.Users.Commands.CreateUser;
using Application.Books.Commands.CreateBook;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Users.Queries.GetUsers;
using Application.Reviews.Commands.CreateReview;
using Application.Reviews.Queries.GetReviewsByBook;
using Application.Users.Commands.CreateRegularUser;
using Application.Users.Commands.UpdateRegularUser;
using Infrastructure.Repositories;
using Application.Books.Queries.GetBookById;

var diContainer = new ServiceCollection()
               .AddDbContext<AppDbContext>()
               .AddMediatR(typeof(IBookRepository))
               .AddScoped<IBookRepository, BookRepository>()
               .AddScoped<IUserRepository, UserRepository>()
               .AddScoped<IReviewRepository, ReviewRepository>()
               .AddScoped<IBookListRepository, BookListRepository>()
               .AddScoped<IRegularUserRepository, RegularUserRepository>()
               .BuildServiceProvider();

var mediator = diContainer.GetRequiredService<IMediator>();

/*var user1 = await mediator.Send(new CreateRegularUserCommand
{
    Email = "vlad@gmail.com",
    Name = "Vlad",
    Password = "1234",
    ProfilePicture = "profile picture"
});

var user2 = await mediator.Send(new CreateUserCommand
{
    Email = "ana@gmail.com",
    Name = "Ana",
    Password = "1234",
});

var book1 = await mediator.Send(new CreateBookCommand { Author = "Deniel Keyes", Title = "Flori pentru Algernon", BookCoverImage = "cover img", Genre = "fiction", Description = "description" });
var book2 = await mediator.Send(new CreateBookCommand { Author = "Stacey Halls", Title = "Doamna England", BookCoverImage = "cover img", Genre = "fiction", Description = "description" });
var books = await mediator.Send(new GetBooksQuery());
foreach (var book in books)
{
    Console.WriteLine($"{book.Title} -> {book.Author}");
}

var users = await mediator.Send(new GetUsersQuery());
foreach (var user in users)
{
    Console.WriteLine($"{user.Id}: {user.Name}");
}

user1.Read.Books.Add(book1);

var new_user = await mediator.Send(new UpdateRegularUserCommand
{
    Id = user1.Id,
    Name = "Vlad Vlad",
    Email = user1.Email,
    Password = user1.Password,
    ProfilePicture = user1.ProfilePicture,
    Read = user1.Read,
    CurrentlyReading = user1.CurrentlyReading,
    WantToRead = user1.WantToRead,
    Reviews = user1.Reviews,
});*/

var user = await mediator.Send(new CreateRegularUserCommand
{
    Email = "catalina@gmail.com",
    Name = "Catalina",
    Password = "1234",
    ProfilePicture = "profile picture"
});

var book = await mediator.Send(new GetBookByIdQuery { Id = 1 });
user.Read.Books.Add(book);
var new_user = await mediator.Send(new UpdateRegularUserCommand
{
    Id = user.Id,
    Name = "Vlad Vlad",
    Email = user.Email,
    Password = user.Password,
    ProfilePicture = user.ProfilePicture,
    Read = user.Read,
    CurrentlyReading = user.CurrentlyReading,
    WantToRead = user.WantToRead,
    Reviews = user.Reviews,
}); 