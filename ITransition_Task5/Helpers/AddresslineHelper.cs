using Bogus;
using ITransition_Task5.Models.Entities;


namespace ITransition_Task5.Helpers;

public static class AddresslineHelper
{
    public static string GetRandomisedAddressString(this Address address, Randomizer randomizer)
    {
        var addresses = new[]
        {
            $"{address.State}, {address.City}, {address.Street}, {address.SecondAddress}",
            $"{address.City}, {address.Street}",
            $"{address.City}, {address.Street}, {address.SecondAddress}",
            $"{address.State}, {address.City}, {address.Street}"
        };

        return randomizer.ArrayElement(addresses);
    }
}