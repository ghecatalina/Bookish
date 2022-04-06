using Application;
using Application.Books.Commands.CreateBook;
using Application.Interfaces;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

/*var diContainer = new ServiceCollection()
               .AddMediatR(typeof(IBookRepository))
               .AddScoped<IBookRepository, BookRepository>()
               .BuildServiceProvider();

var mediator = diContainer.GetRequiredService<IMediator>();

var bookId = await mediator.Send(new CreateBookCommand
{
    Author = "Liviu Rebreanu",
    Title = "Adam si Eva"
});

Console.WriteLine($"Order created with {bookId}");*/

var databaseContext = new AppDbContext();
var book = new Book { Author = "Daniel Keyes", Title = "Flori pentru Algernon", BookCoverImage = "cover img", Description = "description", Genre = "fiction" };
databaseContext.Books.Add(book);
databaseContext.SaveChanges();
var user = new User { Email = "ana@gmail.com", Name = "Ana", Password = "1234" };
databaseContext.Users.Add(user);
databaseContext.SaveChanges();
var review = new Review { User = user, Book = book, UserId = user.Id, BookId = book.Id, Rating = 5, ReviewDescription = "Such a lovely book"};
databaseContext.Reviews.Add(review);
databaseContext.SaveChanges();
