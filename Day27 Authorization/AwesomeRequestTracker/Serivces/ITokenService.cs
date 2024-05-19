using AwesomeRequestTracker.DTO;
using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Serivces;

public interface ITokenService
{
    public string GenerateToken(Person person);
    public PayloadDTO GetPayload(string token);
}