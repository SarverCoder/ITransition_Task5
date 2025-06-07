using CsvHelper.Configuration;
using ITransition_Task5.Models.Entities;

namespace ITransition_Task5.Helpers;

public class DataCsvMap : ClassMap<User>
{
    public DataCsvMap()
    {
        Map(u => u.Id);
        Map(u => u.FirstName);
        Map(u => u.LastName);
        Map(u => u.Gender);
        Map(u => u.AddressString);
        Map(u => u.PhoneNumber);
    }
}