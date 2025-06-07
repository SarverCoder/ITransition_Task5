using Bogus;
using ITransition_Task5.Models;
using ITransition_Task5.Models.Enums;

namespace ITransition_Task5.Services;

public class BookGenerator : IBookGenerator
{
    public List<Book> GenerateBooks(BookFilter filter, int page, int pageSize)
    {
        var combinedSeed = (filter.Seed.GetHashCode() + page).ToString();
        Randomizer.Seed = new Random(combinedSeed.GetHashCode());

        var faker = filter.Language switch
        {
            Region.English => new Faker("en"),
            Region.Russian => new Faker("ru"),
            Region.Uzbekistan => new Faker("uz"),
            _ => new Faker("en")
        };

        var books = new List<Book>();
        for (int i = 0; i < pageSize; i++)
        {
            var book = new Faker<Book>()
                .RuleFor(b => b.Index, f => (page - 1) * pageSize + i + 1)
                .RuleFor(b => b.ISBN, f => f.Random.Replace("###-##-#####-##-#"))
                .RuleFor(b => b.Title, f => f.Lorem.Sentence(3, 5))
                .RuleFor(b => b.Author, f => f.Name.FullName())
                .RuleFor(b => b.Publisher, f => f.Company.CompanyName())
                .RuleFor(b => b.Likes, f => GenerateLikes(filter.AverageLikes))
                .RuleFor(b => b.Reviews, f => GenerateReviews(filter.AverageReviews, faker))
                .Generate();

            books.Add(book);
        }

        return books;
    }

    public double GenerateLikes(double averageLikes)
    {
        return averageLikes; // Fraction
    }

    public List<Review> GenerateReviews(double averageReviews, Faker faker)
    {
        var reviews = new List<Review>();
        var reviewCount = (int)Math.Floor(averageReviews);
        var fractional = averageReviews - reviewCount;

        if (faker.Random.Double() < fractional)
            reviewCount++;

        for (int i = 0; i < reviewCount; i++)
        {
            reviews.Add(new Review
            {
                ReviewerName = faker.Name.FullName(),
                ReviewText = faker.Lorem.Paragraph()
            });
        }

        return reviews;
    }
}