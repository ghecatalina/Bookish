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
using Application.Users.Commands.AddBookToReadList;
using Application.Users.Queries.GetReadList;
using Application.Users.Queries.GetRegularUserById;

var diContainer = new ServiceCollection()
               .AddDbContext<AppDbContext>()
               .AddMediatR(typeof(IBookRepository))
               .AddScoped<IBookRepository, BookRepository>()
               .AddScoped<IUserRepository, UserRepository>()
               .AddScoped<IReviewRepository, ReviewRepository>()
               .AddScoped<IRegularUserRepository, RegularUserRepository>()
               .BuildServiceProvider();

var mediator = diContainer.GetRequiredService<IMediator>();

/*
var user1 = await mediator.Send(new CreateRegularUserCommand
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
foreach (var bookEx in books)
{
    Console.WriteLine($"{bookEx.Title} -> {bookEx.Author}");
}

var users = await mediator.Send(new GetUsersQuery());
foreach (var userEx in users)
{
    Console.WriteLine($"{userEx.Id}: {userEx.Name}");
}

var user = await mediator.Send(new CreateRegularUserCommand
{
    Email = "catalina@gmail.com",
    Name = "Catalina",
    Password = "1234",
    ProfilePicture = "profile picture"
});

var add = await mediator.Send(new AddBookToReadCommand
{
    UserId = 1,
    BookId = 1,
});

*/
var book = await mediator.Send(new GetBookByIdQuery { Id = 1 });
Console.WriteLine(book.Title);

var read = await mediator.Send(new GetReadListQuery { Id = 1});
if (read == null)
{
    Console.WriteLine("No books");
}
else
{
    if (read.Books == null)
    {
        Console.WriteLine("No books");
    }
    else
    {
        foreach (var bookEx in read.Books)
        {
            Console.WriteLine("read -> " + bookEx.Title);
        }
    }
}
Console.WriteLine("here");
var foundUser = await mediator.Send(new GetRegularUserByIdQuery { Id=1 });
if (foundUser != null)
{
    Console.WriteLine(foundUser.Read.Books.ElementAt(0).Title);
}