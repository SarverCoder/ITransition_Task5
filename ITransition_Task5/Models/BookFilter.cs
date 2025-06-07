using ITransition_Task5.Models.Enums;

namespace ITransition_Task5.Models;

public class BookFilter
{
    public Region Language { get; set; } // Masalan: "en-US", "de-DE", "ja-JP"
    public string Seed { get; set; }
    public double AverageLikes { get; set; }
    public double AverageReviews { get; set; }
}