using Application;
using Infrastructure;

IUserRepository users = new InMemoryUserRepository();
var email = "ana@gmail.com";
var password = "1234";
var currentUser = users.Login(email, password);
IBookRepository bookRepo = new InMemoryBookRepository();
var books = bookRepo.GetBooks();
IBookListRepository bookList = new InMemoryBookListRepository();
bookList.AddBookToRead(currentUser, books.ElementAt(0));
IReviewRepository reviewRepo = new InMemoryReviewRepository();
var review = reviewRepo.CreateReview("my review", 3.2, currentUser, books.ElementAt(0));
reviewRepo.AddReview(review, currentUser, books.ElementAt(0));

var reviews = reviewRepo.GetReviews();
foreach (var rev in reviews)
{
    Console.WriteLine($"{rev.User.Name} on the book \"{rev.Book.Title}\": {rev.ReviewDescription}");
}

