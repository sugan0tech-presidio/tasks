using System.Security.Authentication;
using PharmacyManagement.Exceptions;
using PharmacyManagement.Repositories;
using PharmacyModels;

namespace PharmacyManagement.Services;

public class StaffService
{
    private readonly StaffRepo _staffRepository;
    public static bool IsLogged { get; private set; }
    public static Staff? LoggedStaff { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StaffService"/> class.
    /// </summary>
    /// <param name="staffRepository">The staff repository.</param>
    public StaffService(StaffRepo staffRepository)
    {
        _staffRepository = staffRepository ??
                           throw new ArgumentNullException(nameof(staffRepository), "Staff repository cannot be null.");
    }

    /// <summary>
    /// Retrieves a staff member by their ID.
    /// </summary>
    /// <param name="id">The ID of the staff member to retrieve.</param>
    /// <returns>The staff member with the specified ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the staff member with the specified ID is not found.</exception>
    public Staff GetById(int id)
    {
        try
        {
            return _staffRepository.GetById(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Staff member with ID {id} not found.");
        }
    }

    /// <summary>
    /// Retrieves all staff members.
    /// </summary>
    /// <returns>A list of all staff members.</returns>
    public List<Staff> GetAll()
    {
        return _staffRepository.GetAll();
    }

    /// <summary>
    /// Adds a new staff member.
    /// </summary>
    /// <param name="staff">The staff member to add.</param>
    /// <returns>The added staff member.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the staff member is null.</exception>
    public Staff Add(Staff staff)
    {
        if (staff == null)
            throw new ArgumentNullException(nameof(staff), "Staff member cannot be null.");

        return _staffRepository.Add(staff);
    }

    /// <summary>
    /// Updates an existing staff member.
    /// </summary>
    /// <param name="staff">The staff member to update.</param>
    /// <returns>The updated staff member.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the staff member is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if the staff member to update is not found.</exception>
    public Staff Update(Staff staff)
    {
        if (staff == null)
            throw new ArgumentNullException(nameof(staff), "Staff member cannot be null.");

        try
        {
            return _staffRepository.Update(staff);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Staff member with ID {staff.Id} not found.");
        }
    }

    /// <summary>
    /// Deletes a staff member by their ID.
    /// </summary>
    /// <param name="id">The ID of the staff member to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the staff member with the specified ID is not found.</exception>
    public void Delete(int id)
    {
        try
        {
            _staffRepository.Delete(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Staff member with ID {id} not found.");
        }
    }

    /// <summary>
    /// Authenticates a staff member with the provided credentials.
    /// </summary>
    /// <param name="email">The email of the staff member.</param>
    /// <param name="password">The password of the staff member.</param>
    /// <returns>The authenticated staff member.</returns>
    /// <exception cref="ArgumentException">Thrown if the email or password is empty or null.</exception>
    /// <exception cref="AuthenticationException">Thrown if authentication fails.</exception>
    public Staff Authenticate(string email, string password)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email cannot be empty or null.", nameof(email));

        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Password cannot be empty or null.", nameof(password));

        var authenticatedStaff = _staffRepository.FindByEmailAndPassword(email, password);

        if (authenticatedStaff == null)
            throw new AuthenticationException("Invalid email or password.");

        IsLogged = true;
        LoggedStaff = authenticatedStaff;

        return authenticatedStaff;
    }

    /// <summary>
    /// Adds a role to the staff member with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the staff member.</param>
    /// <param name="role">The role to add.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the staff member with the specified ID is not found.</exception>
    public void AddRole(int id, Roles role)
    {
        var staff = GetById(id);
        staff.Role = role;
        Update(staff);
    }

    public void Logout()
    {
        IsLogged = false;
    }

    /// <summary>
    /// Get's role of the given staff
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotLoggedInException">If there is no login attempt</exception>
    public Roles getRole()
    {
        if (LoggedStaff != null) return LoggedStaff.Role;
        throw new NotLoggedInException("Login first!!!");
    }
}