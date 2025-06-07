using ITransition_Task5.Models.Entities;

namespace ITransition_Task5.Services;

public interface IUserDataService
{
    public IEnumerable<User> GetUserData(int seed, double mistakeRate, string locale);
}