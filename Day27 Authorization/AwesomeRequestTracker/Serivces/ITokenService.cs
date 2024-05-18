using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Serivces;

public interface ITokenService
{
    public string GenerateToken(Person person);
}