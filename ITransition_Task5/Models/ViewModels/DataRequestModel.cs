using ITransition_Task5.Models.Enums;

namespace ITransition_Task5.Models.ViewModels;

public class DataRequestModel
{
    public Region Region { get; set; }
    public double MistakesRate { get; set; }
    public int Seed { get; set; }
    public int PageNumber { get; set; }
}