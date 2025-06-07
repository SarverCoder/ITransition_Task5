using System.Reflection;
using ITransition_Task5.Models.Enums;

namespace ITransition_Task5.Models.Entities;

public class User
{
    public string Id { get; set; }

    public Gender Gender { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Address Address { get; set; }

    public string AddressString { get; set; }

    public string PhoneNumber { get; set; }
}