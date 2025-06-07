using Bogus;
using ITransition_Task5.Models;
using ITransition_Task5.Models.Enums;

namespace ITransition_Task5.Services;

public interface IBookGenerator
{
    List<Book> GenerateBooks(BookFilter filter, int page, int pageSize);
    double GenerateLikes(double averageLikes);

    List<Review> GenerateReviews(double averageReviews, Faker faker);
}