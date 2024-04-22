using PharmacyManagement.Exceptions;
using PharmacyModels;

namespace PharmacyManagement.Repositories;

public class StaffRepo : BaseEntityRepo<Staff>
{
    /// <summary>
    /// Finds a staff member by their email.
    /// </summary>
    /// <param name="email">The email of the staff member to find.</param>
    /// <returns>The staff member with the specified email, or null if not found.</returns>
    /// <exception cref="UserNotFound">If no user exists for the mail</exception>
    public Staff FindByEmail(string email)
    {
        foreach (var entitiesValue in Entities.Values)
        {
            if (entitiesValue.Email.Equals(email))
                return entitiesValue;
        }

        throw new UserNotFound($"User not found for the mail {email}");
    }

    /// <summary>
    /// Finds a staff member by their email and password.
    /// </summary>
    /// <param name="email">The email of the staff member to find.</param>
    /// <param name="password">The password of the staff member to find.</param>
    /// <returns>The staff member with the specified email and password, or null if not found.</returns>
    /// <exception cref="UserNotFound">If no user present for the credential.</exception>
    public Staff FindByEmailAndPassword(string email, string password)
    {
        var staff = FindByEmail(email);
        if (staff.Password.Equals(password))
        {
            return staff;
        }

        throw new UserNotFound($"User not found for the credentials email and password!!!");
    }

    /// <summary>
    /// Finds staff members by their role.
    /// </summary>
    /// <param name="role">The role of the staff members to find.</param>
    /// <returns>A list of staff members with the specified role.</returns>
    public List<Staff> FindByRole(string role)
    {
        return Entities.Values.Where(staff => staff.Role == role).ToList();
    }
}