using AwesomeRequestTracker.Exceptions;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Services;

namespace AwesomeRequestTracker.Serivces;

public class AdminService
{
    private readonly IBaseService<Registry> _registryService;

    public AdminService(IBaseService<Registry> registryService)
    {
        _registryService = registryService;
    }

    public Registry ActivateUser(int id)
    {
        var registry = _registryService.GetAll().Result.Find(r => r.Person.Id.Equals(id));
        if (registry == null)
            throw new UserNotRegisteredException("Please ask the user to register for account activation");
        
        registry.IsActivated = true;
        _registryService.Update(registry);
        return registry;
    }
    
    public Registry DeactivateUser(int id)
    {
        var registry = _registryService.GetAll().Result.Find(r => r.Person.Id.Equals(id));
        if (registry == null)
            throw new UserNotRegisteredException("User Not registered");
        registry.IsActivated = false;
        _registryService.Update(registry);
        return registry;
    }
}