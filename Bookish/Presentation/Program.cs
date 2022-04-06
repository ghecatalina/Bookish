﻿using Application.Books.Queries.GetBooks;
using Application.Interfaces;
using Application.Users.Commands.CreateUser;
using Application.Books.Commands.CreateBook;
using Domain;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Users.Queries.GetUsers;
using Application.Reviews.Commands.CreateReview;
using Application.Reviews.Queries.GetReviewsByBook;

var diContainer = new ServiceCollection()
               .AddDbContext<AppDbContext>()
               .AddMediatR(typeof(IBookRepository))
               .AddScoped<IBookRepository, BookRepository>()
               .AddScoped<IUserRepository, UserRepository>()
               .AddScoped<IReviewRepository, ReviewRepository>()
               .BuildServiceProvider();

var mediator = diContainer.GetRequiredService<IMediator>();

var user1 = await mediator.Send(new CreateUserCommand
{
    Email = "vlad@gmail.com",
    Name = "Vlad",
    Password = "1234"
});

var user2 = await mediator.Send(new CreateUserCommand
{
    Email = "ana@gmail.com",
    Name = "Ana",
    Password = "1234"
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

var review = await mediator.Send(new CreateReviewCommand { ReviewDescription = "my review", Rating = 5, BookId = book1.Id, UserId = user1.Id });
var reviews = await mediator.Send(new GetReviewsByBookQuery { BookId = book1.Id});


/*var bookId = await mediator.Send(new CreateBookCommand
{
    Author = "Liviu Rebreanu",
    Title = "Adam si Eva"
});

Console.WriteLine($"Order created with {bookId}");*/

//var databaseContext = new AppDbContext();
/*var book = new Book { Author = "Daniel Keyes", Title = "Flori pentru Algernon", BookCoverImage = "cover img", Description = "description", Genre = "fiction" };
databaseContext.Books.Add(book);
databaseContext.SaveChanges();
var user = new User { Email = "ana@gmail.com", Name = "Ana", Password = "1234" };
databaseContext.Users.Add(user);
databaseContext.SaveChanges();
var review = new Review { User = user, Book = book, UserId = user.Id, BookId = book.Id, Rating = 5, ReviewDescription = "Such a lovely book"};
databaseContext.Reviews.Add(review);
databaseContext.SaveChanges();*/
