using PharmacyModels;

namespace PharmacyManagement.Repositories;

public class StaffRepo: BaseEntityRepo<Staff>
{
    /// <summary>
    /// Finds a staff member by their email.
    /// </summary>
    /// <param name="email">The email of the staff member to find.</param>
    /// <returns>The staff member with the specified email, or null if not found.</returns>
    public Staff FindByEmail(string email)
    {
        return Entities.Values.FirstOrDefault(staff => staff.Email == email);
    }

    /// <summary>
    /// Finds a staff member by their email and password.
    /// </summary>
    /// <param name="email">The email of the staff member to find.</param>
    /// <param name="password">The password of the staff member to find.</param>
    /// <returns>The staff member with the specified email and password, or null if not found.</returns>
    public Staff FindByEmailAndPassword(string email, string password)
    {
        return Entities.Values.FirstOrDefault(staff => staff.Email == email && staff.Password == password);
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