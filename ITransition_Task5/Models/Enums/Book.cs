using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ITransition_Task5.Models.Enums;

public class Book
{
    public int Index { get; set; }
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public double Likes { get; set; }
    public List<Review> Reviews { get; set; }
}